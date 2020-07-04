using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Vsubject
    {
        public int SubjectId { get; set; }
        public int CenterId { get; set; }
        public string SubjectName { get; set; }
        public Guid SubjectToken { get; set; }
        public int Expr1 { get; set; }
        public string FullName { get; set; }
        public string IdNumber { get; set; }
    }
}
