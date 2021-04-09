using System;
using System.Collections.Generic;

namespace Client
{
    [Serializable]
    public class GroupViewModel : ViewModelBase
    {
        private string name;
        private string imagePath;
        private byte[] bytesImage;

        public int Id { get; set; }
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        public string ImagePath
        {
            get { return imagePath; }
            set { SetProperty(ref imagePath, value); }
        }

        public byte[] Bytes
        {
            get { return bytesImage; }
            set { SetProperty(ref bytesImage, value); }
        }

        public ICollection<UserViewModel> Users { get; set; }
        public ICollection<MessageViewModel> Messages { get; set; }

        public GroupViewModel()
        {
            Users = new HashSet<UserViewModel>();
            Messages = new HashSet<MessageViewModel>();
        }
    }
}
