using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.App.Dtos.DailyTrack
{
    public class UpdateTrack
    {
        public DateOnly Date { get; set; }
        public int TaskDefinationId { get; set; }
        public bool IsFinished { get; set; }

    }
}
