using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Vreport
    {
        public int CenterId { get; set; }
        public Guid UsersToken { get; set; }
        public string Loginname { get; set; }
        public int GenderId { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNo { get; set; }
        public string Telephone { get; set; }
        public string PostalAddress { get; set; }
        public string Displayname { get; set; }
        public string PhysicalAddress { get; set; }
        public DateTime CreateDate { get; set; }
        public string CenterName { get; set; }
        public string CenterNumber { get; set; }
        public string GenderDescription { get; set; }
        public int UsersId { get; set; }
        public int RoleId { get; set; }
        public int CreatedByUsersId { get; set; }
        public DateTime Expr1 { get; set; }
        public string RoleDescription { get; set; }
    }
}
