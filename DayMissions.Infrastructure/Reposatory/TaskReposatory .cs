using DayMissions.App.Interfaces;
using DayMissions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.Infrastructure.Reposatory
{
    public class TaskReposatory : ITaskReposatory
    {
        private readonly DayMissionsDbcContext _context;
        public TaskReposatory(DayMissionsDbcContext context)
        {
            _context=context;
        }

        public TaskDefination Add(TaskDefination taskDefination)
        {
            if (taskDefination == null) return null;

            _context.Tasks.Add(taskDefination);
            _context.SaveChanges();
            return taskDefination;
        }
        public void UpdateActive()
        {
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null) _context.Remove(task);
            _context.SaveChanges();

        }

        public IEnumerable<TaskDefination> GetActive(string Id)
        {
            var tasks = _context.Tasks.Where(a => a.Active==true&&a.UserId==Id);
            return tasks;
        }
        public IEnumerable<TaskDefination> Get(string Id)
        {
            var tasks = _context.Tasks.Include(a => a.Tracks).Where(a=>a.UserId==Id);
            return tasks;
        }

        public TaskDefination GetTask(int id)
        {
            var task = _context.Tasks.Include(a => a.Tracks).FirstOrDefault(a => a.Id==id);

            if (task != null) return task;
            return null;
        }

        public void Update()
        {

            _context.SaveChanges();



        }
    }
}