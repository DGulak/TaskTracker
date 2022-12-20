using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.API.DTO;
using TaskTracker.BLL;
using TaskTracker.BLL.Contracts;

namespace TaskTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IProjectLogic _pojectLogic;
        public ProjectsController(
            ILogger<ProjectsController> logger,
            IMapper mapper,
            IProjectLogic projectLogic)
        {
            _logger = logger;
            _mapper = mapper;
            _pojectLogic = projectLogic;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetAll()
        {
            var projects = _pojectLogic.GetAll();
            return Ok(_mapper.Map<IEnumerable<Models.Project>>(projects));
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

            return Ok(_mapper.Map<Models.Project>(project));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] int id, ProjectDTO projectDTO)
        {
            if (projectDTO == null || id <= 0)
            {
                _logger.LogWarning($"Project was null or id < 0");
                return BadRequest();
            }

            projectDTO.Id = id;
            var post = _mapper.Map<Models.Project>(projectDTO);
            _pojectLogic.Update(post);
            return Ok();
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(ProjectDTO projectDTO)
        {
            if (projectDTO == null)
            {
                _logger.LogWarning($"Project was null");
                return BadRequest();
            }

            var project = _mapper.Map<Models.Project>(projectDTO);
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
