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

        IEnumerable<FileDTO> GetAllFile();
        IEnumerable<GroupDTO> GetAllGroup();
        IEnumerable<MessageDTO> GetAllMessage();
        IEnumerable<UserDTO> GetAllUser();
    }
}
