﻿using SmartCA.Infrastructure.UI;
using SmartCA.Presentation.ViewModels;
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

namespace SmartCA.Presentation.Views
{
    /// <summary>
    /// Логика взаимодействия для SelectProjectView.xaml
    /// </summary>
    public partial class SelectProjectView : Window, IView
    {
        public SelectProjectView()
        {
            InitializeComponent();
            this.DataContext = new SelectProjectViewModel(this);
        }
    }
}
