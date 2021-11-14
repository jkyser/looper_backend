using Loopr.audioDB;
using Loopr.dto;
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
        public SessionTrackDto Get(int id)
        {
            SessionTrackDto sessionTrackDto = new SessionTrackDto();

            // get session
            Session session = _context.Sessions.Where(s => s.SessionId == id).FirstOrDefault();
            sessionTrackDto.Session = session;

            // get list of tracks for the session
            List<Track> tracks = _context.Tracks.Where(t => t.SessionId == id).ToList();
            sessionTrackDto.Tracks = tracks;

            return sessionTrackDto;
        }
    }
}
