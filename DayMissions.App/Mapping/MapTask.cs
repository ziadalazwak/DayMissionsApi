using DayMissions.App.Dtos.Task;
using DayMissions.Domain.Entities;
using System;
using System.Collections;
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
                ,
                CurrentStreak=tsk.CurrentStreak,
                LongestStreak=tsk.LongestStreak,


            };
            return task;

        }
        public static  IEnumerable< GetTask> MapToGetActiveTasks(this IEnumerable<TaskDefination> tsk)
        {
            if (tsk==null) return null;
            IEnumerable< GetTask >task = tsk.Select(a=>
                new GetTask
            {
                Id=a.Id,
                Name=a.Name,
                Active=a.Active,
                CurrentStreak=a.CurrentStreak,
                    LongestStreak=a.LongestStreak,


                });
            return task;

        }

    }
}
