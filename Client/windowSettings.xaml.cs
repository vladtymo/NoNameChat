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
    /// Interaction logic for windowSettings.xaml
    /// </summary>
    public partial class windowSettings : Window
    {
        public windowSettings()
        {
            InitializeComponent();
        }

        private void SettingsClose(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void UploadPhoto(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void ChangePassword(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
