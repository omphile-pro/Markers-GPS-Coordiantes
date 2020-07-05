using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Resident
    {
        public int ResidentId { get; set; }
        public string IdentityNo { get; set; }
        public string ResidentialAddress { get; set; }
        public string FullResidentialAddress { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string PostalCode { get; set; }

        public virtual Marker IdentityNoNavigation { get; set; }
    }
}
