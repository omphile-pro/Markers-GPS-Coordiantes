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
            CenterManger = new HashSet<CenterManger>();
            MarkersGpscoordinates = new HashSet<MarkersGpscoordinates>();
        }

        public int UsersId { get; set; }
        public int RoleId { get; set; }
        public int CenterId { get; set; }
        public Guid UsersToken { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Loginname Required")]
        [DisplayName("Login Name")]
        public string Loginname { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Password Required")]
        [DisplayName("Password")]
        public string Password { get; set; }
        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Password Required")]
        [DisplayName("Password")]

        public int GenderId { get; set; }

        [Column(TypeName = "int")]
        [Required(ErrorMessage = "Race Required")]
        [DisplayName("Race")]

        public int RaceId { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Firstname Required")]
        [DisplayName("Firstname ")]

        public string Firstname { get; set; }
        [Column(TypeName = "varchar(255)")]
        [Required(ErrorMessage = "Lastname Required")]
        [DisplayName("Last name")]
        public string Lastname { get; set; }

        

        public string SchoolName { get; set; }
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
        public virtual Role Role { get; set; }
        public virtual ICollection<CenterManger> CenterManger { get; set; }
        public virtual ICollection<MarkersGpscoordinates> MarkersGpscoordinates { get; set; }
    }
}
