using AutoMapper;
using TaskTracker.API.Contracts.Requests.Queries;
using TaskTracker.Infrastructures.Filters;

namespace TaskTracker.API.MappingProfiles
{
    public class ProjectFilterProfile : Profile
    {
        public ProjectFilterProfile()
        {
            CreateMap<GetAllProjectsQuery, GetAllProjectsFilter>();
        }
    }
}
