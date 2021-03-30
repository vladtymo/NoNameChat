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
            modelBuilder.Entity<Message>().HasOptional(m => m.File).WithRequired(f => f.Message).WillCascadeOnDelete(false);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

    }
}