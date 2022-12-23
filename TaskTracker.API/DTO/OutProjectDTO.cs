using System.ComponentModel.DataAnnotations;
using TaskTracker.Infrastructures.Enums;

namespace TaskTracker.API.DTO
{
    /// <summary>
    /// ProjectStatus:
    /// 1 - ToDo,
    /// 2 - InProgress,
    /// 4 - Done
    /// </summary>
    public class OutProjectDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CompletionDate { get; set; }

        [Required]
        public ProjectStatus ProjectStatus { get; set; }

        public int Priority { get; set; }
    }
}
