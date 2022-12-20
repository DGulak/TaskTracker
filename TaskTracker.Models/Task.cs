using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTracker.Models
{
    public class Task : BaseEntity
    {
        public TaskStatus TaskStatus { get; set; }
        public string Description { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

    }
}
