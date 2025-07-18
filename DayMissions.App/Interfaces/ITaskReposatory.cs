using DayMissions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.App.Interfaces
{
    public interface ITaskReposatory
    {
        public IEnumerable<TaskDefination> Get();
        public TaskDefination GetTask(int id);
        public TaskDefination Add(TaskDefination taskDefination);
        public void Update( );
        public void Delete(int id);
        
    }
}
