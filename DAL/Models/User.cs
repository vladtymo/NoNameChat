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
            Messages = new HashSet<Message>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<Group>  Groups { get; set; }
        public virtual ICollection<Message>  Messages { get; set; }

    }
}