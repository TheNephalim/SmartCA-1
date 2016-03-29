using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Infrastructure.RepositoryFramework;

namespace SmartCA.Model.Projects
{
    public static class ProjectService
    {
        public static IList<Project> GetAllProjects()
        {
            IProjectRepository repository = RepositoryFactory.GetRepository<IProjectRepository, Project>();
            return repository.FindAll();
        }
    }
}
