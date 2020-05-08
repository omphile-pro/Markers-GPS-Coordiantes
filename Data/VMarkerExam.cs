using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class VMarkerExam
    {
        public int MarkerExamId { get; set; }
        public Guid MarkerExamToken { get; set; }
        public int ExamId { get; set; }
        public int MarkerId { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid? ExamToken { get; set; }
        public int? CenterId { get; set; }
        public string CenterName { get; set; }
        public Guid? CenterToken { get; set; }
        public string CenterNumber { get; set; }
   
        public decimal? CenterLongitude { get; set; }
        public decimal? CenterLatitude { get; set; }
        public int? CityId { get; set; }
        public string CityDescription { get; set; }
        public Guid MarkerToken { get; set; }
        public int UsersId { get; set; }
        public int PositionId { get; set; }
        public string PositionDescription { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNo { get; set; }
        public string Telephone { get; set; }
        public string Displayname { get; set; }
        public decimal? MarkerLatitude { get; set; }
        public decimal? MarkerLongitude { get; set; }
        public double? Distance { get; set; }
    }
}
