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
    public class AdminController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            //Get current date and time
            var fromDate = DateTime.Now.ToString("yyyy-MM-dd");
            var toDate = DateTime.Now.ToString("yyyy-MM-dd");
            var toDateTime = DateTime.Now.ToString("HH:mm");
            // toDate+"T"+toDateTime

            Debug.WriteLine("The date and time:" + toDate + "T" + toDateTime);
            
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
                    var reservationList = JsonConvert.DeserializeObject<List<groups>>(outputJson);
                    int numberOfScans = reservationList.Count();
                    Debug.WriteLine(reservationList.Count());

                    int numberOfCars = 0;

                    for (int x = 0;x< numberOfScans; x++)
                    {
                        if(reservationList[x].licenceNumber != null)
                        {
                            numberOfCars++;
                        }
                    }

                    Debug.WriteLine(numberOfCars);
                    ViewData["NumberofScans"] = numberOfScans;
                    ViewData["NumberofCars"] = numberOfCars;

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString()); //"Invalid URI: The Uri string is too long."
                }
            }
            
            return View();
        }
    }
}