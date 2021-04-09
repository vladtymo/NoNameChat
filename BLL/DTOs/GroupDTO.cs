using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class GroupDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public byte[] bytesImage { get; set; }

        public ICollection<UserDTO> Users { get; set; }
        public ICollection<MessageDTO> Messages { get; set; }

        public GroupDTO()
        {
            Users = new HashSet<UserDTO>();
            Messages = new HashSet<MessageDTO>();
        }
    }
}
