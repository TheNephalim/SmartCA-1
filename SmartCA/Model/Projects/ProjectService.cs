using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Infrastructure.RepositoryFramework;
using SmartCA.Infrastructure;

namespace SmartCA.Model.Projects
{
    public static class ProjectService
    {
        private static IProjectRepository repository;
        private static IUnitOfWork unitOfWork;

        static ProjectService()
        {
            ProjectService.unitOfWork = new UnitOfWork();
            ProjectService.repository =
                RepositoryFactory.GetRepository<IProjectRepository, Project>(ProjectService.unitOfWork);
        }

        public static IList<Project> GetAllProjects()
        {
            return ProjectService.repository.FindAll();
        }

        public static IList<MarketSegment> GetMarketSegments()
        {
            return ProjectService.repository.FindAllMarketSegments();
        }

        public static void SaveProject(Project project)
        {
            ProjectService.repository[project.Key] = project;
            ProjectService.unitOfWork.Commit();
        }
    }
}
