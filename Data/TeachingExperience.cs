using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class TeachingExperience
    {
        public TeachingExperience()
        {
            SubjectTaught = new HashSet<SubjectTaught>();
        }

        public int TeachingExperienceId { get; set; }
        public string IdentityNo { get; set; }
        public string TeachingExperience1 { get; set; }
        public string ExperienceInNcsCaps { get; set; }
        public string SubjectExperience { get; set; }
        public string Fetexperience { get; set; }

        public virtual Marker IdentityNoNavigation { get; set; }
        public virtual ICollection<SubjectTaught> SubjectTaught { get; set; }
    }
}
