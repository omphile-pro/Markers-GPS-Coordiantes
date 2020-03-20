using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class UsersRole
    {
        public int UsersRoleId { get; set; }
        public int UsersId { get; set; }
        public int RoleId { get; set; }
        public int CreatedByUsersId { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Users CreatedByUsers { get; set; }
        public virtual Role Role { get; set; }
        public virtual Users Users { get; set; }
    }
}
