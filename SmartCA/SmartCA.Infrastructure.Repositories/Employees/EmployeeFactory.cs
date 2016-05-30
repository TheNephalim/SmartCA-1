using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Infrastructure.EntityFactoryFramework;
using SmartCA.Model.Employees;

namespace SmartCA.Infrastructure.Repositories
{
    internal class EmployeeFactory:IEntityFactory<Employee>
    {
        internal static class FieldNames
        {
            public const string EmployeeId = "EmployeeId";
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
        }

        public Employee BuildEntity(IDataReader reader)
        {
            Employee employee = new Employee(
                reader[FieldNames.EmployeeId]
                , reader[FieldNames.FirstName].ToString()
                , reader[FieldNames.LastName].ToString());

            return employee;
        }
    }
}
