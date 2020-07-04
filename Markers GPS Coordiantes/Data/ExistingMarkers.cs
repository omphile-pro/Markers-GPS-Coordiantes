using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class ExistingMarkers
    {
        public string IdNumber { get; set; }
        public string CentreNumber { get; set; }
        public string FullName { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalCode { get; set; }
        public string PersalNumber { get; set; }
        public string WorkTelephone { get; set; }
        public string HomeTelephone { get; set; }
        public string Cellphone { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual Marker IdNumberNavigation { get; set; }
    }
}
