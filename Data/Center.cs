using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Center
    {
        public Center()
        {
            Exam = new HashSet<Exam>();
            Marker = new HashSet<Marker>();
            MarkersGpscoordinates = new HashSet<MarkersGpscoordinates>();
        }

        public int CenterId { get; set; }
        public Guid CenterToken { get; set; }
        public string CenterName { get; set; }
        public string CenterNumber { get; set; }
        public string CenterDescription { get; set; }
        public int CityId { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedByUsersId { get; set; }
        public int LastModifiedByUsersId { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int CreatedByUsersId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual City City { get; set; }
        public virtual Users CreatedByUsers { get; set; }
        public virtual Users DeletedByUsers { get; set; }
        public virtual Users LastModifiedByUsers { get; set; }
        public virtual ICollection<Exam> Exam { get; set; }
        public virtual ICollection<Marker> Marker { get; set; }
        public virtual ICollection<MarkersGpscoordinates> MarkersGpscoordinates { get; set; }
    }
}
