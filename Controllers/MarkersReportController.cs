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
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Markers_GPS_Coordiantes.Models;

namespace Markers_GPS_Coordiantes.Controllers
{
    public class MarkersReportController : Controller
    {
        dbsMarkersContext _context = new dbsMarkersContext();

        public async Task<IActionResult> IndexAsync()
        {
            //Get Data API
            //Get current date and time
            var fromDate = DateTime.Now.ToString("yyyy-MM-dd");
            var toDate = DateTime.Now.ToString("yyyy-MM-dd");
            var toDateTime = DateTime.Now.ToString("HH:mm");
            // toDate+"T"+toDateTime

                List<groups> reservationList = new List<groups>();
            // Get access track data
            string url = "https://portal.accesstrack.co.za/integri/api/scanGroup/scanGroups";
            var values = new Dictionary<string, string>
                               {
                { "siteId", "1164" },
                { "fromDate", "2019-11-15" },
                { "toDate", "2019-11-15T06:00" }
                };

            using (var client = new HttpClient())
            {
                try
                {
                    string auth = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImxlYjAxYXBpIiwibmJmIjoxNTg3NDU2MzU5LCJleHAiOjE1ODg2NjU5NTksImlhdCI6MTU4NzQ1NjM1OX0.CJfuZlUHbX76OEcZaMV0AuaT-EqRpr5324SyaDeZUpA";


                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync(url, content);
                    Task<string> responseString = response.Content.ReadAsStringAsync();
                    string outputJson = await responseString;

                    Debug.WriteLine(outputJson);
                     reservationList = JsonConvert.DeserializeObject<List<groups>>(outputJson);
                    int numberOfScans = reservationList.Count();

                    int numberOfCars = 0;

                    for (int x = 0; x < numberOfScans; x++)
                    {
                        if (reservationList[x].licenceNumber != null)
                        {
                            numberOfCars++;
                        }
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString()); //"Invalid URI: The Uri string is too long."
                }
            }


            List<VMarkersGpscoordinates> supList = _context.VMarkersGpscoordinates.Select(x => new VMarkersGpscoordinates
            {
                FullName = x.FullName,
                PhysicalAddress = x.PhysicalAddress,
                CentreNumber = x.CentreNumber,
                CenterName = x.CenterName,
                SubjectName = x.SubjectName,
                PaperNumber = x.PaperNumber,
                PositionDescription = x.PositionDescription,
                Distance = x.Distance,
                IdNumber = x.IdNumber
            }).ToList();

            List<VMarkersGpscoordinates> viewList = new List<VMarkersGpscoordinates>();

            for (int i = 0; i < supList.Count; i++)
            { // Loop through List with for
                //Debug.WriteLine(supList[i].IdNumber);
                for(int j = 0;j < reservationList.Count; j++)
                {
                    //if (supList[i].IdNumber.Any(x => reservationList[j].idNumber.Any(y => y == x)))
                    //{
                    //    Debug.WriteLine(y"There are equal elements");
                    //}

                    if(supList[i].IdNumber == reservationList[j].idNumber)
                    {
                        Debug.WriteLine(supList[i].IdNumber + "is equal to " + reservationList[j].idNumber);
                        viewList.Add(new VMarkersGpscoordinates 
                        {
                            FullName = supList[i].FullName,
                            PhysicalAddress = supList[i].PhysicalAddress,
                            CentreNumber = supList[i].CentreNumber,
                            CenterName = supList[i].CenterName,
                            SubjectName = supList[i].SubjectName,
                            PaperNumber = supList[i].PaperNumber,
                            PositionDescription = supList[i].PositionDescription,
                            Distance = supList[i].Distance,
                            IdNumber = supList[i].IdNumber
                        });


                    }
                }

               
            }
            return View(viewList);

            
        }

        public async Task<IActionResult> ExportToExcel()
        {
            byte[] result;

            List<VMarkersGpscoordinates> supList = _context.VMarkersGpscoordinates.Select(x => new VMarkersGpscoordinates
            {
                FullName = x.FullName,
                PhysicalAddress = x.PhysicalAddress,
                CentreNumber = x.CentreNumber,
                CenterName = x.CenterName,
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
            ws.Cells["D1"].Value = "CenterName";
            ws.Cells["E1"].Value = "SubjectName";
            ws.Cells["F1"].Value = "PaperNumber";
            ws.Cells["G1"].Value = "PositionDescription";
            ws.Cells["H1"].Value = "Distance";

            int rowStart = 2;
            foreach (var item in supList)
            {
                // ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;

                ws.Cells[string.Format("A{0}", rowStart)].Value = item.FullName;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.PhysicalAddress;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.CentreNumber;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.CenterName;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.SubjectName;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.PaperNumber;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.PositionDescription;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.Distance;

                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            result = pck.GetAsByteArray();

            var now = DateTime.Now.ToString("yyyy-MM-dd");


            return File(result, "application/vnd.ms-excel", now + ".xls");
        } public async Task<IActionResult> UsersReport()
            {
            var dbsMarkersContext = _context.VusersReport.OrderBy(g => g.CenterName);
            return View(await dbsMarkersContext.ToListAsync());
        }

        }
    }
