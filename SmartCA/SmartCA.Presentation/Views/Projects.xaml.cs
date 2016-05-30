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
using SmartCA.Presentation.ViewModels;

namespace SmartCA.Presentation.Views
{
    /// <summary>
    /// Логика взаимодействия для Projects.xaml
    /// </summary>
    public partial class Projects : Window, IView
    {
        public Projects()
        {
            InitializeComponent();
            this.DataContext = new SelectProjectViewModel(this);
        }
    }
}
