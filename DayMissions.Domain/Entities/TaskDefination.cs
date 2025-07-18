using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.Domain.Entities
{
    public class TaskDefination
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public bool Active { get; set; } 
        public ICollection<DailyTrack> Tracks { get; set; }

    }
}
