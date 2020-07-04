using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Markers_GPS_Coordiantes.Data;
using System.Text.Json.Serialization;
using System.Diagnostics;

namespace Markers_GPS_Coordiantes.Controllers
{
    public class ContactsController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Create(string search)
        {
            dbsMarkersContext db = new dbsMarkersContext();

            List<Contact> allsearch = db.Contact.Where(x => x.EmailAddress != search).Select(x => new Contact
            {
               ContactId= x.ContactId,
               IdentityNo= x.IdentityNo,
               TelephoneNo = x.TelephoneNo,
               WorkSchool= x.WorkSchool,
               HomeTelephoneNo = x.HomeTelephoneNo,
               CellphoneNo = x.CellphoneNo,
               FaxNo = x.FaxNo,
                EmailAddress = x.EmailAddress

            }).ToList();
            Debug.WriteLine(allsearch);
            return Json (allsearch);

        }
}
}