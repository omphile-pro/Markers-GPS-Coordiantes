using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class VMarkersGpscoordinates
    {
        public int MarkersId { get; set; }
        public int SubjectId { get; set; }
        public int CenterId { get; set; }
        public int UsersId { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName(" Marker Name")]
        [Required(ErrorMessage = "Marker FullName Required")]
        public string FullName { get; set; }
        [DisplayName(" identity number")]
        [Required(ErrorMessage = " identity number Required")]
        public string IdNumber { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Physical Address")]
        [Required(ErrorMessage = "Physical Address Required")]
        public string PhysicalAddress { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Postal Code")]
        [Required(ErrorMessage = "Postal Address Required")]
        public string PostalCode { get; set; }

        [Column(TypeName = "varchar(255)")]
        [DisplayName("Persal Number")]
        [Required(ErrorMessage = "Persal Number Required")]
        public string PersalNumber { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Work Telephone")]
        [Required(ErrorMessage = "Work Telephone Number Required")]
        public string WorkTelephone { get; set; }
        public string Cellphone { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Home Telephone")]
        [Required(ErrorMessage = "Home Telephone Number Required")]
        public string HomeTelephone { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Centre Name ")]
        [Required(ErrorMessage = "Centre Name Required")]
        public string CenterName { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Center Number ")]
        [Required(ErrorMessage = "Center Number Required")]
        public string CenterNumber { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [DisplayName("Center Number ")]
        [Required(ErrorMessage = "Center Number Required")]
        public decimal? CenterLongitude { get; set; }
        public decimal? CenterLatitude { get; set; }
        public string Distance { get; set; }
        public string CentreNumber { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Paper Number")]
        public string PaperNumber { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Subject Name")]
        public string SubjectName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string GenderDescription { get; set; }
        public string PayOut { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Position")]
        public string PositionDescription { get; set; }
    }
    public class viewModel
    {
        public string FullName { get; set; }
        public string IdNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string CenterName { get; set; }
        public string CenterNumber { get; set; }
        public string Distance { get; set; }
        public string CentreNumber { get; set; }
        public string PaperNumber { get; set; }
        public string SubjectName { get; set; }
        public string PayOut { get; set; }
        public string PositionDescription { get; set; }
        public string licenceNumber { get; set; }
    }
}