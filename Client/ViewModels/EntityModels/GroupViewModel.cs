namespace Client
{
    public class GroupViewModel : ViewModelBase
    {
        private string name;
        private string imagePath;

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
    }
}
