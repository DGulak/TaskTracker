namespace TaskTracker.Infrastructure.Filters
{
    public class GetAllProjectsFilter
    {
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
    }
}
