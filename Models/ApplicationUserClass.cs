using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Markers_GPS_Coordiantes.Models
{
    public class ApplicationUserClass:DbContext
    {
        public ApplicationUserClass(DbContextOptions<ApplicationUserClass> options) : base(options)
        {
        }
        public DbSet<UserRegistration> UserRegistration { get; set; }
        }
    }

