using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL
{
    public interface IService
    {
        void CreateNewFile(FileDTO newFile);
        void CreateNewGroup(GroupDTO newGroup);
        void CreateNewMessage(MessageDTO newMessage);
        void CreateNewUser(UserDTO newUser);

        IEnumerable<FileDTO> GetAllFiles();
        IEnumerable<GroupDTO> GetAllGroups();
        IEnumerable<MessageDTO> GetAllMessages();
        IEnumerable<UserDTO> GetAllUsers();
    }
}
