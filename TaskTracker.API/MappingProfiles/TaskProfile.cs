using AutoMapper;
using TaskTracker.API.DTO;

namespace TaskTracker.API.MappingProfiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskDTO, Infrastructure.Entities.Task>();
            CreateMap<Infrastructure.Entities.Task, TaskDTO>().ReverseMap();
        }
    }
}
