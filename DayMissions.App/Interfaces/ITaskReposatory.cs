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
        public IEnumerable<TaskDefination> Get(string Id);
        public TaskDefination GetTask(int id);
        public IEnumerable<TaskDefination> GetActive(string Id);
        public TaskDefination Add(TaskDefination taskDefination);
        public void UpdateActive( );    
        public void Update( );
        public void Delete(int id);
        
    }
}
