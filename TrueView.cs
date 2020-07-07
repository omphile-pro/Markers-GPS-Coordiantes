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

        public string NameofDegreeOne { get; set; }
        public string NameofDegreeTwo { get; set; }
        public string NameofDegreeThree { get; set; }
        public string DegreeYearOne { get; set; }
        public string DegreeYearTwo { get; set; }
        public string DegreeYearThree { get; set; }
        public string InstitutionOne { get; set; }
        public string InstitutionTwo { get; set; }
        public string InstitutionThree { get; set; }
        public string DegreeMajorSubjects { get; set; }
        public string DegreeMajorSubjectsTwo { get; set; }
        public string DegreeMajorSubjectsThree { get; set; }
        public string NameofDiplomaOne { get; set; }
        public string NameofDiplomaTwo { get; set; }
        public string NameofDiplomaThree { get; set; }
        public string DiplomaYearOne { get; set; }
        public string DiplomaYearTwo { get; set; }
        public string DiplomaYearThree { get; set; }
        public string DiplomainstitutionOne { get; set; }
        public string DiplomainstitutionTwo { get; set; }
        public string DiplomaMajorSubjects { get; set; }
        public string DiplomaMajorSubjectsTwo { get; set; }
        public string DiplomaMajorSubjectsThree { get; set; }
        public string AdditionalSubjectOne { get; set; }
        public string AdditionalSubjectTwo { get; set; }
        public string QualificationInstitutionOne { get; set; }
        public string QualificationInstitutionTwo { get; set; }
        public string CourseLevelOne { get; set; }
        public string CourseLevelTwo { get; set; }
        
        public string LevelOfDegree { get; set; }
        public string LevelOfDiploma { get; set; }

        //TEACHING EXPERIENCE

        public string TeachingExperience1 { get; set; }
        public string ExperienceInNcsCaps { get; set; }
        public string SubjectExperience { get; set; }
        public string Fetexperience { get; set; }
        public string Year { get; set; }
        





        public string Grade { get; set; }
        public string NameofschooIInstitution { get; set; }
        public string PercentageofLearners { get; set; }

        //MARKING EXPERIENCE
        public string PositionHeld { get; set; }
        
        public string MarkingExperience2019 { get; set; }
        public string MarkingExperience2018 { get; set; }
        public string MarkingExperience2017 { get; set; }
        public string MarkingExperience2016 { get; set; }
        public string MarkingExperience2015 { get; set; }
        public string MarkingExperience2014 { get; set; }
        public string SubjectOne { get; set; }
        public string SubjectTwo { get; set; }
        public string SubjectThree { get; set; }
        public string SubjectFour { get; set; }
        public string SubjectFive { get; set; }
        public string SubjectSix { get; set; }
        public string PositionHeldOne { get; set; }
        public string PositionHeldTwo { get; set; }
        public string PositionHeldThree { get; set; }
        public string PositionHeldFour { get; set; }
        public string PositionHeldFive { get; set; }
        public string PositionHeldSive { get; set; }




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



        //DECLARATRIONBY APPLICANT

       
        public string Year2020 { get; set; }
        public string Year2019 { get; set; }
        public string Year2018 { get; set; }
        public string Year2017 { get; set; }
        public string Year2016 { get; set; }
        public string Year2015 { get; set; }
        public string Subject2020One { get; set; }
        public string Subject2020Two { get; set; }
        public string Subject2020Three { get; set; }
        public string Subject2020Four { get; set; }
        public string Language2020One { get; set; }
        public string Language2020Two { get; set; }
        public string Language2020Three { get; set; }
        public string Language2020Four { get; set; }
        public string Grade2020One { get; set; }
        public string Grade2020Two { get; set; }
        public string Grade2020Three { get; set; }
        public string Grade2020Four { get; set; }
        public string NameOfTheInstitution2020One { get; set; }
        public string NameOfTheInstitution2020Two { get; set; }
        public string NameOfTheInstitution2020Three { get; set; }
        public string NameOfTheInstitution2020Four { get; set; }
        public string PercentagePassed2020Pone { get; set; }
        public string PercentagePassed2020Two { get; set; }
        public string PercentagePassed2020Three { get; set; }
        public string PercentagePassed2020Four { get; set; }
        public string Subject2019One { get; set; }
        public string Subject2019Two { get; set; }
        public string Subject2019Three { get; set; }
        public string Subject2019Four { get; set; }
        public string Language2019One { get; set; }
        public string Language2019Two { get; set; }
        public string Language2019Three { get; set; }
        public string Language2019Four { get; set; }
        public string Grade2019One { get; set; }
        public string Grade2019Two { get; set; }
        public string Grade2019Three { get; set; }
        public string Grade2019Four { get; set; }
        public string NameOfTheInstitution2019One { get; set; }
        public string NameOfTheInstitution2019Two { get; set; }
        public string NameOfTheInstitution2019Three { get; set; }
        public string NameOfTheInstitution2019Four { get; set; }
        public string PercentagePassed2019One { get; set; }
        public string PercentagePassed2019Two { get; set; }
        public string PercentagePassed2019Three { get; set; }
        public string PercentagePassed2019Four { get; set; }
        public string Subject2018One { get; set; }
        public string Subject2018Two { get; set; }
        public string Subject2018Three { get; set; }
        public string Subject2018Four { get; set; }
        public string Language2018One { get; set; }
        public string Language2018Two { get; set; }
        public string Language2018Three { get; set; }
        public string Language2018Four { get; set; }
        public string Grade2018One { get; set; }
        public string Grade2018Two { get; set; }
        public string Grade2018Three { get; set; }
        public string Grade2018Four { get; set; }
        public string NameOfTheInstitution2018One { get; set; }
        public string NameOfTheInstitution2018Two { get; set; }
        public string NameOfTheInstitution2018Three { get; set; }
        public string NameOfTheInstitution2018Four { get; set; }
        public string PercentagePassed2018One { get; set; }
        public string PercentagePassed2018Two { get; set; }
        public string PercentagePassed2018Three { get; set; }
        public string PercentagePassed2018Four { get; set; }
        public string Subject2017One { get; set; }
        public string Subject2017Two { get; set; }
        public string Subject2017Three { get; set; }
        public string Subject2017Four { get; set; }
        public string Language2017One { get; set; }
        public string Language2017Two { get; set; }
        public string Language2017Three { get; set; }
        public string Language2017Four { get; set; }
        public string Grade2017One { get; set; }
        public string Grade2017Two { get; set; }
        public string Grade2017Three { get; set; }
        public string Grade2017Four { get; set; }
        public string NameOfTheInstitution2017One { get; set; }
        public string NameOfTheInstitution2017Two { get; set; }
        public string NameOfTheInstitution2017Three { get; set; }
        public string NameOfTheInstitution2017Four { get; set; }
        public string PercentagePassed2017One { get; set; }
        public string PercentagePassed2017Two { get; set; }
        public string PercentagePassed2017Three { get; set; }
        public string PercentagePassed2017Four { get; set; }
        public string Subject2016One { get; set; }
        public string Subject2016Two { get; set; }
        public string Subject2016Three { get; set; }
        public string Subject2016Four { get; set; }
        public string Language2016One { get; set; }
        public string Language2016Two { get; set; }
        public string Language2016Three { get; set; }
        public string Language2016Four { get; set; }
        public string Grade2016One { get; set; }
        public string Grade2016Two { get; set; }
        public string Grade2016Three { get; set; }
        public string Grade2016Four { get; set; }
        public string NameOfTheInstitution2016One { get; set; }
        public string NameOfTheInstitution2016Two { get; set; }
        public string NameOfTheInstitution2016Three { get; set; }
        public string NameOfTheInstitution2016Four { get; set; }
        public string PercentagePassed2016One { get; set; }
        public string PercentagePassed2016Two { get; set; }
        public string PercentagePassed2016Three { get; set; }
        public string PercentagePassed2016Four { get; set; }
        public string Subject2015One { get; set; }
        public string Subject2015Two { get; set; }
        public string Subject2015Three { get; set; }
        public string Subject2015Four { get; set; }
        public string Language2015One { get; set; }
        public string Language2015Two { get; set; }
        public string Language2015Three { get; set; }
        public string Language2015Four { get; set; }
        public string Grade2015One { get; set; }
        public string Grade2015Two { get; set; }
        public string Grade2015Three { get; set; }
        public string Grade2015Four { get; set; }
        public string NameOfTheInstitution2015One { get; set; }
        public string NameOfTheInstitution2015Two { get; set; }
        public string NameOfTheInstitution2015Three { get; set; }
        public string NameOfTheInstitution2015Four { get; set; }
        public string PercentagePassed2015One { get; set; }
        public string PercentagePassed2015Two { get; set; }
        public string PercentagePassed2015Three { get; set; }
        public string PercentagePassed2015Four { get; set; }

    }


}

