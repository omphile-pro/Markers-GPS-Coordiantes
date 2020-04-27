using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Markers_GPS_Coordiantes.Data
{
    public class ApplicationUser:DbContext
    {
        public ApplicationUser(DbContextOptions<ApplicationUser> options) : base(options)
        {
        }
        public DbSet<Login> Users { get; set; }
        }
    }

