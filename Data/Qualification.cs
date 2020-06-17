using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Qualification
    {
        public int QualificationId { get; set; }
        public int? IdentityNo { get; set; }
        public DateTime? Year { get; set; }
        public string QualificationDescription { get; set; }
        public string MojarSubjects { get; set; }
        public string CourseLevel { get; set; }
        public string LevelOfDegree { get; set; }
        public string LevelOfDiploma { get; set; }

        public virtual Marker IdentityNoNavigation { get; set; }
    }
}
