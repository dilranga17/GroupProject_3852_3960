﻿using StudentRegistrationSystem.ViewModel;
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

namespace StudentRegistrationSystem.View
{
    /// <summary>
    /// Interaction logic for LoginWindow2.xaml
    /// </summary>
    public partial class LoginWindow2 : Window
    {
        public LoginWindow2()
        {
            DataContext = new LoginWindowVM();
            InitializeComponent();
        }
    }
}
