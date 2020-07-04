using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class City
    {
        public City()
        {
            Center = new HashSet<Center>();
        }

        public int CityId { get; set; }
        public string CityDescription { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Center> Center { get; set; }
    }
}
