using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Markers_GPS_Coordiantes.Data;
using Microsoft.AspNetCore.Http;
using Markers_GPS_Coordiantes.Enumerators;

namespace Markers_GPS_Coordiantes.Controllers
{
    public class MarkersReportController : Controller
    {
        dbsMarkersContext _context = new dbsMarkersContext();

        public async Task<IActionResult> Index()
        {
            var dbsMarkersContext = _context.VMarkersGpscoordinates.OrderBy(g => g.CenterName);
            return View(await dbsMarkersContext.ToListAsync());
        }
    }
}