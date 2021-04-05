using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    class MessageDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int GroupId { get; set; }
        public GroupDTO Group { get; set; }

        public int FromId { get; set; }
        public UserDTO From { get; set; }

        public int? FileId { get; set; }
        public FileDTO File { get; set; }
    }
}
