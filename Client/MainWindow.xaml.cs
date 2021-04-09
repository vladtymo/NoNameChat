using Client.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel vm = null;

        public MainWindow()
        {
            vm = new MainViewModel();
            DataContext = vm;
            InitializeComponent();
        }

        private void MainWinClose(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void MainWindowHide(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MainMenuOpen(object sender, MouseButtonEventArgs e)
        {
            Menu.Toggle();
        }

        private void MessangerSend(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void MainMenuHide(object sender, MouseButtonEventArgs e)
        {
            Menu.Hide();
        }
    }
}
