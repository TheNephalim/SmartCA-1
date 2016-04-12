using SmartCA.Model.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCA.Infrastructure.Repositories
{
    public class EmployeeRepository : SqlCeRepositoryBase<Employee>, IEmployeeRepository
    {

        #region Contructors

        public EmployeeRepository():this(null)
        {
        }

        public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        #endregion

        protected override void BuildChildCallbacks()
        {
            throw new NotImplementedException();
        }

        #region UnitOfWork
        protected override void PersistNewItem(Employee item)
        {
            throw new NotImplementedException();
        }

        protected override void PersistUpdateItem(Employee item)
        {
            throw new NotImplementedException();
        }

        protected override void PersistDeletedItem(Employee item)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region queries
        protected override string GetBaseQuery()
        {
            return "SELECT * FROM Employee";
        }

        protected override string GetBaseWhereClause()
        {
            return " WHERE EmployeeID = {0};";
        }
        #endregion

        #region IEmployeeRepository implementation
        public IList<Employee> GetConstructionAdministrators()
        {
            StringBuilder builder = GetBaseQueryBuilder();
            builder.Append(" WHERE JobTitle like '%Construction Administrator%'");
            return this.BuildEntitiesFromSql(builder.ToString());
        }

        public IList<Employee> GetPrincipals()
        {
            StringBuilder builder = GetBaseQueryBuilder();
            builder.Append(" WHERE JobTitle like '%Principal%'");
            return this.BuildEntitiesFromSql(builder.ToString());
        }
        #endregion
    }
}
