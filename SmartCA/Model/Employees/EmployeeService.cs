using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Infrastructure;
using SmartCA.Infrastructure.RepositoryFramework;

namespace SmartCA.Model.Employees
{
    public static class EmployeeService
    {
        private static IEmployeeRepository repository;
        private static IUnitOfWork unitOfWork;

        static EmployeeService()
        {
            unitOfWork = new UnitOfWork();
            repository = RepositoryFactory.GetRepository<IEmployeeRepository, Employee>(unitOfWork);
        }

        public static IList<Employee> GetConstractionAdministrators()
        {
            return repository.GetConstructionAdministrators();
        }

        public static IList<Employee> GetPrincipals()
        {
            return repository.GetPrincipals();
        }
    }
}
