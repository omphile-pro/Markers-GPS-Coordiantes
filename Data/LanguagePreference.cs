﻿using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class LanguagePreference
    {
        public int LanguagePreferenceId { get; set; }
        public string IdentityNo { get; set; }
        public string LanguageDescription { get; set; }

        public virtual Marker IdentityNoNavigation { get; set; }
    }
}
