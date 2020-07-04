using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class VUsers
    {
        public int UsersId { get; set; }
        public Guid UsersToken { get; set; }
        public string Loginname { get; set; }
        public string Password { get; set; }
        public int GenderId { get; set; }
        public int RaceId { get; set; }
        public string GenderDescription { get; set; }
        public string RaceDescription { get; set; }
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
        public DateTime CreateDate { get; set; }
        public string SchoolName { get; set; }
    }
}
