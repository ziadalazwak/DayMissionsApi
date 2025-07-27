using DayMissions.App.Dtos.Task;
using DayMissions.App.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DayMissions.api.Controllers
{
    
    
    [ApiController]
   
    [Route("api/[controller]")]
    [Authorize]


    public class TaskController : ControllerBase
    {

        private readonly ITaskService taskService;
    
        public TaskController(ITaskService taskService)
        {
            this.taskService=taskService;
         
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetActveTasks() {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var tasks = taskService.GetActive(userId);
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

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var addtask = taskService.AddTask(task, userId);
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
