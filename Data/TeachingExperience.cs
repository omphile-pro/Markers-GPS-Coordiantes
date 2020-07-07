using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class TeachingExperience
    {
        public int TeachingExperienceId { get; set; }
        public string IdentityNo { get; set; }
        public string TeachingExperience1 { get; set; }
        public string ExperienceInNcsCaps { get; set; }
        public string SubjectExperience { get; set; }
        public string Fetexperience { get; set; }
        public string Year { get; set; }
        public string Subject { get; set; }
        public string Language { get; set; }
        public string Grade { get; set; }
        public string NameOfSchooIorInstitution { get; set; }
        public string PercentageofLearners { get; set; }

        public virtual Marker IdentityNoNavigation { get; set; }
    }
}
