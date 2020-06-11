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
        private readonly IHttpContextAccessor _sessionAccessor;
        int roleID = 0;
        public int CenterID = 0;
        public int UsersID = 0;

        public MarkersReportController(IHttpContextAccessor sessionAccessor)
        {
            _sessionAccessor = sessionAccessor;
        }

        public IEnumerable<VMarkersGpscoordinates> results { get; set; }

        public void OnGet()
        {
            results = _context.VMarkersGpscoordinates.ToList();
        }
        public void OnPost(DateTime from, DateTime To)
        {
            results = (from x in _context.VMarkersGpscoordinates where (x.CreatedDate <= @from) && (x.CreatedDate > To) select x).ToList();

        }

        public async Task<IActionResult> IndexAsync()
        {

            //Get Data API
            //Get current date and time
            var fromDate = DateTime.Now.ToString("yyyy-MM-dd");
            var toDate = DateTime.Now.ToString("yyyy-MM-dd");
            var toDateTime = DateTime.Now.ToString("HH:mm");
            // toDate+"T"+toDateTime
            ViewBag.value = DateTime.Now;


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
                    string auth = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImxlYjAxYXBpIiwibmJmIjoxNTkwMTMxNDM4LCJleHAiOjE1OTEzNDEwMzgsImlhdCI6MTU5MDEzMTQzOH0.idVCy8Oxl76zd2M8AjcoxRPcXjZofJedT72cTscoIZ8";


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


            CenterID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("centerID"));
            UsersID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("usersID"));
            roleID  = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("roleID"));


            var center = await _context.VCenter.Where(b => b.CenterId == CenterID).FirstOrDefaultAsync();

            //  check if the user is registered in the CenterManager-Center join table
            var MarkersGpscoordinates = await _context.Users.Where(b => b.UsersId == UsersID && b.CenterId == center.CenterId).FirstOrDefaultAsync();
            if (MarkersGpscoordinates == null)
            {
                return NotFound("You are not configured as center manager, please consult your system administrator.");
            }
            List<VMarkersGpscoordinates> supList = new List<VMarkersGpscoordinates>();

            if(roleID == (int)RoleIDs.SuperAdmin)
            {
                 supList = _context.VMarkersGpscoordinates.Select(x => new VMarkersGpscoordinates
                {
                    FullName = x.FullName,
                    IdNumber = x.IdNumber,
                    PhysicalAddress = x.PhysicalAddress,
                    CentreNumber = x.CentreNumber,
                    CenterName = x.CenterName,
                    SubjectName = x.SubjectName,
                    PaperNumber = x.PaperNumber,
                    PositionDescription = x.PositionDescription,
                    Distance = x.Distance,
                    PayOut = x.PayOut

                }).ToList();

            }
            else
            {
                supList = await _context.VMarkersGpscoordinates.Where(b => b.CenterId == center.CenterId).ToListAsync();
            }

            List<viewModel> viewList = new List<viewModel>();

            for (int i = 0; i < supList.Count; i++)
            { 
                for (int j = 0; j < reservationList.Count; j++)
                {
 

                    if (supList[i].IdNumber == reservationList[j].idNumber)
                    {
                        Debug.WriteLine(reservationList[j].licenceNumber);
                        Debug.WriteLine(supList[i].IdNumber + "is equal to " + reservationList[j].idNumber);
                        viewList.Add(new viewModel
                        {
                            FullName = supList[i].FullName,
                            IdNumber = reservationList[j].idNumber,
                            PhysicalAddress = supList[i].PhysicalAddress,
                            CentreNumber = supList[i].CentreNumber,
                            CenterName = supList[i].CenterName,
                            SubjectName = supList[i].SubjectName,
                            PaperNumber = supList[i].PaperNumber,
                            PositionDescription = supList[i].PositionDescription,
                            Distance = supList[i].Distance,
                            PayOut = supList[i].PayOut,
                            licenceNumber = reservationList[j].licenceNumber

                        });


                    }
                }


            }
            return View(viewList);


        }

        public async Task<IActionResult> ExportToExcel(List<viewModel> model)
        {
            byte[] result;
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
                    string auth = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImxlYjAxYXBpIiwibmJmIjoxNTkwMTMxNDM4LCJleHAiOjE1OTEzNDEwMzgsImlhdCI6MTU5MDEzMTQzOH0.idVCy8Oxl76zd2M8AjcoxRPcXjZofJedT72cTscoIZ8";


                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", auth);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync(url, content);
                    Task<string> responseString = response.Content.ReadAsStringAsync();
                    string outputJson = await responseString;

                    reservationList = JsonConvert.DeserializeObject<List<groups>>(outputJson);

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString()); //"Invalid URI: The Uri string is too long."
                }
            }


            CenterID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("centerID"));
            UsersID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("usersID"));
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("roleID"));


            var center = await _context.VCenter.Where(b => b.CenterId == CenterID).FirstOrDefaultAsync();

            //  check if the user is registered in the CenterManager-Center join table
            var MarkersGpscoordinates = await _context.Users.Where(b => b.UsersId == UsersID && b.CenterId == center.CenterId).FirstOrDefaultAsync();
            if (MarkersGpscoordinates == null)
            {
                return NotFound("You are not configured as center manager, please consult your system administrator.");
            }

            List<VMarkersGpscoordinates> supList = new List<VMarkersGpscoordinates>();

            if (roleID == (int)RoleIDs.SuperAdmin)
            {
                supList = _context.VMarkersGpscoordinates.Select(x => new VMarkersGpscoordinates
                {
                    FullName = x.FullName,
                    IdNumber = x.IdNumber,
                    PhysicalAddress = x.PhysicalAddress,
                    CentreNumber = x.CentreNumber,
                    CenterName = x.CenterName,
                    SubjectName = x.SubjectName,
                    PaperNumber = x.PaperNumber,
                    PositionDescription = x.PositionDescription,
                    Distance = x.Distance,
                    PayOut = x.PayOut

                }).ToList();

            }
            else
            {
                supList = await _context.VMarkersGpscoordinates.Where(b => b.CenterId == center.CenterId).ToListAsync();
            }



            List<viewModel> viewList = new List<viewModel>();

            for (int i = 0; i < supList.Count; i++)
            {
                for (int j = 0; j < reservationList.Count; j++)
                {
                    if (supList[i].IdNumber == reservationList[j].idNumber)
                    {
                        Debug.WriteLine(reservationList[j].licenceNumber);
                        Debug.WriteLine(supList[i].IdNumber + "is equal to " + reservationList[j].idNumber);
                        viewList.Add(new viewModel
                        {
                            FullName = supList[i].FullName,
                            IdNumber = reservationList[j].idNumber,
                            PhysicalAddress = supList[i].PhysicalAddress,
                            CentreNumber = supList[i].CentreNumber,
                            CenterName = supList[i].CenterName,
                            SubjectName = supList[i].SubjectName,
                            PaperNumber = supList[i].PaperNumber,
                            PositionDescription = supList[i].PositionDescription,
                            Distance = supList[i].Distance,
                            PayOut = supList[i].PayOut,
                            licenceNumber = reservationList[j].licenceNumber

                        });


                    }
                }


            }


            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Reports");

            ws.Cells["A1"].Value = "FullName";
            ws.Cells["B1"].Value = "IdNumber";
            ws.Cells["C1"].Value = "PhysicalAddress";
            ws.Cells["D1"].Value = "CentreNumber";
            ws.Cells["E1"].Value = "CenterName";
            ws.Cells["F1"].Value = "SubjectName";
            ws.Cells["G1"].Value = "PaperNumber";
            ws.Cells["H1"].Value = "PositionDescription";
            ws.Cells["I1"].Value = "Distance";
            ws.Cells["J1"].Value = "PayOut";
            int rowStart = 2;
            foreach (var item in viewList)
            {
                // ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;

                ws.Cells[string.Format("A{0}", rowStart)].Value = item.FullName;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.IdNumber;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.PhysicalAddress;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.CentreNumber;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.CenterName;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.SubjectName;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.PaperNumber;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.PositionDescription;
                ws.Cells[string.Format("I{0}", rowStart)].Value = item.Distance;
                ws.Cells[string.Format("J{0}", rowStart)].Value = item.PayOut;
                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            result = pck.GetAsByteArray();

            var now = DateTime.Now.ToString("yyyy-MM-dd");


            return File(result, "application/vnd.excel", now + ".xlsx");
        }
        public async Task<IActionResult> UsersReport()
        {
            var dbsMarkersContext = _context.VusersReport.OrderBy(g => g.CenterName);
            return View(await dbsMarkersContext.ToListAsync());
        }

    }
}