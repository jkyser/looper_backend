using System;
using System.Collections.Generic;

#nullable disable

namespace Loopr.audioDB
{
    public partial class Track
    {
        public int TrackId { get; set; }
        public int SessionId { get; set; }
        public string TrackName { get; set; }

        public virtual Session Session { get; set; }
    }
}
