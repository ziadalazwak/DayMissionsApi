using DayMissions.App.Dtos.DailyTrack;
using DayMissions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.App.Dtos.Task
{
    public class GetTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int CurrentStreak { get; set; }
        public int LongestStreak { get; set; }
        public IEnumerable<GetTrack> Tracks { get; set; }
    }
}
