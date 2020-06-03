using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Markers_GPS_Coordiantes.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Markers_GPS_Coordiantes.Data;
using Markers_GPS_Coordiantes.Enumerators;
using Microsoft.AspNetCore.Http;
namespace Markers_GPS_Coordiantes.Controllers
{
    public class GroupController : Controller
    {
        dbsMarkersContext _context = new dbsMarkersContext();
        private readonly IHttpContextAccessor _sessionAccessor;
        int roleID = 0;
        public int CenterID = 0;
        public int UsersID = 0;

        public GroupController(IHttpContextAccessor sessionAccessor)
        {
            _sessionAccessor = sessionAccessor;
        }
        public async Task<IActionResult> Index()
        {
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }

            List<groups> reservationList = new List<groups>();
            List<groups> viewList = new List<groups>();

            string url = "https://portal.accesstrack.co.za/integri/api/scanGroup/scanGroups";
            var values = new Dictionary<string, string>
                               {
                { "siteId", "1164" },
                { "fromDate", "2019-11-15" },
                { "toDate", "2019-11-15T23:59" }
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

                    CenterID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("centerID"));
                    UsersID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("usersID"));
                    roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("roleID"));

                    var center = await _context.VCenter.Where(b => b.CenterId == CenterID).FirstOrDefaultAsync();


                    List<Center> scannerCenter = new List<Center>();

                    if (roleID == (int)RoleIDs.SuperAdmin)
                    {
                        scannerCenter = _context.Center.Select(x => new Center
                        {
                            Scanner = x.Scanner,
                            CenterName = x.CenterName
                        }).ToList();

                    }
                    else
                    {
                        scannerCenter = await _context.Center.Where(b => b.CenterId == center.CenterId).ToListAsync();
                    }


                    

                    for (int i = 0; i < scannerCenter.Count; i++)
                    {
                        Debug.WriteLine(scannerCenter.Count);
                        for (int j = 0; j < reservationList.Count; j++)
                        {
                            if (scannerCenter[i].Scanner == reservationList[j].displayName)
                            {
                                Debug.WriteLine(reservationList[j].licenceNumber);
                                Debug.WriteLine(scannerCenter[i].Scanner + "is equal to " + reservationList[j].displayName);
                                viewList.Add(new groups
                                {
                                    CenterName = scannerCenter[i].CenterName,
                                    displayName = scannerCenter[i].Scanner,
                                    idNumber = reservationList[j].idNumber,
                                    licenceNumber = reservationList[j].licenceNumber,
                                    timestamp = reservationList[j].timestamp,
                                    hasBlacklist = reservationList[j].hasBlacklist,
                                    expiryDate = reservationList[j].expiryDate,
                                    sadlExpiryDate = reservationList[j].sadlExpiryDate
                                });


                            }
                        }


                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString()); //"Invalid URI: The Uri string is too long."
                }
            }
            return View(viewList);
        }
    }
}