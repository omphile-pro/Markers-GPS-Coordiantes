using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class DeclerationByApplicant
    {
        public int DeclareationId { get; set; }
        public string IdentityNo { get; set; }
        public bool Declaration { get; set; }
        public DateTime Year { get; set; }
        public string TaughtByAverage { get; set; }
        public DateTime AveragebyYear { get; set; }
        public string CandidatesByDescriptionPercentage { get; set; }
        public DateTime PercentageYear { get; set; }
        public string ProvincePercentage { get; set; }

        public virtual Marker IdentityNoNavigation { get; set; }
    }
}
