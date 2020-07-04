using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Markers_GPS_Coordiantes.Models;
using Microsoft.EntityFrameworkCore;

namespace Markers_GPS_Coordiantes.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }
        public DbSet<MarkersReport>Markers{ get; set; }
    }
}
