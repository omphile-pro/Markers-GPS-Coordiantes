using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class MarkerExam
    {
        public int MarkerExamId { get; set; }
        public Guid MarkerExamToken { get; set; }
        public int ExamId { get; set; }
        public int LastModifiedByUsersId { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int CreatedByUsersId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
