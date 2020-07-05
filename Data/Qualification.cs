using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Qualification
    {
        public int QualificationId { get; set; }
        public string IdentityNo { get; set; }
        public DateTime QualificationYear { get; set; }
        public string QualificationDescription { get; set; }
        public string MajorSubjects { get; set; }
        public string CourseLevel { get; set; }
        public string LevelOfDegree { get; set; }
        public string LevelOfDiploma { get; set; }

        public virtual Marker IdentityNoNavigation { get; set; }
    }
}
