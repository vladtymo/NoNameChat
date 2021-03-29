namespace DAL
{
    using System.Collections.Generic;

    public class Admin
    {

        public Admin()
        {
            Users = new HashSet<User>();
            Groups = new HashSet<Group>();
        }
        public int Id { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}