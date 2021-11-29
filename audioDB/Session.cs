using System;
using System.Collections.Generic;

#nullable disable

namespace Loopr.audioDB
{
    public partial class Session
    {
        public Session()
        {
            Tracks = new HashSet<Track>();
        }

        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public DateTime SessionDate { get; set; }
        public string SessionDescription { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
