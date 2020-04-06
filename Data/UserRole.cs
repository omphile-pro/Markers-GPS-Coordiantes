using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class UserRole
    {
        public string Displayname { get; set; }
        public int RoleId { get; set; }
        public string PositionDescription { get; set; }
        public int PositionId { get; set; }
        public string RoleDescription { get; set; }
        public int UsersId { get; set; }
        public int UsersRoleId { get; set; }
    }
}
