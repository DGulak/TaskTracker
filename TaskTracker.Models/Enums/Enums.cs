namespace TaskTracker.Infrastructures.Enums
{
    [Flags]
    public enum TaskStatus
    {
        NotStarted = 1,
        Active = 2,
        Completed = 4
    }

    [Flags]
    public enum ProjectStatus
    {
        ToDo = 1,
        InProgress = 2,
        Done = 4
    }
}
