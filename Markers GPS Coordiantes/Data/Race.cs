using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Race
    {
        public Race()
        {
            MarkersGpscoordinates = new HashSet<MarkersGpscoordinates>();
        }

        public string RaceId { get; set; }
        public string RaceDescription { get; set; }

        public virtual ICollection<MarkersGpscoordinates> MarkersGpscoordinates { get; set; }
    }
}
