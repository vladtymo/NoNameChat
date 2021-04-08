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

        //public virtual ICollection<User> Users { get; set; }
        //public virtual ICollection<Message> Messages { get; set; }
    }
}
