using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class CenterManger
    {
        public int CenterManagerId { get; set; }

        [Column(TypeName = "int")]
        [DisplayName("Username")]
        public int UsersId { get; set; }
        [Column(TypeName = "int")]
        [DisplayName("Centre ame")]
        public int CenterId { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Center Center { get; set; }
        public virtual Users Users { get; set; }
    }
}
