using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<Users>();
            UsersRole = new HashSet<UsersRole>();
        }

        public int RoleId { get; set; }
        public string RoleDescription { get; set; }

        public virtual ICollection<Users> Users { get; set; }
        public virtual ICollection<UsersRole> UsersRole { get; set; }
    }
}
