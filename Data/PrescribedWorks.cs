using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class PrescribedWorks
    {
        public int PrescribedWorksId { get; set; }
        public int ApplicationDetailsId { get; set; }
        public string Drama { get; set; }
        public string Novel { get; set; }
        public string ShortStories { get; set; }
        public string Poetry { get; set; }

        public virtual ApplicationDetails ApplicationDetails { get; set; }
    }
}
