using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Markers_GPS_Coordiantes.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using OfficeOpenXml;
using RestSharp;
using Markers_GPS_Coordiantes.Enumerators;
namespace Markers_GPS_Coordiantes.Controllers
{

    public class ExportController : Controller
    {
        private readonly IWebHostEnvironment _IWebHostEnvironment;
        dbsMarkersContext _context = new dbsMarkersContext();

        public ExportController(IWebHostEnvironment IWebHostEnvironment, dbsMarkersContext context)
        {
            _IWebHostEnvironment = IWebHostEnvironment;
        }
            public IActionResult Index()
        {


            Console.WriteLine("Works");
            List<VMarkersGpscoordinates> supList = _context.VMarkersGpscoordinates.Select(x => new VMarkersGpscoordinates
            {
                Distance = x.Distance
            }).ToList();
            return View(supList);
        }
        public string ExportToExcel()
        {
            string rootFolder = _hostingEnvironment.WebRootPath;
            string fileName = @"ExportMarkers.xlsx";

            FileInfo file = new FileInfo(Path.Combine(rootFolder, fileName));

            using (ExcelPackage package = new ExcelPackage(file))
            {

                IList<VMarkersGpscoordinates> supList = _context.VMarkersGpscoordinates.ToList();

                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Markers");
                int totalRows = supList.Count();

                worksheet.Cells[1, 1].Value = "Distance";
               
                int i = 0;
                for (int row = 2; row <= totalRows + 1; row++)
                {
                    worksheet.Cells[row, 1].Value = supList[i].Distance;
                
                    i++;
                }

                package.Save();

            }

            return " Markers list has been exported successfully";
        }


    }
}