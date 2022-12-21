using System.ComponentModel.DataAnnotations.Schema;
using TaskStatus = TaskTracker.Infrastructure.Enums.TaskStatus;

namespace TaskTracker.Infrastructure.Entities
{
    public class Task : BaseEntity
    {
        public TaskStatus TaskStatus { get; set; }
        public string Description { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

    }
}
