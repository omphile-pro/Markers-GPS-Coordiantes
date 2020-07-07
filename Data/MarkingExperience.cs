using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class MarkingExperience
    {
        public int MarkingExperienceid { get; set; }
        public string IdentityNo { get; set; }
        public string MarkingExperienceYear { get; set; }
        public string Subject { get; set; }
        public string PositionHeld { get; set; }

        public virtual Marker IdentityNoNavigation { get; set; }
    }
}
