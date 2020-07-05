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
using System.Diagnostics;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;

namespace Markers_GPS_Coordiantes.Controllers
{
    public class TrueController : Controller
    {


        dbsMarkersContext db = new dbsMarkersContext();
        

        public IActionResult Create()
        {
            //get marker data from database
            List<Marker> markers = db.Marker.ToList();

            ViewBag.id = JsonConvert.SerializeObject(markers);
            return View();
        }

        //public ActionResult getID()
        //{
        //    List<Marker> markers = db.Marker.ToList();

        //    return Json(markers);

        //}

        public JsonResult getID()
        {
            List<Marker> markers = db.Marker.ToList();
            // do something and return Json

            return Json(db.Marker.ToList(),System.Web.Mvc.JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(TrueView model, string search)
        {
            List<Marker> list = db.Marker.ToList();
            var applicationMax = db.Application;
            var applicationDetailsMax = db.ApplicationDetails;

            ViewBag.MarkerList = new SelectList(list, "IdentityNo", "Name");

            var markerDatabase = db.Marker;


            var idNumber = markerDatabase.AsQueryable().Where(idNumber => model.IdentityNo == idNumber.IdentityNo);

            if (idNumber.Count() <= 0)
            {
                Marker marker = new Marker();
                marker.IdentityNo = model.IdentityNo;
                marker.Surname = model.Surname;
                marker.Initials = model.Initials;
                marker.Gender = model.Gender;
                marker.Race = model.Race;
                marker.Title = model.Title;
                marker.Persal = model.Persal;
                marker.MaidenName = model.MaidenName;
                marker.Nationality = model.Nationality;
                db.Marker.Add(marker);
                db.SaveChanges();
            }
            else
            {
                List<Marker> allsearch = db.Marker.Where(x => x.IdentityNo.Contains(search)).Select(x => new Marker
                {
                    IdentityNo = x.IdentityNo,
                    Surname = x.Surname
                    
                }).ToList();
            };

            //Application
            Application application = new Application();
            application.IdentityNo = model.IdentityNo;
            application.Subject = model.Subject;
            application.Language = model.Language;
            application.Paper = model.Paper;

            application.CheckedBySubjectAdvisor = model.CheckedBySubjectAdvisor;
            application.RecommendedBySubject = model.RecommendedBySubject;
            application.SelectionReason = model.SelectionReason;
            db.Application.Add(application);
            db.SaveChanges();


            ////LanguageContact
            LanguagePreference languagePreference = new LanguagePreference();
            languagePreference.IdentityNo = model.IdentityNo;
            languagePreference.LanguageDescription = model.LanguageDescription;
            db.LanguagePreference.Add(languagePreference);
            //db.SaveChanges();

            ////Save contact

            Contact contact = new Contact();
            contact.IdentityNo = model.IdentityNo;
            contact.TelephoneNo = model.TelephoneNo;
            contact.WorkSchool = model.WorkSchool;
            contact.HomeTelephoneNo = model.HomeTelephoneNo;
            contact.CellphoneNo = model.CellphoneNo;
            contact.FaxNo = model.FaxNo;
            contact.EmailAddress = model.EmailAddress;
            db.Contact.Add(contact);
            db.SaveChanges();

            //Resindent
            Resident resident = new Resident();
            resident.IdentityNo = model.IdentityNo;
            resident.ResidentialAddress = model.ResidentialAddress;
            resident.PostalCode = model.PostalCode;
            resident.Latitude = model.Latitude;
            resident.Longitude = model.Longitude;
            resident.FullResidentialAddress = model.FullResidentialAddress;
            db.Resident.Add(resident);
            db.SaveChanges();
            //currentEmployment
            CurrentEmployment currentEmployment = new CurrentEmployment();
            currentEmployment.IdentityNo = model.IdentityNo;
            currentEmployment.NameOftheSchoolOffice = model.NameOftheSchoolOffice;
            currentEmployment.CentreNumber = model.CentreNumber;
            currentEmployment.District = model.District;
            currentEmployment.CurrentPosition = model.CurrentPosition;
            currentEmployment.EmploymentType = model.EmploymentType;
            currentEmployment.Retiring = model.Retiring;
            db.CurrentEmployment.Add(currentEmployment);
            db.SaveChanges();

            //Qualification

            Qualification qualification = new Qualification();
            qualification.IdentityNo = model.IdentityNo;
            qualification.QualificationYear = model.QualificationYear;
            qualification.QualificationDescription = model.QualificationDescription;
            qualification.MajorSubjects = model.MajorSubjects;
            qualification.CourseLevel = model.CourseLevel;
            qualification.LevelOfDegree = model.LevelOfDegree;
            qualification.LevelOfDiploma = model.LevelOfDiploma;
            db.Qualification.Add(qualification);
            db.SaveChanges();

            ////Teaching Experience

            TeachingExperience teachingExperience = new TeachingExperience();
            teachingExperience.IdentityNo = model.IdentityNo;
            teachingExperience.TeachingExperience1 = model.TeachingExperience1;
            teachingExperience.ExperienceInNcsCaps = model.ExperienceInNcsCaps;
            teachingExperience.SubjectExperience = model.SubjectExperience;
            teachingExperience.Fetexperience = model.Fetexperience;
            teachingExperience.Year = model.Year;
            teachingExperience.Subject = model.Subject;
            teachingExperience.Language = model.Language;
            teachingExperience.Grade = model.Grade;
            teachingExperience.NameofschooIInstitution = model.NameofschooIInstitution;
            teachingExperience.PercentageofLearners = model.PercentageofLearners;
            db.TeachingExperience.Add(teachingExperience);
            db.SaveChanges();

            ////Marking Experience
            MarkingExperience markingExperience = new MarkingExperience();
            markingExperience.IdentityNo = model.IdentityNo;
            markingExperience.MarkingExperienceYear = model.MarkingExperienceYear;
            markingExperience.Subject = model.Subject;
            markingExperience.Language = model.Language;
            markingExperience.PositionHeld = model.PositionHeld;
            db.MarkingExperience.Add(markingExperience);
            db.SaveChanges();

            ApplicationDetails applicationDetails = new ApplicationDetails();

            ////Test


            int max = applicationMax.AsQueryable().Max(pet => pet.AppliactionId);
            applicationDetails.Subject = model.Subject;
            applicationDetails.Language = model.Language;
            applicationDetails.Paper = model.Paper;
            applicationDetails.ApplicationId = max;
            db.ApplicationDetails.Add(applicationDetails);
            db.SaveChanges();

            ////Prescribe
            PrescribedWorks prescribedWorks = new PrescribedWorks();
            int maxD = applicationDetailsMax.AsQueryable().Max(detail => detail.ApplicationDetailsId);
            prescribedWorks.ApplicationDetailsId = maxD;
            prescribedWorks.Drama = model.Drama;
            prescribedWorks.Novel = model.Novel;
            prescribedWorks.ShortStories = model.ShortStories;
            prescribedWorks.Poetry = model.Poetry;
            db.PrescribedWorks.Add(prescribedWorks);
            //db.SaveChanges();
            ////Declaration

            DeclerationByApplicant declerationByApplicant = new DeclerationByApplicant();
            declerationByApplicant.IdentityNo = model.IdentityNo;
            declerationByApplicant.Declaration = model.Declaration;
            declerationByApplicant.YearAvg = model.YearAvg;
            declerationByApplicant.TaughtByAverage = model.TaughtByAverage;
            declerationByApplicant.DistrictYear = model.DistrictYear;
            declerationByApplicant.CandidatesByDistrictPercentage = model.CandidatesByDistrictPercentage;
            declerationByApplicant.PercentageYear = model.PercentageYear;
            declerationByApplicant.ProvincePercentage = model.ProvincePercentage;
            db.DeclerationByApplicant.Add(declerationByApplicant);
            //db.SaveChanges();



            ////Motivation
            Motivation motivation = new Motivation();
            motivation.IdentityNo = model.IdentityNo;
            motivation.MotivationDescription = model.MotivationDescription;
            db.Motivation.Add(motivation);
            //db.SaveChanges();


       
            return View(model);


            }
        }
    }
