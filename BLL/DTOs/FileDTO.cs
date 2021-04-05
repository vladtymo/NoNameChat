using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    class FileDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public byte[] bytesFile { get; set; }

        public int MessageId { get; set; }
        public MessageDTO Message { get; set; }
    }
}
