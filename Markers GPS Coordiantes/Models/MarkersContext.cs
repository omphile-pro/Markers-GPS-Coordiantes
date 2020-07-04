using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Markers_GPS_Coordiantes.Models
{
    public class MarkersContext : DbContext
    {
        public MarkersContext(DbContextOptions<MarkersContext> options) : base(options)
        {
        }
            public DbSet<Markers> Markers{ get;set;}
        public string Text { get; set; }
        }
    }

