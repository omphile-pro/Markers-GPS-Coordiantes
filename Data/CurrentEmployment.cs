using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class CurrentEmployment
    {
        public int CurrentEmploymentId { get; set; }
        public string IdentityNo { get; set; }
        public string NameOftheSchoolOffice { get; set; }
        public string CentreNumber { get; set; }
        public string District { get; set; }
        public string CurrentPosition { get; set; }
        public string EmploymentType { get; set; }
        public string Retiring { get; set; }

        public virtual Marker IdentityNoNavigation { get; set; }
    }
}
