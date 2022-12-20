using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
