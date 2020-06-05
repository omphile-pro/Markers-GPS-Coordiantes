using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
namespace Markers_GPS_Coordiantes.Data
{
    public partial class MarkersGpscoordinates
    {
        public int MarkersId { get; set; }
        [Column(TypeName = "int")]
        [DisplayName("Subject")]
        public int SubjectId { get; set; }
        [Column(TypeName = "int")]
        [DisplayName("Center")]

        public int CenterId { get; set; }
        [Column(TypeName = "int")]
        [DisplayName("User")]
        public int UsersId { get; set; }
        [Column(TypeName = "int")]
        [DisplayName("Race")]
        public int RaceId { get; set; }
        [Column(TypeName = "int")]
        [DisplayName("Paper Number")]
        public int ExamId { get; set; }
        [Column(TypeName = "int")]
        [DisplayName(" Gender")]
        public int GenderId { get; set; }
        [Column(TypeName = "int")]
        [DisplayName("Position")]
        public int PositionId { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [DisplayName("Centre Number")]
        [Required(ErrorMessage = "Centre Number Required")]
        public string CentreNumber { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName(" Marker Name")]
        [Required(ErrorMessage = "Marker FullName Required")]
        public string FullName { get; set; }
        [Column(TypeName = "nvarchar(255)")]
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
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Home Telephone")]
        [Required(ErrorMessage = "Home Telephone Number Required")]
        public string HomeTelephone { get; set; }

        [Column(TypeName = "varchar(255)")]
        [DisplayName("Cellphone No")]
        [Required(ErrorMessage = "Cellphone Number Required")]
        public string Cellphone { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUsersId { get; set; }

        public virtual Center Center { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Position Position { get; set; }
        public virtual Race Race { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Users Users { get; set; }
    }
}
