using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using SmartCA.Infrastructure.DomainBase;
using SmartCA.Infrastructure.EntityFactoryFramework;
using SmartCA.Infrastructure.RepositoryFramework;
using System.Data.SqlServerCe;

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
        private string baseQuery;
        private string baseWhereClause;

        protected SqlCeRepositoryBase():this(null)
        {
        }

        protected SqlCeRepositoryBase(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            database = factory.Create("SmartCA");
            //this.database = DatabaseFactory.CreateDatabase();
            this.entityFactory = EntityFactoryBuilder.BuildFactory<T>();
            this.childCallbacks = new Dictionary<string, AppendChildData>();
            this.BuildChildCallbacks();
            this.baseQuery = this.GetBaseQuery();
            this.baseWhereClause = this.GetBaseWhereClause();
        }

        protected abstract void BuildChildCallbacks();

        /*???*/
        protected virtual StringBuilder GetBaseQueryBuilder()
        {
            StringBuilder builder = new StringBuilder(50);
            builder.Append(baseQuery);
            return builder;
        }


        public override T FindBy(object key)
        {
            StringBuilder builder = this.GetBaseQueryBuilder();
            builder.Append(this.BuildBaseWhereClause(key));
            return this.BuildEntityFromSql(builder.ToString());
        }

        public override IList<T> FindAll()
        {
            StringBuilder builder = this.GetBaseQueryBuilder();
            builder.Append(";");
            return this.BuildEntitiesFromSql(builder.ToString());
        }

        protected abstract override void PersistNewItem(T item);
        protected abstract override void PersistUpdateItem(T item);
        protected abstract override void PersistDeletedItem(T item);

        protected abstract string GetBaseQuery();
        protected abstract string GetBaseWhereClause();

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
                    /*???*/
                    if (DataHelper.ReaderContainsColumnName(columnData, childKeyName))
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
            using (IDataReader reader = this.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    entities.Add(this.BuildEntityFromReader(reader));
                }
            }
            return entities;
        }

        protected virtual string BuildBaseWhereClause(object key)
        {
            return string.Format(this.baseWhereClause, key);
        }

        public static void UpgradeDataBase()
        {
            string connStringCI = "Data Source= SmartCA.sdf; LCID= 1033";

            // Set "Case Sensitive" to true to change the collation from CI to CS.
            string connStringCS = "Data Source= SmartCA.sdf; LCID= 1033; Case Sensitive=true";

            SqlCeEngine engine = new SqlCeEngine(connStringCI);

            // The collation of the database will be case sensitive because of 
            // the new connection string used by the Upgrade method.                
            engine.Upgrade(connStringCS);

            SqlCeConnection conn = null;
            conn = new SqlCeConnection(connStringCI);
            conn.Open();

            //Retrieve the connection string information - notice the 'Case Sensitive' value.
            List<KeyValuePair<string, string>> dbinfo = conn.GetDatabaseInfo();

            Console.WriteLine("\nGetDatabaseInfo() results:");

            foreach (KeyValuePair<string, string> kvp in dbinfo)
            {
                Console.WriteLine(kvp);
            }
        }
    }
}
