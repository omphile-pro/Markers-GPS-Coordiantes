using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class VMarkerSubjectCenter
    {
        public int MarkerSubjectCenterId { get; set; }
        public Guid MarkerSubjectCenterToken { get; set; }
        public int MarkerId { get; set; }
        public int SubjectId { get; set; }
        public int CenterId { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid? CenterToken { get; set; }
        public string CenterName { get; set; }
        public string CenterNumber { get; set; }
      
        public decimal? CenterLatitude { get; set; }
        public decimal? CenterLongitude { get; set; }
        public Guid? MarkerToken { get; set; }
        public int? UsersId { get; set; }
        public Guid? SubjectToken { get; set; }
        public string SubjectName { get; set; }
        public int? PositionId { get; set; }
        public string PositionDescription { get; set; }
        public Guid? UsersToken { get; set; }
        public string Loginname { get; set; }
        public string Password { get; set; }
        public int? GenderId { get; set; }
        public int? RaceId { get; set; }
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
        public decimal? MarkerLatitude { get; set; }
        public decimal? MarkerLongitude { get; set; }
    }
}
