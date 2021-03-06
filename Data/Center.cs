﻿using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Center
    {
        public Center()
        {
            CenterManger = new HashSet<CenterManger>();
            Exam = new HashSet<Exam>();
            MarkersGpscoordinates = new HashSet<MarkersGpscoordinates>();
            Users = new HashSet<Users>();
        }

        public int CenterId { get; set; }
        public Guid CenterToken { get; set; }
        public string CenterName { get; set; }
        public string CenterNumber { get; set; }
        public int CityId { get; set; }
        public string Scanner { get; set; }
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
        public virtual ICollection<CenterManger> CenterManger { get; set; }
        public virtual ICollection<Exam> Exam { get; set; }
        public virtual ICollection<MarkersGpscoordinates> MarkersGpscoordinates { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
