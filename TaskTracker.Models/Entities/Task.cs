using System.ComponentModel.DataAnnotations.Schema;
using TaskStatus = TaskTracker.Infrastructures.Enums.TaskStatus;

namespace TaskTracker.Infrastructures.Entities
{
    public class Task : BaseEntity
    {
        public TaskStatus TaskStatus { get; set; }
        public string Description { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

    }
}
