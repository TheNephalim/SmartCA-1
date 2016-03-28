using SmartCA.Infrastructure.DomainBase;
using SmartCA.Infrastructure.EntityFactoryFramework;
using SmartCA.Infrastructure.RepositoryFramework;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace SmartCA.Infrastructure.Repositories
{
    public abstract class SqlCeRepositoryBase<T> :RepositoryBase<T> where T:EntityBase
    {
        /// <summary>
        /// The delegate signature required for callback methods
        /// </summary>
        /// <param name="entityAggregate"></param>
        /// <param name="childEntityKeyValue"></param>
        public delegate void AppendChildData(T entityAggregate, object childEntityKeyValue);

        private Database database;
        private IEntityFactory<T> entityFactory;
        private Dictionary<string, AppendChildData> childCallbacks;

        protected SqlCeRepositoryBase():this(null)
        {
        }

        protected SqlCeRepositoryBase(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.database = DatabaseFactory.CreateDatabase();
            this.entityFactory = EntityFactoryBuilder;
            this.childCallbacks = new Dictionary<string, AppendChildData>();
            this.BuildChildCallbacks();
        }

        protected abstract void BuildChildCallbacks();
        public abstract override T FindBy(object key);
        protected abstract override void PersistNewItem(T item);
        protected abstract override void PersistUpdateItem(T item);
        protected abstract override void PersistDeletedItem(T item);

        protected Database Database
        {
            get { return database; }
        }

        protected Dictionary<string, AppendChildData> ChildCallbacks {
            get { return childCallbacks; }
        }

        protected IDataReader ExecuteReader(string sql)
        {
            DbCommand command = this.database.GetSqlStringCommand(sql);
            return this.database.ExecuteReader(command);
        }

        protected virtual T BuildEntityFromSql(string sql)
        {
            T entity = default(T);
            using (IDataReader reader = this.ExecuteReader(sql))
            {
                if (reader.Read())
                {
                    entity = this.BuildEntityFromReader(reader);
                }
            }
            return entity;
        }

        protected virtual T BuildEntityFromReader(IDataReader reader)
        {
            T entity = this.entityFactory.BuildEntity(reader);
            if (this.childCallbacks != null && this.childCallbacks.Count > 0)
            {
                object childKeyValue = null;
                DataTable columnData = reader.GetSchemaTable();
                foreach (string childKeyName in childCallbacks.Keys)
                {
                    if (DataHelper.Reader)
                    {
                        childKeyValue = reader[childKeyName];
                    }
                    else
                    {
                        childKeyValue = null;
                    }
                    this.childCallbacks[childKeyName](entity, childKeyValue);
                }
            }
            return entity;
        }

        protected virtual List<T> BuildEntitiesFromSql(string sql)
        {
            List<T> entities = new List<T>();
            using (IDataReader reader = this.database.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    entities.Add(this.BuildEntityFromReader(reader));
                }
            }
            return entities;
        }
    }
}
