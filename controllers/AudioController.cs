using Loopr.audioDB;
using Loopr.repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


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
         * GET api/audio
         * 
         * Get all of the audio file entries in the database
         */
        [HttpGet]
        public IEnumerable<AudioFile> GetAllAudioFiles()
        {
            return _audioRepo.GetAll();
        }

        /**
         * GET api/audio/{id}
         * 
         * Get an audio file by the audio file entry id
         */
        [HttpGet("{id}")]
        public AudioFile GetAudioFile(int id)
        {
            return _audioRepo.Get(id);
        }

        /**
         * POST api/audio
         * 
         * Create a new audio file entry in the database
         */
        [HttpPost]
        public IActionResult PostAudioFile([FromBody] AudioFile audioFile)
        {
            _audioRepo.Save(audioFile);
            return CreatedAtAction(nameof(GetAudioFile), new { id = audioFile.Id }, audioFile);
        }

        // PUT api/audio/{}id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/audio/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _audioRepo.Delete(id);
            NoContent();
        }
    }
}
