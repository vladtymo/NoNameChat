﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for windowRegister.xaml
    /// </summary>
    public partial class windowRegister : Window
    {
        public windowRegister()
        {
            InitializeComponent();
        }

        private void RegisterClose(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(1226);
            Close();

        }
    }
}
