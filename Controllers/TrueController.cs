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


            return View();
        }
        [HttpPost]
        public IActionResult Create(TrueView model)
        {
            List<Marker> list = db.Marker.ToList();

            ViewBag.MarkerList = new SelectList(list, "IdentityNo", "Name");

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

            //Application
            Application application = new Application();
            application.IdentityNo = model.IdentityNo;
            application.Subject = model.Subject;
            application.Language = model.Language;
            application.Paper = model.Paper;
            application.Position = model.Position;
            application.CurrentPosition = model.CurrentPosition;
            application.PracticalSubject = model.PracticalSubject;
            application.PracticalExamination = model.PracticalExamination;
            db.Application.Add(application);
            db.SaveChanges();
            //Marker

            //LanguageContact
            LanguagePreference languagePreference = new LanguagePreference();
            languagePreference.IdentityNo = model.IdentityNo;
            languagePreference.LanguageDescription = model.LanguageDescription;
            db.LanguagePreference.Add(languagePreference);
            db.SaveChanges();

            //Save contact

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
            qualification.MojarSubjects = model.MojarSubjects;
            qualification.CourseLevel = model.CourseLevel;
            qualification.LevelOfDegree = model.LevelOfDegree;
            qualification.LevelOfDiploma = model.LevelOfDiploma;
            db.Qualification.Add(qualification);
            db.SaveChanges();

            //Teaching Experience

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

            //Marking Experience
            MarkingExperience markingExperience = new MarkingExperience();
            markingExperience.IdentityNo = model.IdentityNo;
            markingExperience.Subject = model.Subject;
            markingExperience.Language = model.Language;
            markingExperience.PositionHeld = model.PositionHeld;
            db.MarkingExperience.Add(markingExperience);
             db.SaveChanges();

            ApplicationDetails applicationDetails = new ApplicationDetails();
            applicationDetails.Subject = model.Subject;
            applicationDetails.Language = model.Language;
            applicationDetails.Paper = model.Paper;
            db.ApplicationDetails.Add(applicationDetails);
            db.SaveChanges();



            //Prescribe
            PrescribedWorks prescribedWorks = new PrescribedWorks();
            prescribedWorks.Drama = model.Drama;
            prescribedWorks.Novel = model.Novel;
            prescribedWorks.ShortStories = model.ShortStories;
            prescribedWorks.Poetry = model.Poetry;
            db.PrescribedWorks.Add(prescribedWorks);
            db.SaveChanges();
            //Declaration
            DeclerationByApplicant declerationByApplicant = new DeclerationByApplicant();
            declerationByApplicant.IdentityNo = model.IdentityNo;
            declerationByApplicant.Declaration = model.Declaration;
            declerationByApplicant.YearAvg = model.YearAvg;
            declerationByApplicant.TaughtByAverage = model.TaughtByAverage;
            declerationByApplicant.DistrictYear = model.DistrictYear;
            declerationByApplicant.TaughtByAverage = model.TaughtByAverage;
            declerationByApplicant.CandidatesByDistrictPercentage  = model.CandidatesByDistrictPercentage;
            declerationByApplicant.PercentageYear = model.PercentageYear;
            declerationByApplicant.ProvincePercentage = model.ProvincePercentage;
            db.DeclerationByApplicant.Add(declerationByApplicant);
            db.SaveChanges();
            //Motivation
            Motivation motivation = new Motivation();
            motivation.IdentityNo = model.IdentityNo;
            motivation.MotivationDescription = model.MotivationDescription;
            db.Motivation.Add(motivation);
            db.SaveChanges();

            // Save all the inserted records to database using
          
            return View(model);

            


        }
    }
}
