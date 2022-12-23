using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.API.Contracts.Requests.Queries;
using TaskTracker.API.DTO;
using TaskTracker.BLL.Contracts;
using TaskTracker.Infrastructures.Entities;
using TaskTracker.Infrastructures.Enums;
using TaskTracker.Infrastructures.Filters;

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

        /// <summary>
        /// Returns all projects
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutProjectDTO>>> GetAll([FromQuery] GetAllProjectsQuery? query)
        {
            var filter = _mapper.Map<GetAllProjectsFilter>(query);

            if (filter?.Priority < -1)
            {
                string message = "Project priority incorrect";
                _logger.LogWarning(message);
                return BadRequest(message);
            }

            var projects = _pojectLogic.GetAll(filter);

            return Ok(_mapper.Map<IEnumerable<OutProjectDTO>>(projects));
        }

        /// <summary>
        /// Return a project for given id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<OutProjectDTO>> GetById(int id)
        {
            var project = _pojectLogic.GetById(id);

            if (project is null)
            {
                _logger.LogWarning($"Project not found. id:{id}");
                return NotFound();
            }

            return Ok(_mapper.Map<OutProjectDTO>(project));
        }

        /// <summary>
        /// Get all project tasks
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/Tasks")]
        public async Task<ActionResult<IEnumerable<OutTaskDTO>>> GetTasks(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Project id <= 0");
                return BadRequest();
            }
            var tasks = _taskLogic.Where(t => t.ProjectId == id);

            if (tasks is null)
            {
                _logger.LogWarning($"Tasks not found.");
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<OutTaskDTO>>(tasks));
        }

        /// <summary>
        /// Update project information by given project id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projectDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, InProjectDTO projectDTO)
        {
            if (projectDTO == null || id <= 0)
            {
                _logger.LogWarning($"Project was null or id <= 0");
                return BadRequest();
            }

            var post = _mapper.Map<Project>(projectDTO);
            post.Id = id;
            _pojectLogic.Update(post);
            return Ok();
        }

        /// <summary>
        /// Assign task to project by its ids
        /// </summary>
        /// <param name="id"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Create a new project
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult> Create(InProjectDTO projectDTO)
        {
            if (projectDTO == null)
            {
                string message = "Project was null";
                _logger.LogWarning(message);
                return BadRequest(message);
            }

            if (projectDTO.ProjectStatus != ProjectStatus.ToDo &&
                projectDTO.ProjectStatus != ProjectStatus.InProgress &&
                projectDTO.ProjectStatus != ProjectStatus.Done)
            {
                string message = "Project status incorrect";
                _logger.LogWarning(message);
                return BadRequest(message);
            }

            var project = _mapper.Map<Project>(projectDTO);

            if (project.ProjectStatus == 0 || string.IsNullOrEmpty(project.Name))
            {
                string message = "Project status or project name is incorrect";
                _logger.LogWarning(message);
                return BadRequest(message);
            }

            _pojectLogic.Create(project);
            return Ok();
        }

        /// <summary>
        /// Delete project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
