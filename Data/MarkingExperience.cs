using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class MarkingExperience
    {
        public int MarkingExperienceid { get; set; }
        public string IdentityNo { get; set; }
        public string MarkingExperience2019 { get; set; }
        public string MarkingExperience2018 { get; set; }
        public string MarkingExperience2017 { get; set; }
        public string MarkingExperience2016 { get; set; }
        public string MarkingExperience2015 { get; set; }
        public string MarkingExperience2014 { get; set; }
        public string SubjectOne { get; set; }
        public string SubjectTwo { get; set; }
        public string SubjectThree { get; set; }
        public string SubjectFour { get; set; }
        public string SubjectFive { get; set; }
        public string SubjectSix { get; set; }
        public string PositionHeldOne { get; set; }
        public string PositionHeldTwo { get; set; }
        public string PositionHeldThree { get; set; }
        public string PositionHeldFour { get; set; }
        public string PositionHeldFive { get; set; }
        public string PositionHeldSive { get; set; }

        public virtual Marker IdentityNoNavigation { get; set; }
    }
}
