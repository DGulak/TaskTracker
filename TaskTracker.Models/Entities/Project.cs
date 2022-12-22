using TaskTracker.Infrastructures.Enums;

namespace TaskTracker.Infrastructures.Entities
{
    public class Project : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
    }
}
