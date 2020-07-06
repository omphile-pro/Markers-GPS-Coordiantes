using System;
using System.Collections.Generic;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class Marker
    {
        public Marker()
        {
            Contact = new HashSet<Contact>();
            CurrentEmployment = new HashSet<CurrentEmployment>();
            DeclerationByApplicant = new HashSet<DeclerationByApplicant>();
            LanguagePreference = new HashSet<LanguagePreference>();
            MarkingExperience = new HashSet<MarkingExperience>();
            Motivation = new HashSet<Motivation>();
            Qualification = new HashSet<Qualification>();
            Resident = new HashSet<Resident>();
            TeachingExperience = new HashSet<TeachingExperience>();
        }

        public string IdentityNo { get; set; }
        public int UserId { get; set; }
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Title { get; set; }
        public string Persal { get; set; }
        public string MaidenName { get; set; }
        public string Nationality { get; set; }
        public DateTime DeletedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Users User { get; set; }
        public virtual ExistingMarkers ExistingMarkers { get; set; }
        public virtual ICollection<Contact> Contact { get; set; }
        public virtual ICollection<CurrentEmployment> CurrentEmployment { get; set; }
        public virtual ICollection<DeclerationByApplicant> DeclerationByApplicant { get; set; }
        public virtual ICollection<LanguagePreference> LanguagePreference { get; set; }
        public virtual ICollection<MarkingExperience> MarkingExperience { get; set; }
        public virtual ICollection<Motivation> Motivation { get; set; }
        public virtual ICollection<Qualification> Qualification { get; set; }
        public virtual ICollection<Resident> Resident { get; set; }
        public virtual ICollection<TeachingExperience> TeachingExperience { get; set; }
    }
}
