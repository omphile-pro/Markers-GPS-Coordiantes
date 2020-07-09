using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Markers_GPS_Coordiantes.Data;
using Microsoft.AspNetCore.Http;
using Markers_GPS_Coordiantes.Enumerators;
using System.IO;
using OfficeOpenXml;
using System.Net.Mail;
using System.Text;
using Microsoft.AspNetCore.Hosting;

namespace Markers_GPS_Coordiantes.NotificationSystem
{
    public class EmailNotificationSystem
    {
        private readonly IHostingEnvironment env;
        payMarkerContext _context = new payMarkerContext();

        public EmailNotificationSystem(IHostingEnvironment _env) 
        {
            env = _env;
        }


        //  APPOINTMENT LETTER
        public async Task<int> SendAppointmentLetter() 
        {
            int res = 404;
            try { }
            catch (Exception ex) 
            { 
            
            }
            return res;
        }

        //  APPOINTMENT LETTER
        public async Task<int> SendLoginDetails(int? usersID)
        {
            int res = 404;

            if (usersID != null) 
            {
                var user = await _context.Users.Where(k => k.UsersId == usersID).FirstOrDefaultAsync();
                try {
                    using (SmtpClient smtpClient = new SmtpClient())
                    {
                        //  SET UP SMTP --  Add you info here
                        smtpClient.Port = 25;
                        smtpClient.Host = "mail.tisscorporation.co.za";
                        smtpClient.Credentials = new System.Net.NetworkCredential("tracker@tisscorporation.co.za", "H3ALT#YANDw3lTHY4eVR");
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.EnableSsl = true;
                        smtpClient.Timeout = 15000;

                        MailMessage mail = new MailMessage();
                        mail.Subject = "Login Details";
                        mail.IsBodyHtml = true;
                        mail.From = new MailAddress("tracker@tisscorporation.co.za", "Admin");
                        mail.To.Add(new MailAddress(user.EmailAddress));
                        mail.Bcc.Add(new MailAddress("gavenomojahi@gmail.com"));   //  usually the person sending the email (logged in user)

                        //  GET EMAIL TEMPLATE
                        string rootFileDir = env.ContentRootPath;
                        string emailTemplateFilename = "LoginDetails.html";
                        string emailTemplate = System.IO.File.ReadAllText(rootFileDir + @"\wwwroot\Emailtemplates\" + emailTemplateFilename, Encoding.UTF8);
                        mail.Body = emailTemplate.Replace("@@Displayname@@", user?.Displayname ?? "User").Replace("@@Username@@", user.Loginname).Replace("@Password@", user.Password);
                        mail.IsBodyHtml = true;

                        //  SEND EMAIL
                        smtpClient.Send(mail);
                    }


                }
                catch (Exception ex)
                {

                    Console.Write(ex.ToString());
                }
            }

            return res;
        }
       

        //  APPOINTMENT LETTER
        public async Task<int> SendDistricMessage()
        {
            int res = 404;
            try { }
            catch (Exception ex)
            {

            }
            return res;
        }

    }
}
