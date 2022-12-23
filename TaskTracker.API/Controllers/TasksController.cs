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

        /// <summary>
        /// Returns all tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutTaskDTO>>> GetAll()
        {
            var tasks = _taskLogic.GetAll();
            return Ok(_mapper.Map<IEnumerable<Infrastructures.Entities.Task>>(tasks));
        }

        /// <summary>
        /// Returns task by given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<OutTaskDTO>> GetById(int id)
        {
            var task = _taskLogic.GetById(id);

            if (task is null)
            {
                _logger.LogWarning($"Task not found. id:{id}");
                return NotFound();
            }

            return Ok(_mapper.Map<Infrastructures.Entities.Task>(task));
        }

        /// <summary>
        /// Update task by given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="taskDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, InTaskDTO taskDTO)
        {
            if (taskDTO == null || id <= 0)
            {
                _logger.LogWarning($"Task was null or id < 0");
                return BadRequest();
            }

            var update = _mapper.Map<Infrastructures.Entities.Task>(taskDTO);
            update.Id = id;
            _taskLogic.Update(update);
            return Ok();
        }

        /// <summary>
        /// Create a new task
        /// </summary>
        /// <param name="taskDTO"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult> Create(InTaskDTO taskDTO)
        {
            if (taskDTO == null)
            {
                _logger.LogWarning($"Task was null");
                return BadRequest();
            }

            var task = _mapper.Map<Infrastructures.Entities.Task>(taskDTO);
            _taskLogic.Create(task);
            return Ok();
        }

        /// <summary>
        /// Delete a task by given id
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

            _taskLogic.Delete(id);
            return Ok();
        }
    }
}
