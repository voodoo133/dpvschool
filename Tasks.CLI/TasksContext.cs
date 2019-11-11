using Microsoft.EntityFrameworkCore;
 
namespace Tasks
{
    public class TasksContext : DbContext
    {
        public DbSet<Job> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
         
         
        public TasksContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Tasks;Username=postgres;Password=password");
        }
    }
}