using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;


namespace Markers_GPS_Coordiantes
{
    public class TrueView
    {
        public string IdentityNo { get; set; }
        public string LanguageDescription { get; set; }
        //Application

        public int AppliactionId { get; set; }
        
        public string Subject { get; set; }
        public string Language { get; set; }

      
        public string Paper { get; set; }
       
        public string LiteraturePaper { get; set; }
        public string Position { get; set; }
      
        public string PracticalSubject { get; set; }
        public string PracticalExamination { get; set; }
        public string PrescribedBook { get; set; }

        public string CheckedBySubjectAdvisor { get; set; }
        public string RecommendedBySubject { get; set; }
        public string SelectionReason { get; set; }

        //Marker
        public Guid MarkerToken { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Surname")]
        [Required(ErrorMessage = "Marker Surname Required")]
        public string Surname { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Initials")]
        [Required(ErrorMessage = "Initials Required")]
        public string Initials { get; set; }

        [Column(TypeName = "varchar(255)")]
        [DisplayName("Gender")]
        [Required(ErrorMessage = "Marker Gender is  Required")]
        public string Gender { get; set; }

        [Column(TypeName = "varchar(255)")]
        [DisplayName("Race")]
        [Required(ErrorMessage = "Marker Race is Required")]
        public string Race { get; set; }

        [Column(TypeName = "varchar(255)")]
        [DisplayName("Title")]
        [Required(ErrorMessage = "Title Is Required")]
        public string Title { get; set; }

        [Column(TypeName = "varchar(255)")]
        [DisplayName("Persal")]
        [Required(ErrorMessage = "Persal Number Is Required")]
        public string Persal { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Maiden Name")]
        [Required(ErrorMessage = "Maiden Name is Required")]
        public string MaidenName { get; set; }
        [Column(TypeName = "varchar(255)")]
        [DisplayName("Nationality")]
        [Required(ErrorMessage = "Nationality is Required")]
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

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string FullResidentialAddress { get; set; }



        //CurrentEmployement

        public string NameOftheSchoolOffice { get; set; }
        public string CentreNumber { get; set; }
        public string District { get; set; }
        public string CurrentPosition { get; set; }
        public string EmploymentType { get; set; }
        public string Retiring { get; set; }

        //Qualification

        public DateTime QualificationYear { get; set; }
        public string QualificationDescription { get; set; }
        public string MajorSubjects { get; set; }
        public string CourseLevel { get; set; }
        public string HighestQualification { get; set; }
        public string LevelOfDegree { get; set; }
        public string LevelOfDiploma { get; set; }

        //TEACHING EXPERIENCE

        public string TeachingExperience1 { get; set; }
        public string ExperienceInNcsCaps { get; set; }
        public string SubjectExperience { get; set; }
        public string Fetexperience { get; set; }
        public DateTime Year { get; set; }
        
        public string Grade { get; set; }
        public string NameofschooIInstitution { get; set; }
        public string PercentageofLearners { get; set; }

        //MARKING EXPERIENCE
        public string PositionHeld { get; set; }
        public DateTime MarkingExperienceYear { get; set; }
        public string MarkingExperienceYears { get; set; }
    //APPLICATION DETAILS
    public string Poetry { get; set; }

        public string Drama { get; set; }
        public string Novel { get; set; }
        public string ShortStories { get; set; }
        //public string Poetry { get; set; }

        //MOTIVATION

        public string MotivationDescription { get; set; }
        //DECLARATRIONBY APPLICANT

        public bool Declaration { get; set; }
        public DateTime YearAvg { get; set; }
        public string TaughtByAverage { get; set; }
        public DateTime DistrictYear { get; set; }
        public string CandidatesByDistrictPercentage { get; set; }
        public DateTime PercentageYear { get; set; }
        public string ProvincePercentage { get; set; }

    }


}

