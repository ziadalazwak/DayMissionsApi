using DayMissions.App.Dtos.Task;
using DayMissions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.App.Mapping
{
    public static class MapTask
    {
        public static TaskDefination MapToTask(this AddTask addtask)
        {
            TaskDefination task = new TaskDefination
            {
                Name=addtask.Name,
                 Active=addtask.Active,
                 
            };
            return task;

        }
        public static TaskDefination MapToTask(this UpdateTask addtask)
        {
            TaskDefination task = new TaskDefination
            {
                Name=addtask.Name,
                Active=addtask.Active,

            };
            return task;

        }
        public static TaskDefination MapToTask(this UpdateTask addtask,int id )
        {
            TaskDefination task = new TaskDefination
            {
                Id=id,
                Name=addtask.Name,
                Active=addtask.Active,

            };
            return task;

        }
        public static GetTask MapToGetTask(this TaskDefination tsk)
        {
            if (tsk==null) return null;
            GetTask task = new GetTask
            {
                Id=tsk.Id,
                Name=tsk.Name,
                Active=tsk.Active,
                Tracks=tsk.Tracks.MapToGetTracks()

            };
            return task;

        }

    }
}
