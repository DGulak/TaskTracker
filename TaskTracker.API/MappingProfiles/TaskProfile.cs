using AutoMapper;
using TaskTracker.API.DTO;

namespace TaskTracker.API.MappingProfiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskDTO, Infrastructures.Entities.Task>();
            CreateMap<Infrastructures.Entities.Task, TaskDTO>().ReverseMap();
        }
    }
}
