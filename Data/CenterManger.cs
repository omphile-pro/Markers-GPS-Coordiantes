using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class CenterManger
    {
        public int CenterManagerId { get; set; }
        public int UsersId { get; set; }
        public int CenterId { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Center Center { get; set; }
        public virtual Users Users { get; set; }
    }
}
