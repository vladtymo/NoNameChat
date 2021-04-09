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
    public class LoginViewModel : ViewModelBase
    {

        private void OpenMainWindow()
        {
            windowAuthentication w = new windowAuthentication();
            w.ShowDialog();
        }

        private readonly ICommand openMainWindowCommand;

        public ICommand OpenMainWindowCommand => openMainWindowCommand;
        private void OpenRegisterWindow()
        {
            windowRegister mw = new windowRegister();
            mw.ShowDialog();
        }

        private readonly ICommand openRegisterWindowCommand;

        public ICommand OpenRegisterWindowCommand => openRegisterWindowCommand;

        public LoginViewModel()
        {
            openMainWindowCommand = new DelegateCommand(f => OpenMainWindow());
            openRegisterWindowCommand = new DelegateCommand(f => OpenRegisterWindow());
            User = new UserViewModel();
            OkCmd = new DelegateCommand((o) => { IsOK = true; ((Window)o).Close(); });
            CancelCmd = new DelegateCommand((o) => { IsOK = false; ((Window)o).Close(); });
        }

        public bool IsOK { get; set; }
        public ICommand OkCmd { get; }          
        public ICommand CancelCmd { get; }      
        public UserViewModel User { get; set; }
        public IEnumerable<FileViewModel> Files { get; }
        public IEnumerable<GroupViewModel> Groups { get; }
        public IEnumerable<MessageViewModel> Messages { get; }
    }
}
