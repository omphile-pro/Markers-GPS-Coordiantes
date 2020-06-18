using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Position
    {
        public Position()
        {
            MarkersGpscoordinates = new HashSet<MarkersGpscoordinates>();
        }

        public int PositionId { get; set; }
        public string PositionDescription { get; set; }

        public virtual ICollection<MarkersGpscoordinates> MarkersGpscoordinates { get; set; }
    }
}
