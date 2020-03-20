using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Gender
    {
        public Gender()
        {
            Users = new HashSet<Users>();
        }

        public int GenderId { get; set; }
        public string GenderDescription { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
