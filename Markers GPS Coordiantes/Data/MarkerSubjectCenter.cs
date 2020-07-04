using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class MarkerSubjectCenter
    {
        public int MarkerSubjectCenterId { get; set; }
        public Guid MarkerSubjectCenterToken { get; set; }
        public int SubjectId { get; set; }
        public int CenterId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
