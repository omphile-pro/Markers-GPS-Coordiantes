using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Users
    {
        public Users()
        {
            CenterManger = new HashSet<CenterManger>();
            MarkersGpscoordinates = new HashSet<MarkersGpscoordinates>();
            UsersRoleCreatedByUsers = new HashSet<UsersRole>();
            UsersRoleUsers = new HashSet<UsersRole>();
        }

        public int UsersId { get; set; }
        public int RoleId { get; set; }
        public int CenterId { get; set; }
        public Guid UsersToken { get; set; }
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
        public virtual Role Role { get; set; }
        public virtual ICollection<CenterManger> CenterManger { get; set; }
        public virtual ICollection<MarkersGpscoordinates> MarkersGpscoordinates { get; set; }
        public virtual ICollection<UsersRole> UsersRoleCreatedByUsers { get; set; }
        public virtual ICollection<UsersRole> UsersRoleUsers { get; set; }
    }
}
