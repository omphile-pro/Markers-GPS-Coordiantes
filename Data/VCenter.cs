using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class VCenter
    {
        public int CenterId { get; set; }
        public Guid CenterToken { get; set; }
        public string CenterName { get; set; }
        public string CenterNumber { get; set; }

        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int LastModifiedByUsersId { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int CreatedByUsersId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
