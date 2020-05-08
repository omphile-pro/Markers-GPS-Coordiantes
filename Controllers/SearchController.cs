using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Markers_GPS_Coordiantes.Data;
using Microsoft.AspNetCore.Mvc;

namespace Markers_GPS_Coordiantes.Controllers
{

    public class SearchController : Controller
    {
        private readonly dbsMarkersContext _date;

        public SearchController(dbsMarkersContext date)
        {
            _date = date;
        }
        public IEnumerable<VMarkersGpscoordinates> results { get; set; }

        public void OnGet()
        {
            results = _date.VMarkersGpscoordinates.ToList();
        }

        public void OnPost (DateTime startdate,DateTime To)
        {
            results = (from x in _date.VMarkersGpscoordinates where (x.CreatedDate<= startdate) && (x.CreatedDate > To) select x).ToList();
        }

            public IActionResult Index()
        {
            return View();
        }
    }
}

