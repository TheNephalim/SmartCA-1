using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Infrastructure;
using SmartCA.Infrastructure.RepositoryFramework;

namespace SmartCA.Model.Companies
{
    public static class CompanyService
    {
        private static ICompanyRepository repository;
        private static IUnitOfWork unitOfWork;

        static CompanyService()
        {
            CompanyService.unitOfWork = new UnitOfWork();
            repository = RepositoryFactory.GetRepository<ICompanyRepository, Company>(unitOfWork);
        }

        public static IList<Company> GetOwners()
        {
            return GetAllCompanies();
        }

        public static IList<Company> GetAllCompanies()
        {
            return CompanyService.repository.FindAll();
        }

        public static void SaveCompany(Company company)
        {
            CompanyService.repository[company.Key] = company;
            CompanyService.unitOfWork.Commit();
        }
    }
}
