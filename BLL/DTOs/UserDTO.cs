using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] bytesImage { get; set; }

        //public virtual ICollection<Group> Groups { get; set; }
        //public virtual ICollection<Message> Messages { get; set; }
    }
}
