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
using SmartCA.Presentation.ViewModels;
using SmartCA.Infrastructure.UI;

namespace SmartCA.Presentation.Views
{
    /// <summary>
    /// Логика взаимодействия для ProjectInformationView.xaml
    /// </summary>
    public partial class ProjectInformationView : Window, IView
    {
        public ProjectInformationView()
        {
            InitializeComponent();
            this.DataContext = new ProjectInformationViewModel(this);
        }
    }
}
