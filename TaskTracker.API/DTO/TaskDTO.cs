using System.ComponentModel.DataAnnotations;
using TaskStatus = TaskTracker.Infrastructure.Enums.TaskStatus;

namespace TaskTracker.API.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        [Required]
        public int ProjectId { get; set; }
    }
}
