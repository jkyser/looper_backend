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
         * Gets all audio file entries from the database
         * 
         */
        public List<AudioFile> GetAll()
        {
            return _context.AudioFiles.ToList();
        }

        /**
         * 
         * Gets an individual audio file entry from the database
         * 
         */
        public AudioFile Get(int id)
        {
            return _context.AudioFiles.Single(f => f.Id == id);
        }

        /**
         * 
         * Deletes an individual audio file entry from the databse
         * 
         */
        public void Delete(int id)
        {
            AudioFile toDelete = _context.AudioFiles.Single(f => f.Id == id);
            _context.Remove(toDelete);
            _context.SaveChanges();
        }
    }
}
