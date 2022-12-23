using Microsoft.AspNetCore.Mvc;
using TaskTracker.Infrastructures.Enums;

namespace TaskTracker.API.Contracts.Requests.Queries
{
    public class GetAllProjectsQuery
    {
        [FromQuery(Name = "startDate")]
        public DateTime? StartDate { get; set; } = null;
        [FromQuery(Name = "completionDate")]
        public DateTime? CompletionDate { get; set; } = null;
        [FromQuery(Name = "name")]
        public string? Name { get; set; } = null;
        [FromQuery(Name = "priority")]
        public int? Priority { get; set; } = null;
        [FromQuery(Name = "projectStatus")]
        public ProjectStatus? ProjectStatus { get; set; } = null;
    }
}
