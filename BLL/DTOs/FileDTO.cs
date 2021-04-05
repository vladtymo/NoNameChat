using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class FileDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Path { get; set; }

        public int MessageId { get; set; }
        public virtual MessageDTO Message { get; set; }
    }
}
