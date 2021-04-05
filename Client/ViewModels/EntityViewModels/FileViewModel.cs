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
        private byte[] bytesFile;

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
        public MessageViewModel Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        public byte[] Bytes
        {
            get { return bytesFile; }
            set { SetProperty(ref bytesFile, value); }
        }
    }
}
