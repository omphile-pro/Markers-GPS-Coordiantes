using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Markers_GPS_Coordiantes.Data
{
    public class vMarkerMetaData
    {
        [Key]
        public int MarkerId { get; set; }
    }

    [MetadataType(typeof(vMarkerMetaData))]
    public partial class VMarker 
    {
    
    }
}
