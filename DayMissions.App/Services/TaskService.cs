using DayMissions.App.Dtos.DailyTrack;
using DayMissions.App.Dtos.Task;
using DayMissions.App.Interfaces;
using DayMissions.App.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.App.Services
{
    public class TaskService:ITaskService
    {private readonly ITaskReposatory repo;
          public  TaskService(ITaskReposatory taskReposatory)
        {
            repo=taskReposatory;  

        }
        public GetTask GetTask(int id)
        {
         var task=repo.GetTask(id);
           GetTask getTask= task.MapToGetTask();
            return getTask;
        }

        public GetTask AddTask(AddTask addtask)
        {
            var task = addtask.MapToTask();
            var add = repo.Add(task);
            var gettask = add.MapToGetTask();
            return gettask;
        }

        public GetTask UpdateActive(int id)
        {
            var task = repo.GetTask(id);
            if (task==null) return null;

            task.Active=!task.Active ; 
            repo.UpdateActive();
            var gettask = task.MapToGetTask();
            return gettask;

        }

        public GetTask UpdateTask(int id ,UpdateTask updatetask)
        {
            
            
            var task = repo.GetTask(id);
            if (task==null) return null;

            task.Name=updatetask.Name;
            task.Active= updatetask.Active;

            repo.Update();

            var mapto=task.MapToGetTask();

            return mapto ;
        }

        public void DeleteTask(int id)
        {
            repo.Delete(id);
        }
        public IEnumerable<GetTask> GetActive()
        {
            var tasks = repo.GetActive();
            var gettask = tasks.MapToGetActiveTasks();
            return gettask;
        }
    }
}
