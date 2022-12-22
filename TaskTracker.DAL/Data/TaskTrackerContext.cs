using Microsoft.EntityFrameworkCore;
using TaskTracker.Infrastructures.Entities;

namespace TaskTracker.DAL.Data
{
    public class TaskTrackerContext : DbContext
    {
        public TaskTrackerContext(DbContextOptions<TaskTrackerContext> options) : base(options)
        {
        }

        public DbSet<Infrastructures.Entities.Task> Tasks { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
