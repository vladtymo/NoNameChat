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
    /// Interaction logic for windowLogin.xaml
    /// </summary>
    public partial class windowLogin : Window
    {
        public windowLogin()
        {
            InitializeComponent();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
