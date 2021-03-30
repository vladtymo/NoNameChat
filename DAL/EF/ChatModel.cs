namespace DAL
{
    using System.Data.Entity;
    using System.Linq;

    public class ChatModel : DbContext
    {
        public ChatModel()
            : base("name=ChatModel")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }

    }
}