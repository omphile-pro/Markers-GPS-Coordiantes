using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Marker
    {
        public Marker()
        {
            MarkerExam = new HashSet<MarkerExam>();
            MarkerSubjectCenter = new HashSet<MarkerSubjectCenter>();
        }

        public int MarkerId { get; set; }
        public Guid MarkerToken { get; set; }
        public int UsersId { get; set; }
        public int PositionId { get; set; }
        public int? CenterId { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedByUsersId { get; set; }
        public int LastModifiedByUsersId { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int CreatedByUsersId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Center Center { get; set; }
        public virtual Users CreatedByUsers { get; set; }
        public virtual Users DeletedByUsers { get; set; }
        public virtual Users LastModifiedByUsers { get; set; }
        public virtual Position Position { get; set; }
        public virtual Users Users { get; set; }
        public virtual ICollection<MarkerExam> MarkerExam { get; set; }
        public virtual ICollection<MarkerSubjectCenter> MarkerSubjectCenter { get; set; }
    }
}
