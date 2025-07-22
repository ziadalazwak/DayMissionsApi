using DayMissions.App.Dtos.Task;
using DayMissions.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DayMissions.api.Controllers
{
    [ApiController]
    [Route("api/Task")]
    public class TaskController : ControllerBase
    {

        private readonly ITaskService taskService;
        public TaskController(ITaskService taskService)
        {
            this.taskService=taskService;
        }
        [HttpGet]
        public IActionResult GetActveTasks() {
            var tasks = taskService.GetActive();
            return Ok(tasks);
        }
        [HttpPatch("{id}")]
        public IActionResult UpdateActive(int id) { 
            var task =taskService.UpdateActive(id);
            return Ok(task);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var tasks = taskService.GetTask(id);
            if (tasks == null) { return NotFound(); }
            return Ok(tasks);
        }
        [HttpPost]
        public IActionResult Add(AddTask task) {
            var addtask = taskService.AddTask(task);
            if (addtask==null)
                return BadRequest("could't add");
            return Ok(addtask);
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute]int id ,UpdateTask task) { 
        var updatetask=taskService.UpdateTask(id,task);
            if (updatetask==null) return BadRequest("could't update ");
            return Ok(updatetask);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id )
        {
            taskService.DeleteTask(id);
            return Ok();
        }

    }
}
