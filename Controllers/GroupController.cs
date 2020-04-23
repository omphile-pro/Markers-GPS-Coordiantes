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

namespace Markers_GPS_Coordiantes.Controllers
{
    public class GroupController : Controller
    {
        public async Task<IActionResult> Index()
        {

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
                    string auth = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImxlYjAxYXBpIiwibmJmIjoxNTg3NDU2MzU5LCJleHAiOjE1ODg2NjU5NTksImlhdCI6MTU4NzQ1NjM1OX0.CJfuZlUHbX76OEcZaMV0AuaT-EqRpr5324SyaDeZUpA";


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