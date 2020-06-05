
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Users
    {
        public Users()
        {
            CenterManger = new HashSet<CenterManger>();
            MarkerCreatedByUsers = new HashSet<Marker>();
            MarkerDeletedByUsers = new HashSet<Marker>();
            MarkerLastModifiedByUsers = new HashSet<Marker>();
            MarkerUsers = new HashSet<Marker>();
            MarkersGpscoordinates = new HashSet<MarkersGpscoordinates>();
            UsersRoleCreatedByUsers = new HashSet<UsersRole>();
            UsersRoleUsers = new HashSet<UsersRole>();
        }

        public int UsersId { get; set; }
        [Column(TypeName = "int")]
        [DisplayName("User Role")]
        public int RoleId { get; set; }
        [Column(TypeName = "int")]
        [DisplayName("Center Name")]
        public int CenterId { get; set; }
        public Guid UsersToken { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Username")]
        [Required(ErrorMessage = "Username Required")]
        public string Loginname { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
        [Column(TypeName = "int")]
        [DisplayName("Gender")]
        public int GenderId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Email Address Required")]
        public string EmailAddress { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Mobile Number")]
        [Required(ErrorMessage = "Mobile Number Address Required")]
        public string MobileNo { get; set; }
        public string Telephone { get; set; }
        public string Displayname { get; set; }

        public string PostalAddress { get; set; }
        [Column(TypeName = "varchar(2000)")]
        [DisplayName("Physical Address")]

        public string PhysicalAddress { get; set; }
        public int? LastModifiedByUsersId { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int? CreatedByUsersId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Center Center { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<CenterManger> CenterManger { get; set; }
        public virtual ICollection<Marker> MarkerCreatedByUsers { get; set; }
        public virtual ICollection<Marker> MarkerDeletedByUsers { get; set; }
        public virtual ICollection<Marker> MarkerLastModifiedByUsers { get; set; }
        public virtual ICollection<Marker> MarkerUsers { get; set; }
        public virtual ICollection<MarkersGpscoordinates> MarkersGpscoordinates { get; set; }
        public virtual ICollection<UsersRole> UsersRoleCreatedByUsers { get; set; }
        public virtual ICollection<UsersRole> UsersRoleUsers { get; set; }
    }
}
