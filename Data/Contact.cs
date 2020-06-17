using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public int? IdentityNo { get; set; }
        public string TelephoneNo { get; set; }
        public string WorkSchool { get; set; }
        public string HomeTelephoneNo { get; set; }
        public string CellphoneNo { get; set; }
        public string FaxNo { get; set; }
        public string EmailAddress { get; set; }

        public virtual Marker IdentityNoNavigation { get; set; }
    }
}
