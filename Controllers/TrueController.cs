//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;

//namespace Markers_GPS_Coordiantes.Controllers
//{
//    public class TrueController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}

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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Markers_GPS_Coordiantes.Controllers
{
    public class TrueController : Controller
    {

        dbsMarkersContext db = new dbsMarkersContext();



        public IActionResult Create()
        {
            List<Marker> list = db.Marker.ToList();
      
            ViewBag.MarkerList = new SelectList(list, "IdentityNo", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(TrueView model)
        {
            List<Marker> list = db.Marker.ToList();

            ViewBag.MarkerList = new SelectList(list, "IdentityNo", "Name");
           
            Marker marker = new Marker();
            marker.Name = model.Name;
            marker.Surname = model.Surname;
            marker.Initials = model.Initials;
            marker.Title = model.Title;
            marker.MaidenName = model.MaidenName;
            marker.Gender = model.Gender;
            marker.Nationality = model.Nationality;
            db.Marker.Add(marker);
            db.SaveChanges();
            //Contact
            Contact contact = new Contact();
            contact.EmailAddress = model.EmailAddress;
            contact.TelephoneNo = model.TelephoneNo;
            contact.WorkSchool = model.WorkSchool;
            contact.HomeTelephoneNo = model.HomeTelephoneNo;
            contact.CellphoneNo = model.CellphoneNo;
            contact.FaxNo= model.FaxNo;
            db.Contact.Add(contact);
            db.SaveChanges();
            //Resindent
            Resident resident = new Resident();
            resident.ResidentialAddress = model.ResidentialAddress;
            resident.PostalCode = model.PostalCode;
            db.Resident.Add(resident);
            db.SaveChanges();
            //
            Qualification qualification = new Qualification();
            qualification.QualificationDescription = model.QualificationDescription;
            db.Qualification.Add(qualification);
            db.SaveChanges();


            return View(model);


        }
    } 
}
