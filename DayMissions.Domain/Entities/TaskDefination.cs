﻿
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
        public string UserId { get; set; }
        public int CurrentStreak { get; set; }
        public int LongestStreak { get; set; }
        public DateOnly? LastCompletedDate { get; set; }
        public ICollection<DailyTrack> Tracks { get; set; }
        public ApplicationUser User { get; set; }

    }
}
