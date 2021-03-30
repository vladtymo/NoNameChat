namespace DAL
{
    using System.Collections.Generic;

    public class Group
    {
        public Group()
        {
            Users = new HashSet<User>();
            Messages = new HashSet<Message>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}