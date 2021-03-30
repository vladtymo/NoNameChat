using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int? ToId { get; set; }
        public virtual User To { get; set; }

        public int FromId { get; set; }
        public virtual User From { get; set; }

        public int? FileId { get; set; }
        public virtual File File { get; set; }
    }
}
