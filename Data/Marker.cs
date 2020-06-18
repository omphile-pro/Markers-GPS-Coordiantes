using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Marker
    {
        public Marker()
        {
            Application = new HashSet<Application>();
            Contact = new HashSet<Contact>();
            CurrentEmployment = new HashSet<CurrentEmployment>();
            DeclerationByApplicant = new HashSet<DeclerationByApplicant>();
            MarkerExam = new HashSet<MarkerExam>();
            MarkerSubjectCenter = new HashSet<MarkerSubjectCenter>();
            Motivation = new HashSet<Motivation>();
            Qualification = new HashSet<Qualification>();
            Resident = new HashSet<Resident>();
            TeachingExperience = new HashSet<TeachingExperience>();
        }

        public int IdentityNo { get; set; }
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

        public virtual ICollection<Application> Application { get; set; }
        public virtual ICollection<Contact> Contact { get; set; }
        public virtual ICollection<CurrentEmployment> CurrentEmployment { get; set; }
        public virtual ICollection<DeclerationByApplicant> DeclerationByApplicant { get; set; }
        public virtual ICollection<MarkerExam> MarkerExam { get; set; }
        public virtual ICollection<MarkerSubjectCenter> MarkerSubjectCenter { get; set; }
        public virtual ICollection<Motivation> Motivation { get; set; }
        public virtual ICollection<Qualification> Qualification { get; set; }
        public virtual ICollection<Resident> Resident { get; set; }
        public virtual ICollection<TeachingExperience> TeachingExperience { get; set; }
    }
}
