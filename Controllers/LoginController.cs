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
            if (ModelState.IsValid) 
            {
                try 
                {
                    var user = await db.Users.Where(k => k.Loginname == model.Username && k.Password == model.Password).FirstOrDefaultAsync();

                    if (user != null) 
                    {
                        //  if you are here it means the user logged in successfully.

                        //  get the role of the user
                        var users = db.Users.Where(h => h.UsersId == user.UsersId).FirstOrDefault();

                        if (users == null) 
                        {
                            return Content("No role has been configured for this user");
                        }

                        //  set sessions here
                        //  you need to set sessions before you redirect, the corresponding dashboard (Marker / Admin) will read from session
                        HttpContext.Session.SetString("displayname", Convert.ToString(user.Displayname));
                        HttpContext.Session.SetInt32("roleID", users.RoleId);
                        HttpContext.Session.SetInt32("usersID", user.UsersId);
                        HttpContext.Session.SetInt32("centerID", user.CenterId);
                        
                        HttpContext.Session.SetString("usersToken", Convert.ToString(user.UsersToken));



                        //  BASED ON THE ROLES ON THE SERVER REDIRECT TO SPECIFIC PAGE FOR EITHER MARKER OF SUPER ADMIN
                        //  MARKER
                        //  what did you do here
                        //  i only change the marker to centerManager role 
                        if (users.RoleId == (int)RoleIDs.CenterManager)
                        {
                            //  get marker record
                            var CenterManger = db.CenterManger.Where(u => u.UsersId == user.UsersId).FirstOrDefault();

                            if (CenterManger == null) 
                            {
                                return new ContentResult() {
                                    StatusCode = 404,
                                    ContentType = "application/text",
                                    Content = "Marker record does not exist"
                                };
                            }


                            HttpContext.Session.SetString("CenterManagerId", Convert.ToString(CenterManger.CenterManagerId));
                            return RedirectToAction("Index", "Admin");
                        }

                      
                        //  ADMINISTRATOR
                        else if (users.RoleId == (int)RoleIDs.Administrator) 
                        {
                            return RedirectToAction("Index", "Admin");
                        }

                        //  SUPERADMIN
                        else if (users.RoleId == (int)RoleIDs.SuperAdmin)
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