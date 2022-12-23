using System.ComponentModel.DataAnnotations;
using TaskStatus = TaskTracker.Infrastructures.Enums.TaskStatus;

namespace TaskTracker.API.DTO
{
    /// <summary>
    /// TaskStatus:
    /// 1 - NotStarted,
    /// 2 - Active,
    /// 4 - Completed,
    /// </summary>
    public class InTaskDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public TaskStatus TaskStatus { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        [Required]
        public int ProjectId { get; set; }
    }
}
