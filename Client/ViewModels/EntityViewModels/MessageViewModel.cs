using System;

namespace Client
{
    [Serializable]
    public class MessageViewModel : ViewModelBase
    {
        private string text;
        private GroupViewModel group;
        //private FileViewModel file;
        private UserViewModel from;

        public int Id { get; set; }

        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }


        public int GroupId { get; set; }
        public GroupViewModel Group
        {
            get { return group; }
            set { SetProperty(ref group, value); }
        }


        public int FromId { get; set; }
        public UserViewModel From
        {
            get { return from; }
            set { SetProperty(ref from, value); }
        }


        public int? FileId { get; set; }
        //public FileViewModel File
        //{
        //    get { return file; }
        //    set { SetProperty(ref file, value); }
        //}

        public override string ToString()
        {
            return Text;
        }

    }
}
