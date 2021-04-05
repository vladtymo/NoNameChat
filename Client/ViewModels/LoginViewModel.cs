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
        public LoginViewModel(IService service, IMapper mapper)
        {
            Files = mapper.Map<IEnumerable<FileViewModel>>(service.GetAllFiles());
            Groups= mapper.Map<IEnumerable<GroupViewModel>>(service.GetAllGroups());
            Messages = mapper.Map<IEnumerable<MessageViewModel>>(service.GetAllMessages());

            User = new UserViewModel();
            OkCmd = new DelegateCommand((o) => { IsOK = true; ((Window)o).Close(); });
            CancelCmd = new DelegateCommand((o) => { IsOK = false; ((Window)o).Close(); });
        }

        public bool IsOK { get; set; }
        public ICommand OkCmd { get; }           // Example in RegisterViewModel.cs
        public ICommand CancelCmd { get; }       // Example in RegisterViewModel.cs
        public UserViewModel User { get; set; }
        public IEnumerable<FileViewModel> Files { get; }
        public IEnumerable<GroupViewModel> Groups { get; }
        public IEnumerable<MessageViewModel> Messages { get; }
    }
}
