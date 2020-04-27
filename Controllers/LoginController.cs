using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Mail;
using Markers_GPS_Coordiantes.Data;
using Markers_GPS_Coordiantes.Enumerators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Markers_GPS_Coordiantes.Controllers
{
    public class LoginController : Controller
    {

        dbsMarkersContext db = new dbsMarkersContext();
       

        public string EmailAddress;

        public LoginController()
        {
        }
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
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Passcheck = await db.Users.Where(k => k.EmailAddress == model.EmailAddress).FirstOrDefaultAsync();
                    if (Passcheck != null)
                    {

                        //if you are here it means user has account.
                        //get user record.

                        var UserRecord = db.Users.Where(u => u.UsersId == Passcheck.UsersId).FirstOrDefault();
                        if (UserRecord == null)


                        {
                            return Content("No role has been configured for this user");
                            {

                            };
                        }
                        {
                            if (ModelState.IsValid)
                            {
                                try
                                {
                                    MailMessage msz = new MailMessage();
                                    msz.From = new MailAddress(model.EmailAddress);//Email which you are getting 
                                    msz.To.Add("gavenomojahi@gmail.com");//Where mail will be sent 

                                    SmtpClient smtp = new SmtpClient();

                                    smtp.Host = "smtp.gmail.com";

                                    smtp.Port = 587;

                                    smtp.Credentials = new System.Net.NetworkCredential
                                    ("gavenomojahi@gmail.com", "kutlwano23");

                                    smtp.EnableSsl = true;

                                    smtp.Send(msz);

                                    ModelState.Clear();
                                    ViewBag.Message = "Thank you for Contacting us ";
                                }
                                catch (Exception ex)
                                {
                                    ModelState.Clear();
                                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}";
                                }
                            }
                            // Build the password reset link
                            var passwordResetLink = Url.Action("ChangePassword", "login",
                                        new { email = model.EmailAddress }, Request.Scheme);
                            // Log the password reset link

                            return View("ForgotPasswordConfirmation");
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
    }
}
