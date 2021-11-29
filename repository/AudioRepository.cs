using Loopr.audioDB;
using Loopr.dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
         * Saves a session and its associated tracks
         * 
         */
        public void Save(Session session, List<Track> tracks)
        {
            // add session to context
            session.Tracks = tracks;
            _context.Sessions.Add(session);
            _context.SaveChanges();
        }

        /**
         * 
         * Gets a session and the associated tracks from the database
         * 
         */
        public Session Get(int id)
        {
            return _context.Sessions.Where(s => s.SessionId == id).Include(s => s.Tracks).FirstOrDefault();
        }

        /**
         * 
         * Returns all sessions in the database
         * 
         */
        public List<Session> GetAll()
        {
            return _context.Sessions.ToList();
        }
    }
}
