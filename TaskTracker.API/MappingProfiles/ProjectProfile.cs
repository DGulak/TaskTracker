using AutoMapper;
using TaskTracker.API.DTO;
using TaskTracker.Infrastructures.Entities;

namespace TaskTracker.API.MappingProfiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<InProjectDTO, Project>();
            CreateMap<Project, OutProjectDTO>().ReverseMap();
        }
    }
}
