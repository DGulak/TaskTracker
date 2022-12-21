using AutoMapper;
using TaskTracker.API.DTO;
using TaskTracker.Infrastructure.Entities;

namespace TaskTracker.API.MappingProfiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectDTO, Project>();
            CreateMap<Project, ProjectDTO>().ReverseMap();
        }
    }
}
