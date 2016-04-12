using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCA.Infrastructure;
using SmartCA.Infrastructure.RepositoryFramework;
using SmartCA.Model.Projects;

namespace SmartCA.UnitTests.Projects
{
    [TestClass]
    public class ProjectRepositoryTest
    {
        private TestContext testContextInstance;
        private UnitOfWork unitOfWork;
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
    }
}
