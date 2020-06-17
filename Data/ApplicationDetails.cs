using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class ApplicationDetails
    {
        public int ApplicationDetailsId { get; set; }
        public int ApplicationId { get; set; }
        public string Subject { get; set; }
        public string Language { get; set; }
        public string Paper { get; set; }

        public virtual Application Application { get; set; }
        public virtual PrescribedWorks ApplicationNavigation { get; set; }
    }
}
