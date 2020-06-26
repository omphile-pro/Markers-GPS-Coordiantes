using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class DeclerationByApplicant
    {
        public int DeclareationId { get; set; }
        public string IdentityNo { get; set; }
        public bool Declaration { get; set; }
        public DateTime YearAvg { get; set; }
        public string TaughtByAverage { get; set; }
        public DateTime DistrictYear { get; set; }
        public string CandidatesByDistrictPercentage { get; set; }
        public DateTime PercentageYear { get; set; }
        public string ProvincePercentage { get; set; }

        public virtual Marker IdentityNoNavigation { get; set; }
    }
}
