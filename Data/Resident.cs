using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Resident
    {
        public int ResidentId { get; set; }
        public int IdentityNo { get; set; }
        public string ResidentialAddress { get; set; }
        public string PostalCode { get; set; }

        public virtual Marker IdentityNoNavigation { get; set; }
    }
}
