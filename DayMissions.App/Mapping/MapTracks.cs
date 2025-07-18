using DayMissions.App.Dtos.DailyTrack;
using DayMissions.App.Dtos.Task;
using DayMissions.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayMissions.App.Mapping
{
    public static class MapTracks
    {
        
            public static DailyTrack MapToTrack(this AddTrack addTrack)
            {
                DailyTrack track = new DailyTrack
                {
                    Date=addTrack.Date,
                  
                    IsFinished=addTrack.IsFinished,
                    TaskDefinationId=addTrack.TaskDefinationId

                };
                return track;

            }
            public static DailyTrack MapToTrack(this UpdateTrack addTrack)
            {
                DailyTrack track = new DailyTrack
                {
                    Date=addTrack.Date,
                    IsFinished=addTrack.IsFinished,
                    TaskDefinationId=addTrack.TaskDefinationId

                };
                return track;

            }
            public static GetTrack MapToGetTrack(this DailyTrack trk)
            {
                GetTrack track = new GetTrack
                {
                    Date=trk.Date,
                    IsFinished=trk.IsFinished,
                    Id=trk.Id,
                    TaskDefinationId=trk.TaskDefinationId,
                    //TaskName=trk.TaskDefination.Name
                };

                return track;

            }
            public static IEnumerable<GetTrack> MapToGetTracks(this IEnumerable<DailyTrack> trk)
            {
            if (trk == null) return null;
            var tracks = trk.Select(a => new GetTrack
            {
                Date=a.Date,
                IsFinished=a.IsFinished,
                TaskDefinationId=a.TaskDefinationId,
                Id=a.Id,
                TaskName=a.TaskDefination.Name

            });
                return tracks;

            }


        }
    }

