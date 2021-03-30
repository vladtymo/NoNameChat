namespace DAL
{
    using System.Collections.Generic;

    public class Group
    {
        public Group()
        {
            Users = new HashSet<User>();
            Admins = new HashSet<Admin>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }
    }
}