using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.Domain.Entities
{
    public class DailyTrack
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; } 
        public int TaskDefinationId { get; set; }
        public bool IsFinished { get; set; } =false; // Default value is false
        public TaskDefination TaskDefination {  get; set; }

    }
}
