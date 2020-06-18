using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Markers_GPS_Coordiantes
{
    public class TrueView
    {
        public string Test { get; set; }
        public string LanguageDescription { get; set; }
        //Application

        public int AppliactionId { get; set; }
        public int IdentityNo { get; set; }
        public string Subject { get; set; }
        public string Langauge { get; set; }
        public string Paper { get; set; }
        public string Race { get; set; }
        public string LiteraturePaper { get; set; }
        public string Position { get; set; }
      
        public string PracticalSubject { get; set; }
        public string PracticalExamination { get; set; }
        public string PrescribedBook { get; set; }
        //Marker
        public Guid MarkerToken { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string Gender { get; set; }
        public string Title { get; set; }
        public string Persal { get; set; }
        public string MaidenName { get; set; }
        public string Nationality { get; set; }

        public DateTime? DeletedDate { get; set; }
        public int? DeletedByUsersId { get; set; }
        public int LastModifiedByUsersId { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int CreatedByUsersId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }

        //Contact
        public string TelephoneNo { get; set; }
        public string HomeTelephoneNo { get; set; }
        public string CellphoneNo { get; set; }
        public string FaxNo { get; set; }
        public string EmailAddress { get; set; }
        public string WorkSchool { get; set; }
        //Resident

        public string ResidentialAddress { get; set; }
        public string PostalCode { get; set; }


        //CurrentEmployement

        public string NameOftheSchoolOffice { get; set; }
        public string CentreNumber { get; set; }
        public string District { get; set; }
        public string CurrentPosition { get; set; }
        public string EmploymentType { get; set; }
        public string Retiring { get; set; }

        //Qualification

        public DateTime? Year { get; set; }
        public string QualificationDescription { get; set; }
        public string MojarSubjects { get; set; }
        public string CourseLevel { get; set; }
        public string HighestQualification { get; set; }
        public string LevelOfDegree { get; set; }
        public string LevelOfDiploma { get; set; }

        //TEACHING EXPERIENCE

        public string TeachingExperience1 { get; set; }
        public string ExperienceInNcsCaps { get; set; }
        public string SubjectExperience { get; set; }
        public string Fetexperience { get; set; }
  
        public string Language { get; set; }
        public string Grade { get; set; }
        public string NameofschooIInstitution { get; set; }
        public string PercentageofLearners { get; set; }

        //MARKING EXPERIENCE
        public string PositionHeld { get; set; }

        //APPLICATION DETAILS
        public string Drama { get; set; }
        public string Novel { get; set; }
        public string ShortStories { get; set; }
        public string Poetry { get; set; }

        //MOTIVATION

        public string MotivationDescription { get; set; }
        //DECLARATRIONBY APPLICANT

        public bool Declaration { get; set; }
     
        public string TaughtByAverage { get; set; }
        public DateTime AveragebyYear { get; set; }
        public string CandidatesByDescriptionPercentage { get; set; }
        public DateTime PercentageYear { get; set; }
        public string ProvincePercentage { get; set; }


    }
}
