using Loopr.audioDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loopr.repository
{
    public class AudioRepository : IRepository
    {
        private readonly AudioContext _context;

        public AudioRepository(AudioContext context)
        {
            _context = context;
        }

        /**
         * 
         * Saves an entity to the audio files database
         * 
         */
        public void Save(AudioFile audioFile)
        {
            _context.AudioFiles.Add(audioFile);
            _context.SaveChanges();
        }

        /**
         * 
         * Gets all audio files from the database
         * 
         */
        public List<AudioFile> GetAll()
        {
            return new List<AudioFile>();
        }

        /**
         * 
         * Gets an individual audio file from the database
         * 
         */
        public AudioFile Get(int id)
        {
            return new AudioFile();
        }
    }
}
