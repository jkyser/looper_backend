using Loopr.audioDB;
using Loopr.dto;
using System.Collections.Generic;

namespace Loopr.repository
{
    public interface IRepository
    {
        public void Save(Session session, List<Track> tracks);
        public Session Get(int id);
        public List<Session> GetAll();
    }
}
