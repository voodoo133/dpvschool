using Microsoft.EntityFrameworkCore;
 
namespace Tasks.Data
{
    public class TasksContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }

        public TasksContext(DbContextOptions<TasksContext> options) : base(options)
        {
            
        }
    }
}