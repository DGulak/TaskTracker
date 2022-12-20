﻿
namespace TaskTracker.DAL.Models
{
    internal class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public Enums.ProjectStatus ProjectStatus { get; set; }
        public int Priority { get; set; }
    }
}
