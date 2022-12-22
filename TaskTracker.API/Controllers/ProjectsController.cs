using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.API.Contracts.Requests.Queries;
using TaskTracker.API.DTO;
using TaskTracker.BLL;
using TaskTracker.BLL.Contracts;
using TaskTracker.Infrastructure.Entities;
using TaskTracker.Infrastructure.Enums;
using TaskTracker.Infrastructure.Filters;

namespace TaskTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IProjectLogic _pojectLogic;
        private readonly ITaskLogic _taskLogic;
        public ProjectsController(
            ILogger<ProjectsController> logger,
            IMapper mapper,
            IProjectLogic projectLogic,
            ITaskLogic taskLogic)
        {
            _logger = logger;
            _mapper = mapper;
            _pojectLogic = projectLogic;
            _taskLogic = taskLogic;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetAll([FromQuery] GetAllProjectsQuery query)
        {
            var filter = _mapper.Map<GetAllProjectsFilter>(query);

            if(filter?.Priority < 0)
            {
                string message = "Project priority incorrect";
                _logger.LogWarning(message);
                return BadRequest(message);
            }

            var projects = _pojectLogic.GetAll(filter);

            return Ok(_mapper.Map<IEnumerable<ProjectDTO>>(projects));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDTO>> GetById(int id)
        {
            var project = _pojectLogic.GetById(id);

            if (project is null)
            {
                _logger.LogWarning($"Project not found. id:{id}");
                return NotFound();
            }

            return Ok(_mapper.Map<ProjectDTO>(project));
        }

        [HttpGet("{id}/Tasks")]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetTasks(int id)
        {
            if(id <= 0)
            {
                _logger.LogWarning($"Project id <= 0");
                return BadRequest();
            }
            var tasks = _taskLogic.Where(t => t.ProjectId == id);

            if(tasks is null)
            {
                _logger.LogWarning($"Tasks not found.");
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<TaskDTO>> (tasks));
        }
   
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, ProjectDTO projectDTO)
        {
            if (projectDTO == null || id <= 0)
            {
                _logger.LogWarning($"Project was null or id <= 0");
                return BadRequest();
            }

            projectDTO.Id = id;
            var post = _mapper.Map<Project>(projectDTO);
            _pojectLogic.Update(post);
            return Ok();
        }

        [HttpPut("{id}/AssignTask/{taskId}")]
        public async Task<ActionResult> Update([FromRoute] int id, [FromRoute] int taskId)
        {
            if (taskId <= 0 || id <= 0)
            {
                _logger.LogWarning($"id or taskId was <= 0");
                return BadRequest();
            }

            _taskLogic.ReassignTask(id, taskId);

            return Ok();
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(ProjectDTO projectDTO)
        {
            if (projectDTO == null)
            {
                string message = "Project was null";
                _logger.LogWarning(message);
                return BadRequest(message);
            }

            if(projectDTO.ProjectStatus != ProjectStatus.ToDo &&
                projectDTO.ProjectStatus != ProjectStatus.InProgress &&
                projectDTO.ProjectStatus != ProjectStatus.Done)
            {
                string message = "Project status incorrect";
                _logger.LogWarning(message);
                return BadRequest(message);
            }

            var project = _mapper.Map<Project>(projectDTO);

            if(project.ProjectStatus == 0 || string.IsNullOrEmpty(project.Name))
            {
                string message = "Project status or project name is incorrect";
                _logger.LogWarning(message);
                return BadRequest(message);
            }

            await _pojectLogic.CreateAsync(project);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"id < 0");
                return BadRequest();
            }

            _pojectLogic.Delete(id);
            return Ok();
        }

    }
}
