using Loopr.dto;
using Loopr.repository;
using Microsoft.AspNetCore.Mvc;


namespace Loopr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioController : ControllerBase
    {
        private readonly IRepository _audioRepo;

        public AudioController(IRepository audioRepo)
        {
            _audioRepo = audioRepo;
        }

        /**
         * GET api/audio/{id}
         * 
         * Gets all the associated audio files with the requested session
         */
        [HttpGet("{id}")]
        public SessionTrackDto GetSession(int id)
        {
            return _audioRepo.Get(id);
        }

        /**
         * POST api/audio
         * 
         * Create a new audio file entry in the database
         */
        [HttpPost]
        public IActionResult SaveSession([FromBody] SessionTrackDto sessionTrackDto)
        {
            _audioRepo.Save(sessionTrackDto.Session, sessionTrackDto.Tracks);
            return CreatedAtAction(nameof(GetSession), new { id = sessionTrackDto.Session.SessionId }, sessionTrackDto);
        }

        // PUT api/audio/{}id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
