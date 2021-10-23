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

        // GET: api/audio
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/audio/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/audio
        [HttpPost]
        public void PostAudioFile([FromBody] AudioFile audioFile)
        {
            _audioRepo.Save(audioFile);
            //return CreatedAtAction();
        }

        // PUT api/audio/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/audio/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
