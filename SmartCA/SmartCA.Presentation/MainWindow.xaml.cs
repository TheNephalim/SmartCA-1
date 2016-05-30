using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SmartCA.Infrastructure.UI;
using SmartCA.Presentation.Views;

namespace SmartCA.Presentation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectProject()
        {
            IView view = new SelectProjectView();
            view.Show();
        }

        private void Projects()
        {
            IView view = new Projects();
            view.Show();
        }

        private void ProjectInformation()
        {
            IView view = new ProjectInformationView();
            view.Show();
        }

        private void CompanyView()
        {
            IView view = new CompanyView();
            view.Show();
        }

        private void SelectProjectBtn_OnClick(object sender, RoutedEventArgs e)
        {
            SelectProject();
        }

        private void ProjectInfoBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ProjectInformation();
        }

        private void CompaniesBtn_OnClick(object sender, RoutedEventArgs e)
        {
            CompanyView();
        }

        private void SubmittalsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RFIsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ProposalRequestBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ChangeOrdersBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ConstructionChangeDirectivesBtn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ProjectsBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Projects();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            this.SelectProject();
        }
    }
}
