using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class VExam
    {
        public int ExamId { get; set; }
        public int CenterId { get; set; }
        public int SubjectId { get; set; }
        public Guid ExamToken { get; set; }
        public Guid? SubjectToken { get; set; }
        public Guid? CenterToken { get; set; }
        public string PaperNumber { get; set; }
        public string SubjectName { get; set; }
        public string CenterName { get; set; }
        public string CenterNumber { get; set; }
        public int? CityId { get; set; }
        public string CityDescription { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
