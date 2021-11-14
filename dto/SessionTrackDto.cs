using Loopr.audioDB;
using System.Collections.Generic;

namespace Loopr.dto
{
    public class SessionTrackDto
    {
        public Session Session { get; set; }
        public List<Track> Tracks { get; set; }
    }
}
