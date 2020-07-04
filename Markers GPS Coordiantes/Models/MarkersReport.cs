using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Markers_GPS_Coordiantes.Models
{
    public class MarkersReport
    {
        
            [Key]
            public int Markerid { get; set; }
           
            public string Centre_No { get; set; }
           
            public string Centre_Name { get; set; }
        
            public string Fullname { get; set; }
           
            public string Gender { get; set; }
          
            public string Race { get; set; }
          
            public string Subject { get; set; }
          
            public string Paper_No { get; set; }
       
            public string Position { get; set; }
           
            public string Address { get; set; }

        };

  


    }



