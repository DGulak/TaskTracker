using Microsoft.AspNetCore.Mvc;
using TaskTracker.Infrastructures.Enums;

namespace TaskTracker.API.Contracts.Requests.Queries
{
    public class GetAllProjectsQuery
    {
        [FromQuery(Name = "startDate")]
        public DateTime? StartDate { get; set; }
        [FromQuery(Name = "completionDate")]
        public DateTime? CompletionDate { get; set; }
        [FromQuery(Name = "name")]
        public string? Name { get; set; }
        [FromQuery(Name = "priority")]
        public int? Priority { get; set; } = -1;
        [FromQuery(Name = "projectStatus")]
        public ProjectStatus? ProjectStatus { get; set; }
    }
}
