using AutoMapper;
using TaskTracker.API.DTO;

namespace TaskTracker.API.MappingProfiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<InTaskDTO, Infrastructures.Entities.Task>();
            CreateMap<Infrastructures.Entities.Task, OutTaskDTO>().ReverseMap();
        }
    }
}
