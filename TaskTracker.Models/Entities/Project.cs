using TaskTracker.Infrastructure.Enums;

namespace TaskTracker.Infrastructure.Entities
{
    public class Project : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
    }
}
