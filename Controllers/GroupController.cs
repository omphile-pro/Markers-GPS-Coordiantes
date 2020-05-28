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
            if (roleID != (int)RoleIDs.SuperAdmin && roleID != (int)RoleIDs.CenterManager)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            List<groups> reservationList = new List<groups>();

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
                    Debug.WriteLine("Its working");
                    Debug.WriteLine(outputJson);
                    reservationList = JsonConvert.DeserializeObject<List<groups>>(outputJson);

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString()); //"Invalid URI: The Uri string is too long."
                }
            }
            return View(reservationList);
        }
    }
}