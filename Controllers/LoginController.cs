using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Markers_GPS_Coordiantes.Data;
using Markers_GPS_Coordiantes.Enumerators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Markers_GPS_Coordiantes.Controllers
{
    public class LoginController : Controller
    {

        dbsMarkersContext db = new dbsMarkersContext();

        public IActionResult Index()
        {
            return View("Login");
        }


      
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) 
        {
            //  I ASKED YOU TO BREAK ON THE FIRST LINE OF THE FUNCTION


            if (ModelState.IsValid) 
            {
                try 
                {
                    var user = await db.Users.Where(k => k.Loginname == model.Username && k.Password == model.Password).FirstOrDefaultAsync();

                    if (user != null) 
                    {
                        //  if you are here it means the user logged in successfully.

                        //  get the role of the user
                        var usersRole = db.UsersRole.Where(h => h.UsersId == user.UsersId).FirstOrDefault();

                        if (usersRole == null) 
                        {
                            return Content("No role has been configured for this user");
                        }

                        //  set sessions here
                        //  you need to set sessions before you redirect, the corresponding dashboard (Marker / Admin) will read from session
                        HttpContext.Session.SetString("displayname", Convert.ToString(user.Displayname));
                        HttpContext.Session.SetString("roleID", Convert.ToString(usersRole.RoleId));
                        HttpContext.Session.SetString("usersID", Convert.ToString(user.UsersId));
                        HttpContext.Session.SetString("usersToken", Convert.ToString(user.UsersToken));

                        //  BASED ON THE ROLES ON THE SERVER REDIRECT TO SPECIFIC PAGE FOR EITHER MARKER OF SUPER ADMIN
                        //  MARKER
                        if (usersRole.RoleId == (int)RoleIDs.CenterManager)
                        {
                            //  get marker record
                            var marker = db.Marker.Where(u => u.UsersId == user.UsersId).FirstOrDefault();

                            if (marker == null) 
                            {
                                return new ContentResult() {
                                    StatusCode = 404,
                                    ContentType = "application/text",
                                    Content = "Marker record does not exist"
                                };
                            }


                            HttpContext.Session.SetString("markerID", Convert.ToString(marker.MarkerId));
                            return RedirectToAction("Index", "Admin");
                        }

                        //CenterManager
                        else if (usersRole.RoleId == (int)RoleIDs.CenterManager)
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        //  ADMINISTRATOR
                        else if (usersRole.RoleId == (int)RoleIDs.Administrator) 
                        {
                            return RedirectToAction("Index", "Admin");
                        }

                        //  SUPERADMIN
                        else if (usersRole.RoleId == (int)RoleIDs.SuperAdmin)
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                    }

                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.ToString());
                }
            }


            return View(model);
        }


        public async Task<IActionResult> SignOut() 
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}