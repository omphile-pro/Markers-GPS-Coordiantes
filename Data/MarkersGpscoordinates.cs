using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class MarkersGpscoordinates
    {
        public int MarkersId { get; set; }
        public int SubjectId { get; set; }
        public int CenterId { get; set; }
        public int UsersId { get; set; }
        public int RaceId { get; set; }
        public int ExamId { get; set; }
        public int GenderId { get; set; }
        public int PositionId { get; set; }
        public string CentreNumber { get; set; }
        public string FullName { get; set; }
        public string IdNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalCode { get; set; }
        public string PersalNumber { get; set; }
        public string WorkTelephone { get; set; }
        public string HomeTelephone { get; set; }
        public string Cellphone { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUsersId { get; set; }
        public virtual Center Center { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Position Position { get; set; }
        public virtual Race Race { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Users Users { get; set; }
    }
}
