using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Position
    {
        public Position()
        {
            Marker = new HashSet<Marker>();
        }

        public int PositionId { get; set; }
        public string PositionDescription { get; set; }

        public virtual ICollection<Marker> Marker { get; set; }
    }
}
