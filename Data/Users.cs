using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Users
    {
        public Users()
        {
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
        [Required(ErrorMessage = "Please Enter Centre Number")]
        [DisplayName("Center Name")]
        public int CenterId { get; set; }
        public Guid UsersToken { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Login Name Required")]
        [DisplayName("Login Name")]
        public string Loginname { get; set; }
        public string Password { get; set; }
        public int GenderId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

     
        public string EmailAddress { get; set; }
        public string MobileNo { get; set; }
        public string Telephone { get; set; }
        public string Displayname { get; set; }
        public string PostalAddress { get; set; }
        public string PhysicalAddress { get; set; }
        public int? LastModifiedByUsersId { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int? CreatedByUsersId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Center Center { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<Marker> MarkerCreatedByUsers { get; set; }
        public virtual ICollection<Marker> MarkerDeletedByUsers { get; set; }
        public virtual ICollection<Marker> MarkerLastModifiedByUsers { get; set; }
        public virtual ICollection<Marker> MarkerUsers { get; set; }
        public virtual ICollection<MarkersGpscoordinates> MarkersGpscoordinates { get; set; }
        public virtual ICollection<UsersRole> UsersRoleCreatedByUsers { get; set; }
        public virtual ICollection<UsersRole> UsersRoleUsers { get; set; }
    }
}
