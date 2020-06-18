using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class PrescribedWorks
    {
        public PrescribedWorks()
        {
            ApplicationDetails = new HashSet<ApplicationDetails>();
        }

        public int PrescribedWorksId { get; set; }
        public int ApplicationId { get; set; }
        public string Drama { get; set; }
        public string Novel { get; set; }
        public string ShortStories { get; set; }
        public string Poetry { get; set; }

        public virtual ICollection<ApplicationDetails> ApplicationDetails { get; set; }
    }
}
