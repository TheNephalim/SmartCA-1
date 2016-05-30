using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCA.Infrastructure;
using SmartCA.Infrastructure.RepositoryFramework;
using SmartCA.Model.Companies;

namespace SmartCA.UnitTests.Companies
{
    [TestClass]
    public class CompanyRepositoryTest
    {
        private TestContext testContextInstance;
        private IUnitOfWork unitOfWork;
        private ICompanyRepository repository;

        [TestInitialize]
        public void MyTestInitialize()
        {
            this.unitOfWork = new UnitOfWork();
            this.repository = RepositoryFactory.GetRepository<ICompanyRepository, Company>(this.unitOfWork);
        }

        [DeploymentItem("SmartCA.sdf"), TestMethod]
        public void FindByKeyTest()
        {
            object key = "8b6a05be-6106-45fb-b6cc-b03cfa5ab74b";
            Company company = this.repository.FindBy(key);
            Assert.AreEqual("My Company", company.Name);
        }

        [DeploymentItem("SmartCA.sdf"), TestMethod]
        public void FindAllTest()
        {
            IList<Company> companies = this.repository.FindAll();
            Assert.AreEqual(2, companies.Count);
        }
        
        [DeploymentItem("SmartCA.sdf"), TestMethod]
        public void AddTest()
        {
            Company company = new Company();
            company.Name = "My Test Company";
            
            repository.Add(company);
            this.unitOfWork.Commit();

            Company savedCompany = this.repository.FindBy(company.Key);
            Assert.AreEqual("My Test Company", savedCompany.Name);

            this.repository.Remove(savedCompany);
            this.unitOfWork.Commit();
        }

        [DeploymentItem("SmartCA.sdf"), TestMethod]
        public void UpdateTest()
        {
            object key = "59427e22-0c9e-4821-95d6-9c9f541bf37a";
            Company company = repository.FindBy(key);
            string companyName = company.Name;

            company.Name = "My Updated Company";
            repository[company.Key] = company;
            this.unitOfWork.Commit();

            Company savedCompany = this.repository.FindBy(company.Key);
            Assert.AreEqual("My Updated Company", savedCompany.Name);

            savedCompany.Name = companyName;
            repository[savedCompany.Key] = savedCompany;
            unitOfWork.Commit();
        }

        [DeploymentItem("SmartCA.sdf"), TestMethod]
        public void RemoveTest()
        {
            object key = "8b6a05be-6106-45fb-b6cc-b03cfa5ab74b";
            Company company = repository.FindBy(key);
            this.repository.Remove(company);
            unitOfWork.Commit();

            IList<Company> companies = repository.FindAll();
            Assert.AreEqual(1, companies.Count);

            repository.Add(company);
            unitOfWork.Commit();
        }
    }
}
