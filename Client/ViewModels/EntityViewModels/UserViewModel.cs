using System;

namespace Client
{
    [Serializable]
    public class UserViewModel : ViewModelBase
    {
        private string name;
        private string password;
        private string email;
        private string phone;
        private string imagePath;
        private byte[] bytesImage;

        public int Id { get; set; }

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        public string Phone
        {
            get { return phone; }
            set { SetProperty(ref phone, value); }
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
    }
}
