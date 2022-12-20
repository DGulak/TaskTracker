using Microsoft.EntityFrameworkCore;

namespace TaskTracker.DAL.Data
{
    internal class TaskTrackerContext : DbContext
    {
        public TaskTrackerContext(DbContextOptions<TaskTrackerContext> options)
        : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Models.Project> Projects { get; set; }
    }
}
