namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            Groups = new HashSet<Group>();
            Admins = new HashSet<Admin>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Group>  Groups  { get; set; }
        public virtual ICollection<Admin>  Admins  { get; set; }

    }
}