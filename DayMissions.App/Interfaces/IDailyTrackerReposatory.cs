using DayMissions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.App.Interfaces
{
    public interface IDailyTrackerReposatory
    {
        public IQueryable<DailyTrack> Get();
        public void UpdateFinish();
        public DailyTrack Get(int id);
        public DailyTrack Add(DailyTrack track);
        public void Update();
        public void Delete(int id);
    }
}
