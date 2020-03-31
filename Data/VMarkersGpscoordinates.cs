using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class VMarkersGpscoordinates
    {
        public int MarkersId { get; set; }
        public int SubjectId { get; set; }
        public int CenterId { get; set; }
        public int UsersId { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Marker Full Name")]
        public string FullName { get; set; }

       
        public string IdNumber { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Physical Address")]
        public string PhysicalAddress { get; set; }
        public string PostalCode { get; set; }
        public string PersalNumber { get; set; }
        public string WorkTelephone { get; set; }
        public string Cellphone { get; set; }
        public string HomeTelephone { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [DisplayName("Center Name ")]
        public string CenterName { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [DisplayName("Center Number ")]
        public string CenterNumber { get; set; }
        public decimal? CenterLongitude { get; set; }
        public decimal? CenterLatitude { get; set; }

        public string Distance { get; set; }
        
        public string CentreNumber { get; set; }
        public int PositionId { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Position Description")]
        public string PositionDescription { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Paper Number")]
        public string PaperNumber { get; set; }

        [Column(TypeName = "varchar(255)")]
        [DisplayName("Subject Name")]
        public string SubjectName { get; set; }
    }
}
