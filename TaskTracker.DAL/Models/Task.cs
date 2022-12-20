namespace TaskTracker.DAL.Models
{
    internal class Task
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Enums.TaskStatus TaskStatus { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }

    }
}
