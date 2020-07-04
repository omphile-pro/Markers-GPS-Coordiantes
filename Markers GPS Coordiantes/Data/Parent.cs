using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Parent
    {
        public Parent()
        {
            Child = new HashSet<Child>();
        }

        public int Id { get; set; }
        public string Data { get; set; }

        public virtual ICollection<Child> Child { get; set; }
    }
}
