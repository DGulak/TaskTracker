using Microsoft.EntityFrameworkCore;
using TaskTracker.Infrastructure.Entities;

namespace TaskTracker.DAL.Data
{
    public class TaskTrackerContext : DbContext
    {
        public TaskTrackerContext(DbContextOptions<TaskTrackerContext> options)
        : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Infrastructure.Entities.Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
