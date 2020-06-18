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
          
            LanguagePreference languagePreference = new LanguagePreference();
            languagePreference.LanguageDescription = model.LanguageDescription;
            db.LanguagePreference.Add(languagePreference);
            db.SaveChanges();
            // Marker marker = new Marker();
            //marker.Name = model.Name;
            //marker.Surname = model.Surname;
            //marker.Initials = model.Initials;
            //marker.Title = model.Title;
            //marker.MaidenName = model.MaidenName;
            //marker.Gender = model.Gender;
            //marker.Nationality = model.Nationality;
            //db.Marker.Add(marker);
            //db.SaveChanges();
            ////Contact
            //Contact contact = new Contact();
            //contact.EmailAddress = model.EmailAddress;
            //contact.TelephoneNo = model.TelephoneNo;
            //contact.WorkSchool = model.WorkSchool;
            //contact.HomeTelephoneNo = model.HomeTelephoneNo;
            //contact.CellphoneNo = model.CellphoneNo;
            //contact.FaxNo= model.FaxNo;
            //db.Contact.Add(contact);
            //db.SaveChanges();
            //Resindent
            //Resident resident = new Resident();
            //resident.ResidentialAddress = model.ResidentialAddress;
            //resident.PostalCode = model.PostalCode;
            //db.Resident.Add(resident);
            //db.SaveChanges();
            ////currentEmployment
            //CurrentEmployment currentEmployment = new CurrentEmployment();
            //currentEmployment.NameOftheSchoolOffice = model.NameOftheSchoolOffice;
            //currentEmployment.CentreNumber = model.CentreNumber;
            //currentEmployment.District = model.District;
            //currentEmployment.CurrentPosition = model.CurrentPosition;
            //currentEmployment.EmploymentType = model.EmploymentType;
            //currentEmployment.Retiring = model.Retiring;
            //db.CurrentEmployment.Add(currentEmployment);
            //db.SaveChanges();
            ////Qualification

            //Qualification qualification = new Qualification();
            //qualification.Year = model.Year;
            //qualification.QualificationDescription = model.QualificationDescription;
            //qualification.MojarSubjects = model.MojarSubjects;
            //qualification.CourseLevel = model.CourseLevel;
            //qualification.LevelOfDegree = model.LevelOfDegree;
            //qualification.LevelOfDiploma = model.LevelOfDiploma;
            //db.Qualification.Add(qualification);
            //db.SaveChanges();
            ////Teaching Experience
            //TeachingExperience teachingExperience = new TeachingExperience();
            //teachingExperience.TeachingExperience1= model.TeachingExperience1;
            //teachingExperience.ExperienceInNcsCaps = model.ExperienceInNcsCaps;
            ////teachingExperience.Year =model.Year1;
            //teachingExperience.SubjectExperience = model.SubjectExperience;
            //teachingExperience.Fetexperience= model.Fetexperience;
            //db.Qualification.Add(qualification);
            //db.SaveChanges();

            //teachingExperience.Subject = model.Subject;
            //teachingExperience.Language = model.Language;
            //teachingExperience.Grade = model.Grade;
            //teachingExperience.NameofschooIInstitution = model.NameofschooIInstitution;
            //teachingExperience.Grade = model.Grade;
            //teachingExperience.PercentageofLearners = model.PercentageofLearners;
            //db.TeachingExperience.Add(teachingExperience);
            //db.SaveChanges();
            ////Marking Experience
            //MarkingExperience markingExperience  = new MarkingExperience();
            //markingExperience.Subject = model.Subject;
            //markingExperience.Language = model.Language;
            //markingExperience.PositionHeld = model.PositionHeld;
            //db.MarkingExperience.Add(markingExperience);
            //db.SaveChanges();

            //ApplicationDetails applicationDetails = new ApplicationDetails();
            //applicationDetails.Subject = model.Subject;
            //applicationDetails.Language = model.Language;
            //applicationDetails.Paper = model.Paper;
            //db.ApplicationDetails.Add(applicationDetails);
            //db.SaveChanges();
            ////Declaration
            //DeclerationByApplicant declerationByApplicant = new DeclerationByApplicant();
            //declerationByApplicant.Declaration = model.Declaration;
            //declerationByApplicant.AveragebyYear = model.AveragebyYear;
            //declerationByApplicant.ProvincePercentage = model.ProvincePercentage;
            //declerationByApplicant.PercentageYear = model.PercentageYear;
            //db.DeclerationByApplicant.Add(declerationByApplicant);
            //db.SaveChanges();

            return View(model);
            //Decareation


        }
    } 
}
