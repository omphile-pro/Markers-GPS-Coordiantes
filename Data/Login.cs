using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Login
    {
        public int UsersId { get; set; }
        public string Loginname { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string MobileNo { get; set; }
        public string Displayname { get; set; }
        public DateTime CreateDate { get; set; }
        public int? CreatedByUsersId { get; set; }
        public string EmailAddress { get; set; }
    }
}
