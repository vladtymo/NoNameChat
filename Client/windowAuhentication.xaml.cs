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

namespace Client
{
    /// <summary>
    /// Interaction logic for windowAuhentication.xaml
    /// </summary>
    public partial class windowAuhentication : Window
    {
        public windowAuhentication()
        {
            InitializeComponent();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void BtnSubmit(object sender, RoutedEventArgs e)
        {

        }
    }
}
