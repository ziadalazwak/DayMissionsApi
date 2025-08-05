using DayMissions.App.Dtos.DailyTrack;
using DayMissions.App.Interfaces;
using DayMissions.App.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.App.Services
{
    public class TrackService:ITrackService
    {
        private readonly IDailyTrackerReposatory repo;
       public TrackService(IDailyTrackerReposatory reposatory)
        {
            repo=reposatory;    
        }

        public GetTrack Add(AddTrack addTrack)
        {

            var track = addTrack.MapToTrack();
            var addtrack=repo.Add(track);
            var GetTrack=addtrack.MapToGetTrack();
            return GetTrack;
        }
        public GetTrack UpdateFinish(int id )
        {
            var track=repo.UpdateFinish(id);
            if (track==null) return null;
            
    
            var gettrack=track.MapToGetTrack();
            return gettrack;

        }

        public void Delete(int id )
        {
            repo.Delete(id);
        }

        public GetTrack get(int id )
        {
            var track = repo.Get(id);
            var gettrack = track.MapToGetTrack();
            return gettrack;
        }

        public IEnumerable<GetTrack> Get(DateOnly date,string UserId)
        {
             
            var tracks = repo.Get(UserId).Where(a=>a.Date==date);
            var gettracks = tracks.MapToGetTracks();
            return gettracks;
        }

        public GetTrack Update(int id, UpdateTrack updateTrack)
        {
            var track = repo.Get(id);
            if (track==null) return null;

            track.Date=updateTrack.Date;
            track.IsFinished=updateTrack.IsFinished;
            track.TaskDefinationId=updateTrack.TaskDefinationId;

       repo.Update();

            var gettrack = track.MapToGetTrack();
            return gettrack;
        }
    }
}
