using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class FileViewModel : ViewModelBase
    {
        private string name;
        private string path;
        private MessageViewModel message;

        public int Id { get; set; }

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public string Path
        {
            get { return path; }
            set { SetProperty(ref path, value); }
        }


        public int MessageId { get; set; }
        public virtual MessageViewModel Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }
    }
}
