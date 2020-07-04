using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Child
    {
        public int Parentid { get; set; }
        public int RelatedIds { get; set; }

        public virtual Parent Parent { get; set; }
    }
}
