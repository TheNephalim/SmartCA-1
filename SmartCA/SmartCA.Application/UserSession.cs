using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Model.Projects;

namespace SmartCA.Application
{
    public static class UserSession
    {
        private static Project currentProject;

        public static Project CurrentProject {
            get { return currentProject; }
            set { currentProject = value; }
        }
    }
}
