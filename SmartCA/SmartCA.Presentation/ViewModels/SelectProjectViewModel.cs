using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SmartCA.Application;
using SmartCA.Infrastructure.UI;
using SmartCA.Presentation.Views;
using SmartCA.Model.Projects;

namespace SmartCA.Presentation.ViewModels
{
    public class SelectProjectViewModel
    {
        private CollectionView projects;
        private DelegateCommand selectCommand;
        private DelegateCommand cancelCommand;
        private IView view;

        public SelectProjectViewModel()
            :this(null)
        {
        }

        public SelectProjectViewModel(IView view)
        {
            this.view = view;
            this.projects = new CollectionView(ProjectService.GetAllProjects());
            this.selectCommand = new DelegateCommand(this.SelectCommandHandler);
            this.cancelCommand = new DelegateCommand(this.CancelCommandHandler);
        }

        public CollectionView Projects {
            get { return projects; }
        }

        public DelegateCommand SelectCommand
        {
            get { return selectCommand; }
        }

        public DelegateCommand CancelCommand {
            get { return cancelCommand; }
        }

        private void SelectCommandHandler(object sender, EventArgs e)
        {
            Project project = this.Projects.CurrentItem as Project;
            UserSession.CurrentProject = project;
            this.view.Close();
        }

        private void CancelCommandHandler(object sender, EventArgs e)
        {
            this.view.Close();
        }

    }
}
