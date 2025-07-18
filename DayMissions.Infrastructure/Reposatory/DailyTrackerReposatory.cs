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
    public class DailyTrackerReposatory : IDailyTrackerReposatory
    {
        private readonly DayMissionsDbcContext _context;

       public DailyTrackerReposatory(DayMissionsDbcContext context)
        {
            _context=context;
        }
        public DailyTrack Add(DailyTrack track)
        {
            if (track == null) return null;
            _context.Tracks.Add(track
                );
            _context.SaveChanges();
            return track;
                  
        }

        public void Delete(int id)
        {
            var track = Get(id);
            if (track == null) return ;
            _context.Tracks.Remove(track);
            _context.SaveChanges();
            
        }
        public void UpdateFinish()
        {
            _context.SaveChanges();
        }
        public IQueryable<DailyTrack> Get()
        {
            var tracks = _context.Tracks.Include(a => a.TaskDefination).AsQueryable();
            return tracks;
        }

        public DailyTrack Get(int id)
        {
            var track =_context.Tracks.Include(a=>a.TaskDefination).FirstOrDefault(a=>a.Id==id);
            if (track==null) return null;

            return track;
        }

        public void Update()
        {
            _context.SaveChanges();
        }
    }
}
