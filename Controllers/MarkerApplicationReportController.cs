using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Markers_GPS_Coordiantes.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using OfficeOpenXml;
using RestSharp;
using Markers_GPS_Coordiantes.Enumerators;


namespace Markers_GPS_Coordiantes.Controllers
{
    public class MarkerApplicationReportController : Controller
    {
        dbsMarkersContext _context = new dbsMarkersContext();
     
        public IActionResult Index()
        {
            List<VMarkerApplicationReport> supList = _context.VMarkerApplicationReport.Select(x => new VMarkerApplicationReport
            {
                IdentityNo = x.IdentityNo,
                Surname = x.Surname,
                Subject = x.Subject,
                Language = x.Language,
                Paper = x.Paper,
                Position = x.Position,
                CurrentPosition = x.CurrentPosition
            }).ToList();
            return View();
        }

        public async Task<IActionResult> ExportToExcel(TrueView model)
        {
            byte[] result;
            List<VMarkerApplicationReport> reportList = new List<VMarkerApplicationReport>();


            var position = model.Position;
            var subj = "Geography";

            reportList = await _context.VMarkerApplicationReport.Where(b => b.Position == position && b.Subject == subj).ToListAsync();

            List<VMarkerApplicationReport> supList = _context.VMarkerApplicationReport.Select(x => new VMarkerApplicationReport
            {
                IdentityNo = x.IdentityNo,
                Surname = x.Surname,
                Subject = x.Subject,
                Language = x.Language,
                Paper = x.Paper,
                Position = x.Position,
                CurrentPosition = x.CurrentPosition
            }).ToList();

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Reports");

            ws.Cells["A1"].Value = "IdentityNo";
            ws.Cells["B1"].Value = "Surname";
            ws.Cells["C1"].Value = "Subject";
            ws.Cells["D1"].Value = "Language";
            ws.Cells["E1"].Value = "Paper";
            ws.Cells["F1"].Value = "Position";
            ws.Cells["G1"].Value = "CurrentPosition";

            int rowStart = 2;
            foreach (var item in reportList)
            {
                // ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;

                ws.Cells[string.Format("A{0}", rowStart)].Value = item.IdentityNo;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.Surname;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Subject;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.Language;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.Paper;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.Position;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.CurrentPosition;

                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            result = pck.GetAsByteArray();
            var now = DateTime.Now.ToString("yyyy-MM-dd");

            return File(result, "application/vnd.ms-excel", now + ".xlsx");
        }


    }
}