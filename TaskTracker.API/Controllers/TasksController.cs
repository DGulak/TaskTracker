using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.API.DTO;
using TaskTracker.BLL.Contracts;

namespace TaskTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly ITaskLogic _taskLogic;
        public TasksController(
            ILogger<TasksController> logger,
            IMapper mapper,
            ITaskLogic taskLogic)
        {
            _logger = logger;
            _mapper = mapper;
            _taskLogic = taskLogic;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetAll()
        {
            var tasks = _taskLogic.GetAll();
            return Ok(_mapper.Map<IEnumerable<Models.Task>>(tasks));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO>> GetById(int id)
        {
            var task = _taskLogic.GetById(id);

            if(task is null) 
            {
                _logger.LogWarning($"Task not found. id:{id}");
                return NotFound();
            }

            return Ok(_mapper.Map<Models.Task>(task));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, TaskDTO taskDTO)
        {
            if (taskDTO == null || id <= 0)
            {
                _logger.LogWarning($"Task was null or id < 0");
                return BadRequest();
            }

            taskDTO.Id = id;
            var post = _mapper.Map<Models.Task>(taskDTO);
            _taskLogic.Update(post);
            return Ok();
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Create(TaskDTO taskDTO)
        {
            if (taskDTO == null)
            {
                _logger.LogWarning($"Task was null");
                return BadRequest();
            }

            var task = _mapper.Map<Models.Task>(taskDTO);
            await _taskLogic.CreateAsync(task);
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

            _taskLogic.Delete(id);
            return Ok();
        }
    }
}
