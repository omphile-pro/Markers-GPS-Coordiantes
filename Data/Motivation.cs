using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Motivation
    {
        public int MotivationId { get; set; }
        public string IdentityNo { get; set; }
        public string MotivationDescription { get; set; }

        public virtual Marker IdentityNoNavigation { get; set; }
    }
}
