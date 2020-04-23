using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Markers_GPS_Coordiantes.Models
{
    public class groups
    {
        public int scanGroupId { get; set; }
        public string deviceId { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
        public string idNumber { get; set; }
        public string licenceNumber { get; set; }
        public DateTime? timestamp { get; set; }
        public DateTime? departure { get; set; }
        public int scanCount { get; set; }
        public float hourCount { get; set; }
        public bool showWarning { get; set; }
        public bool hasBlacklist { get; set; }
        public DateTime? expiryDate { get; set; }
        public DateTime? sadlExpiryDate { get; set; }
        public string fieldValues { get; set; }
    }
}
