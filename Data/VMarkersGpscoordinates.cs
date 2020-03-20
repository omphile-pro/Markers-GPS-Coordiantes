using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class VMarkersGpscoordinates
    {
        public int MarkersId { get; set; }
        public int SubjectId { get; set; }
        public int CenterId { get; set; }
        public int UsersId { get; set; }
        public string CentreNumber { get; set; }
        public string CentreName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string IdNumber { get; set; }
        public string Subject { get; set; }
        public string Paper { get; set; }
        public string Position { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalCode { get; set; }
        public string PersalNumber { get; set; }
        public string WorkTelephone { get; set; }
        public string Cellphone { get; set; }
        public string HomeTelephone { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string CenterName { get; set; }
        public string CenterNumber { get; set; }
        public decimal? CenterLongitude { get; set; }
        public decimal? CenterLatitude { get; set; }
        public string Distance { get; set; }
    }
}
