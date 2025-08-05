using DayMissions.App.Dtos.DailyTrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.App.Interfaces
{
    public interface ITrackService
    {
        public GetTrack Add(AddTrack addTrack);
        public GetTrack Update(int id , UpdateTrack updateTrack);
        public void Delete(int id );
        public GetTrack UpdateFinish(int id);
        public GetTrack get(int id);

        public IEnumerable<GetTrack> Get(DateOnly date,string UserId);
    }

}
