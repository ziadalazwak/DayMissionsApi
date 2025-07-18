using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.App.Dtos.DailyTrack
{
    public class AddTrack
    {
      
      
        public int TaskDefinationId { get; set; }
        public bool IsFinished { get; set; } = false;
        public DateOnly Date {  get; set; }= DateOnly.FromDateTime(DateTime.Now);


    }
}
