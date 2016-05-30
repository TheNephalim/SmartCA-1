using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCA.Infrastructure;
using SmartCA.Infrastructure.RepositoryFramework;
using SmartCA.Model.Companies;
using SmartCA.Model.Contacts;
using SmartCA.Model.Projects;

namespace SmartCA.UnitTests.Projects
{
    [TestClass]
    public class ProjectRepositoryTest
    {
        private TestContext testContextInstance;
        private IUnitOfWork unitOfWork;
        private IProjectRepository repository;

        [TestInitialize]
        public void MyTestInitialize()
        {
            this.unitOfWork = new UnitOfWork();
            this.repository = RepositoryFactory.GetRepository<IProjectRepository, Project>(this.unitOfWork);
        }

        [DeploymentItem("SmartCA.sdf"), TestMethod]
        public void FindBySegmentsAndNotCompletedTest()
        {
            List<MarketSegment> segments = new List<MarketSegment>();
            segments.Add(new MarketSegment(1, null, "test", "test"));
            
            IList<Project> projects = this.repository.FindBy(segments, false);
            
            Assert.AreEqual(1, projects.Count);
        }

        [DeploymentItem("SmartCA.sdf"), TestMethod]
        public void FindByProjectNumberTest()
        {
            string projectNumber = "12345.00";
            Project project = this.repository.FindBy(projectNumber);
            Assert.AreEqual("My Project", project.Name);
        }

        [DeploymentItem("SmartCA.sdf"), TestMethod]
        public void FindAllMarketSegmentTest()
        {
            IList<MarketSegment> segments = this.repository.FindAllMarketSegments();
            Assert.AreEqual(true, segments.Count > 0);
        }

        [DeploymentItem("SmartCA.sdf"), TestMethod]
        public void SaveContactTest()
        {
            string projectNumber = "12345.00";
            Project project = repository.FindBy(projectNumber);
            int oldCount = project.Contacts.Count;

            IUnitOfWork contactUnitOfWork = new UnitOfWork();
            IContactRepository contactRepository = RepositoryFactory.GetRepository<IContactRepository, Contact>(unitOfWork);
            object contactKey = "“cae9eb86-5a86-4965-9744-18326fd56a3b";
            Contact contact = contactRepository.FindBy(contactKey);
            
            ProjectContact projectContact = new ProjectContact(project, Guid.NewGuid(), contact);
            this.repository.SaveContact(projectContact);
            this.unitOfWork.Commit();

            Project updatedProject = this.repository.FindBy(projectNumber);
            Assert.AreEqual(oldCount, updatedProject.Contacts.Count -1);
        }
    }
}
