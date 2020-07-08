using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class DeclerationByApplicant
    {
        public int DeclareationId { get; set; }
        public string IdentityNo { get; set; }
        public string Declaration { get; set; }
        public string YearAvg { get; set; }
        public string TaughtByAverage { get; set; }
        public string DistrictYear { get; set; }
        public string CandidatesByDistrictPercentage { get; set; }
        public string PercentageYear { get; set; }
        public string ProvincePercentage { get; set; }

        public virtual Marker IdentityNoNavigation { get; set; }
    }
}
