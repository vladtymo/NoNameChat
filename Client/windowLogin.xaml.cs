﻿using System;
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

namespace Client
{
    /// <summary>
    /// Interaction logic for windowLogin.xaml
    /// </summary>
    public partial class windowLogin : Window
    {
        LoginViewModel vm = null;

        public windowLogin()
        {
            vm = new LoginViewModel();
            DataContext = vm;
            InitializeComponent();
        }

        private void MainForgotPassword(object sender, MouseButtonEventArgs e)
        {
            windowRecover rw = new windowRecover();
            rw.ShowDialog();
        }

        private void MainWinClose(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
