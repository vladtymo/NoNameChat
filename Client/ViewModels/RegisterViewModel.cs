using AutoMapper;
using BLL;
using Client.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client
{
    public class RegisterViewModel : ViewModelBase
    {
        public RegisterViewModel()
        {
            User = new UserViewModel();
            OkCmd = new DelegateCommand((o) => { IsOK = true; ((Window)o).Close(); });
            CancelCmd = new DelegateCommand((o) => { IsOK = false; ((Window)o).Close(); });
        }

        public bool IsOK { get; set; }

        //  Example :
        //  <Button Command = "{Binding CancelCmd, Mode=OneWay}" CommandParameter="{Binding ElementName=window}" Width="100" Margin="20,10" Padding="10">Cancel</Button>

        public ICommand OkCmd { get; }

        //  Example :
        //  <Button Command = "{Binding OkCmd, Mode=OneWay}" CommandParameter="{Binding ElementName=window}" Width="100" Margin="20,10" Padding="10">OK</Button>

        public ICommand CancelCmd { get; }
        public UserViewModel User { get; set; }
    }
}
