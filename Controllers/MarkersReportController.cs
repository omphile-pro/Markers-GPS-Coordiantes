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
    public class MarkersReportController : Controller
    {
        dbsMarkersContext _context = new dbsMarkersContext();




        public IActionResult Index()
        {

            Console.WriteLine("Works");
            List<VMarkersGpscoordinates> supList = _context.VMarkersGpscoordinates.Select(x => new VMarkersGpscoordinates
            {
                FullName = x.FullName,
                PhysicalAddress = x.PhysicalAddress,
                CentreNumber = x.CentreNumber,
                SubjectName = x.SubjectName,
                PaperNumber = x.PaperNumber,
                PositionDescription = x.PositionDescription,
                Distance = x.Distance
            }).ToList();
            return View(supList);
        }

        public void ExportToExcel()
        {
            List<VMarkersGpscoordinates> supList = _context.VMarkersGpscoordinates.Select(x => new VMarkersGpscoordinates
            {
                FullName = x.FullName,
                PhysicalAddress = x.PhysicalAddress,
                CentreNumber = x.CentreNumber,
                SubjectName = x.SubjectName,
                PaperNumber = x.PaperNumber,
                PositionDescription = x.PositionDescription,
                Distance = x.Distance
            }).ToList();

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Reports");

            ws.Cells["A1"].Value = "FullName";
            ws.Cells["B1"].Value = "PhysicalAddress";
            ws.Cells["C1"].Value = "CentreNumber";
            ws.Cells["D1"].Value = "SubjectName";
            ws.Cells["E1"].Value = "PaperNumber";
            ws.Cells["F1"].Value = "PositionDescription";
            ws.Cells["G1"].Value = "Distance";

            int rowStart = 2;
            foreach (var item in supList)
            {
                //ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;

                ws.Cells[string.Format("A{0}", rowStart)].Value = item.FullName;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.PhysicalAddress;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.CentreNumber;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.SubjectName;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.PaperNumber;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.PositionDescription;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.Distance;

                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
           
            Console.WriteLine("Works");
        }

        public void getGroup()
        {
            var client = new RestClient("https://portal.accesstrack.co.za/integri/api/scanGroup/scanGroups");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImxlYjAxYXBpIiwibmJmIjoxNTg1NzI1MjA1LCJleHAiOjE1ODY5MzQ4MDUsImlhdCI6MTU4NTcyNTIwNX0.Iko52CRCn0SVwwr9_FyXvenNMbBDbm6sUWrkzJH5z2s");
            request.AddParameter("application/json", "{ \"siteId\": 1164,\n\"fromDate\": \"2019-11-15\",\n\"toDate\": \"2019-11-15T23:59\" }", ParameterType.RequestBody);
            Response.Headers.Add("content-disposotion", "attachment : filename" + "ExcelReport.xlsx");
            
            Response.CompleteAsync();
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

    }
}