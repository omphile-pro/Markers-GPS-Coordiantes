using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Application
    {
        public Application()
        {
            ApplicationDetails = new HashSet<ApplicationDetails>();
        }

        public int AppliactionId { get; set; }
        public string IdentityNo { get; set; }
        public string Subject { get; set; }
        public string Language { get; set; }
        public string Paper { get; set; }
        public string Position { get; set; }
        public string CurrentPosition { get; set; }
        public string PracticalSubject { get; set; }
        public string PracticalExamination { get; set; }
        public string PrescribedBook { get; set; }

        public virtual Marker IdentityNoNavigation { get; set; }
        public virtual ICollection<ApplicationDetails> ApplicationDetails { get; set; }
    }
}
