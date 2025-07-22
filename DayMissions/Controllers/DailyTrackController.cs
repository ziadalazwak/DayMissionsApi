using DayMissions.App.Dtos.DailyTrack;
using DayMissions.App.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DayMissions.api.Controllers
{
    [ApiController]
    [Route("api/DailyTrack")]
    public class DailyTrackController : ControllerBase
    {
        private readonly ITrackService _trackService;
        public DailyTrackController(ITrackService trackService)
        {
            _trackService = trackService;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] DateOnly? date = null)
        {
            var targetDate = date ?? DateOnly.FromDateTime(DateTime.Now);
            var tracks = _trackService.Get(targetDate);
            if (tracks==null) return NotFound();
            return Ok(tracks);


        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var track = _trackService.get(id);
            if (track==null) return NotFound();
            return Ok(track);
        }
        [HttpPost]
        public IActionResult Add(AddTrack Dailytrack) {
            //Tempratory because of swagger
            Dailytrack.IsFinished = false;
            Dailytrack.Date=DateOnly.FromDateTime(DateTime.Now);
            var track = _trackService.Add(Dailytrack);
            if (track==null) return BadRequest("could't add");
            return Ok(track);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateTrack DailyTrack) {

            var track = _trackService.Update(id, DailyTrack);
            if (track==null) return BadRequest("couldn't Update track");
            return Ok(track);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _trackService.Delete(id);
            return Ok();
        }
        [HttpPatch("{id}")]
        public IActionResult UpdateFinish(int id )
        {
            var track=_trackService.UpdateFinish(id);
            return Ok(track);
        }
    }
}
