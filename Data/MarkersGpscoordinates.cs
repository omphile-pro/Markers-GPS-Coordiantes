using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class MarkersGpscoordinates
    {
        public int MarkersId { get; set; }
        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Please Select Subject Name")]
        [DisplayName("Subject Name")]
        public int SubjectId { get; set; }
        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Please Select Center Name")]
        [DisplayName("Center Name")]
        public int CenterId { get; set; }


        public int UsersId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required(ErrorMessage = "Center Number Required")]
        [DisplayName("Center Number")]
        public string CentreNumber { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required(ErrorMessage = "Please select center name")]
        [DisplayName("Center Name")]
        public string CentreName { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Enter Marker Full Name")]
        [DisplayName("Marker Full Name")]
        public string FullName { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Please select Gender")]
        [DisplayName("Gender")]
        public string Gender { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Race Required")]
        [DisplayName("Race")]
        public string Race { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [Required(ErrorMessage = "Identity Number Required")]
        [DisplayName("Identity Number")]
        public string IdNumber { get; set; }
        public string Subject { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Please select paper number")]
        [DisplayName("Paper Number")]
        public string Paper { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Please select marker position role")]
        [DisplayName("Position")]
        public string Position { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Physical Address required")]
        [DisplayName("Physical Address")]
        public string PhysicalAddress { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Postal Code required")]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Persal Number required")]
        [DisplayName("Persal Number")]
        public string PersalNumber { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Work Telephone required")]
        [DisplayName("Work Telephone")]
        public string WorkTelephone { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Home Telephone Number required")]
        [DisplayName("Home Telephone")]
        public string HomeTelephone { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Mobile Number required")]
        [DisplayName("Mobile Number")]
        public string Cellphone { get; set; }

        [Column(TypeName = "decimal(18,12)")]
        [Required(ErrorMessage = "Enter Correct Latitude Number")]
        [DisplayName("Latitude")]
        public decimal? Latitude { get; set; }

        [Column(TypeName = "decimal(18,12)")]
        [Required(ErrorMessage = "Enter Correct Latitude Number")]
        [DisplayName("Longitude")]
        public decimal? Longitude { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUsersId { get; set; }

        public virtual Center Center { get; set; }
        public virtual Subject SubjectNavigation { get; set; }
        public virtual Users Users { get; set; }
    }
}
