using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Markers_GPS_Coordiantes.Models
{
    public class Markers
    {
        [Key]
        public int Markerid { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Please Enter Centre Number")]
        [DisplayName("Centre Number")]
        public string Centre_No { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Centre Name")]
        [Required(ErrorMessage = "Centre Name Required")]
        public string Centre_Name { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Marker Full Name")]
        [Required(ErrorMessage = "Marker Full Names Required")]
        public string Fullname { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "Marker Gender Required")]
        [DisplayName("Gender")]
        public string Gender { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Race")]
        [Required(ErrorMessage = "Select Marker Race")]
        public string Race { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("ID Number")]
        [Required(ErrorMessage = "ID Number Required")]
        public string ID_Number { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Subject Name")]
        [Required(ErrorMessage = "Enter Subject Name")]
        public string Subject { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Paper No")]
        [Required(ErrorMessage = "Paper Number Required")]
        public string Paper_No { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Makers Position")]
        [Required(ErrorMessage = "Position Name Required")]
        public string Position { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Address")]
        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Postal Code")]
        [Required(ErrorMessage = "Postal Code Required")]
        public string Postal_Code { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Mobile No")]
        [Required(ErrorMessage = "Mobile Number Rquired")]
        public string Mobile_No { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Work Telephone Number")]
        [Required(ErrorMessage = "Work Telephone Number Required")]
        public string Work_Tel { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Latitude")]
        [Required(ErrorMessage = "Longtude Required")]
        public string Latitude { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Longitude")]
        [Required(ErrorMessage = "Latitude Required")]
        public string Longitude { get; set; }
       

    }
}
