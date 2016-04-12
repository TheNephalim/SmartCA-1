using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCA.Infrastructure;
using SmartCA.Infrastructure.RepositoryFramework;
using SmartCA.Model.Employees;
using SmartCA.Model.Projects;

namespace SmartCA.UnitTests.Employees
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        private TestContext testContextInstance;
        private UnitOfWork unitOfWork;
        private IEmployeeRepository repository;

        [TestInitialize]
        public void MyTestInitialize()
        {
            this.unitOfWork = new UnitOfWork();
            this.repository = RepositoryFactory.GetRepository<IEmployeeRepository, Project>(this.unitOfWork);
        }

        [TestMethod]
        public void GetPrincipalsTest()
        {
            IList<Employee> principals = this.repository.GetPrincipals();
            Assert.AreEqual(true, principals.Count > 0);
        }

        [DeploymentItem("SmartCA.sdf"), TestMethod()]
        public void GetCunstructionAdministrators()
        {
            IList<Employee> administrators = this.repository.GetConstructionAdministrators();
            Assert.AreEqual(true, administrators.Count > 0);
        }

    }
}
