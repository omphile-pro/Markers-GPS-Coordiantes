using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Exam
    {
        public Exam()
        {
            MarkerExam = new HashSet<MarkerExam>();
            MarkersGpscoordinates = new HashSet<MarkersGpscoordinates>();
        }

        public int ExamId { get; set; }
        public Guid ExamToken { get; set; }
        public int CenterId { get; set; }
        public int SubjectId { get; set; }
        public string PaperNumber { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedByUsersId { get; set; }
        public int LastModifiedByUsersId { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int CreatedByUsersId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Center Center { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<MarkerExam> MarkerExam { get; set; }
        public virtual ICollection<MarkersGpscoordinates> MarkersGpscoordinates { get; set; }
    }
}
