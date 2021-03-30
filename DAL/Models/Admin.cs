namespace DAL
{
    using System.Collections.Generic;

    public class Admin
    {
        public Admin()
        {
            Groups = new HashSet<Group>();
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}