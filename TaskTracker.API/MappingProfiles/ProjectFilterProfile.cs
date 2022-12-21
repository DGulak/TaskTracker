using AutoMapper;
using TaskTracker.API.Contracts.Requests.Queries;
using TaskTracker.Infrastructure.Filters;

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
