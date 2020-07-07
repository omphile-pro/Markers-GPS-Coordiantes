using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Qualification
    {
        public int QualificationId { get; set; }
        public string IdentityNo { get; set; }
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
        public string Subject { get; set; }
        public string LevelOfDegree { get; set; }
        public string LevelOfDiploma { get; set; }

        public virtual Marker IdentityNoNavigation { get; set; }
    }
}
