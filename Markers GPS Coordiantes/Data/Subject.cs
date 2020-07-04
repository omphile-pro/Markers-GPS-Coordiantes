using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Subject
    {
        public Subject()
        {
            Exam = new HashSet<Exam>();
            MarkersGpscoordinates = new HashSet<MarkersGpscoordinates>();
        }

        public int SubjectId { get; set; }
        public Guid SubjectToken { get; set; }
        public string SubjectName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Exam> Exam { get; set; }
        public virtual ICollection<MarkersGpscoordinates> MarkersGpscoordinates { get; set; }
    }
}
