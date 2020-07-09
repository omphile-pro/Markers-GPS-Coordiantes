﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class payMarkerContext : DbContext
    {
        public payMarkerContext()
        {
        }

        public payMarkerContext(DbContextOptions<payMarkerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<ApplicationDetails> ApplicationDetails { get; set; }
        public virtual DbSet<Center> Center { get; set; }
        public virtual DbSet<CenterManger> CenterManger { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<CurrentEmployment> CurrentEmployment { get; set; }
        public virtual DbSet<DeclerationByApplicant> DeclerationByApplicant { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<LanguagePreference> LanguagePreference { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Marker> Marker { get; set; }
        public virtual DbSet<MarkerDatabase> MarkerDatabase { get; set; }
        public virtual DbSet<MarkerExam> MarkerExam { get; set; }
        public virtual DbSet<MarkerSubjectCenter> MarkerSubjectCenter { get; set; }
        public virtual DbSet<MarkersGpscoordinates> MarkersGpscoordinates { get; set; }
        public virtual DbSet<MarkingExperience> MarkingExperience { get; set; }
        public virtual DbSet<Motivation> Motivation { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<PrescribedWorks> PrescribedWorks { get; set; }
        public virtual DbSet<Qualification> Qualification { get; set; }
        public virtual DbSet<Race> Race { get; set; }
        public virtual DbSet<Resident> Resident { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<TeachingExperience> TeachingExperience { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersRole> UsersRole { get; set; }
        public virtual DbSet<VCenter> VCenter { get; set; }
        public virtual DbSet<VExam> VExam { get; set; }
        public virtual DbSet<VMarkersGpscoordinates> VMarkersGpscoordinates { get; set; }
        public virtual DbSet<VmarkerProfile> VmarkerProfile { get; set; }
        public virtual DbSet<Vsubject> Vsubject { get; set; }
        public virtual DbSet<VusersReport> VusersReport { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=paymarkerserver.database.windows.net,1433;Database=payMarker;User Id=Lebone;Password=Ceres@20!; Trusted_Connection=True; Integrated Security=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>(entity =>
            {
                entity.HasKey(e => e.AppliactionId);

                entity.Property(e => e.AppliactionId).HasColumnName("AppliactionID");

                entity.Property(e => e.CheckedBySubjectAdvisor)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentPosition)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DanceStudiesGenre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Language)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MusicalPracticalInstruments)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Paper)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PracticalSubject)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RecommendedBySubject)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SelectionReason)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TechnicalSubject)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApplicationDetails>(entity =>
            {
                entity.Property(e => e.ApplicationDetailsId).HasColumnName("ApplicationDetailsID");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.Language)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Paper)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ApplicationDetails)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationDetails_Application");
            });

            modelBuilder.Entity<Center>(entity =>
            {
                entity.Property(e => e.CenterId).HasColumnName("CenterID");

                entity.Property(e => e.CenterName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CenterNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CenterToken).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedByUsersId).HasColumnName("CreatedByUsersID");

                entity.Property(e => e.DeletedByUsersId).HasColumnName("DeletedByUsersID");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedByUsersId).HasColumnName("LastModifiedByUsersID");

                entity.Property(e => e.LastModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 12)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 12)");

                entity.Property(e => e.Scanner)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Center)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Center_City");
            });

            modelBuilder.Entity<CenterManger>(entity =>
            {
                entity.HasKey(e => e.CenterManagerId);

                entity.Property(e => e.CenterManagerId).HasColumnName("CenterManagerID");

                entity.Property(e => e.CenterId).HasColumnName("CenterID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.HasOne(d => d.Center)
                    .WithMany(p => p.CenterManger)
                    .HasForeignKey(d => d.CenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CenterManger_Center");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.CenterManger)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CenterManger_Users");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.CellphoneNo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(225);

                entity.Property(e => e.FaxNo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.HomeTelephoneNo).HasMaxLength(225);

                entity.Property(e => e.IdentityNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TelephoneNo).HasMaxLength(10);

                entity.Property(e => e.WorkSchool)
                    .HasColumnName("Work/School")
                    .HasMaxLength(10);

                entity.HasOne(d => d.IdentityNoNavigation)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.IdentityNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_Marker");
            });

            modelBuilder.Entity<CurrentEmployment>(entity =>
            {
                entity.Property(e => e.CurrentEmploymentId).HasColumnName("CurrentEmploymentID");

                entity.Property(e => e.CentreNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentPosition)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.District)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmploymentType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NameOftheSchoolOffice)
                    .IsRequired()
                    .HasColumnName("NameOftheSchool/Office")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Retiring)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdentityNoNavigation)
                    .WithMany(p => p.CurrentEmployment)
                    .HasForeignKey(d => d.IdentityNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CurrentEmployment_Marker");
            });

            modelBuilder.Entity<DeclerationByApplicant>(entity =>
            {
                entity.HasKey(e => e.DeclareationId);

                entity.Property(e => e.DeclareationId).HasColumnName("DeclareationID");

                entity.Property(e => e.CandidatesByDistrictPercentage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Declaration)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DistrictYear).HasMaxLength(50);

                entity.Property(e => e.IdentityNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PercentageYear).HasMaxLength(50);

                entity.Property(e => e.ProvincePercentage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TaughtByAverage)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.YearAvg)
                    .HasColumnName("YearAVG")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdentityNoNavigation)
                    .WithMany(p => p.DeclerationByApplicant)
                    .HasForeignKey(d => d.IdentityNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeclerationByApplicant_Marker");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.Property(e => e.ExamId).HasColumnName("ExamID");

                entity.Property(e => e.CenterId).HasColumnName("CenterID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedByUsersId).HasColumnName("CreatedByUsersID");

                entity.Property(e => e.DeletedByUsersId).HasColumnName("DeletedByUsersID");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.ExamToken).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastModifiedByUsersId).HasColumnName("LastModifiedByUsersID");

                entity.Property(e => e.LastModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaperNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Center)
                    .WithMany(p => p.Exam)
                    .HasForeignKey(d => d.CenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exam_Center");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Exam)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Exam_Subject");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.GenderDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LanguagePreference>(entity =>
            {
                entity.Property(e => e.LanguagePreferenceId).HasColumnName("LanguagePreferenceID");

                entity.Property(e => e.IdentityNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LanguageDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdentityNoNavigation)
                    .WithMany(p => p.LanguagePreference)
                    .HasForeignKey(d => d.IdentityNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LanguagePreference_Marker");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Login");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedByUsersId).HasColumnName("CreatedByUsersID");

                entity.Property(e => e.Displayname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Loginname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UsersId)
                    .HasColumnName("UsersID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Marker>(entity =>
            {
                entity.HasKey(e => e.IdentityNo);

                entity.Property(e => e.IdentityNo).HasMaxLength(50);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Initials)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MaidenName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Persal)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Race)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Marker)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Marker_Users");
            });

            modelBuilder.Entity<MarkerDatabase>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Marker Database");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Address3)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cellphone).HasMaxLength(100);

                entity.Property(e => e.CentreName)
                    .IsRequired()
                    .HasColumnName("Centre_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.CentreNo)
                    .HasColumnName("Centre_No")
                    .HasMaxLength(100);

                entity.Property(e => e.DutyGranted)
                    .IsRequired()
                    .HasColumnName("Duty_Granted")
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HomeTel)
                    .IsRequired()
                    .HasColumnName("Home_Tel")
                    .HasMaxLength(50);

                entity.Property(e => e.IdNo)
                    .HasColumnName("Id_No")
                    .HasMaxLength(100);

                entity.Property(e => e.Initials)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PCode)
                    .HasColumnName("P_Code")
                    .HasMaxLength(100);

                entity.Property(e => e.Paper)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PersalNo)
                    .HasColumnName("Persal_No")
                    .HasMaxLength(100);

                entity.Property(e => e.Race)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SurnameIni)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WorkTel)
                    .HasColumnName("Work_Tel")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MarkerExam>(entity =>
            {
                entity.Property(e => e.MarkerExamId).HasColumnName("MarkerExamID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedByUsersId).HasColumnName("CreatedByUsersID");

                entity.Property(e => e.ExamId).HasColumnName("ExamID");

                entity.Property(e => e.LastModifiedByUsersId).HasColumnName("LastModifiedByUsersID");

                entity.Property(e => e.LastModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MarkerExamToken).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<MarkerSubjectCenter>(entity =>
            {
                entity.Property(e => e.MarkerSubjectCenterId).HasColumnName("MarkerSubjectCenterID");

                entity.Property(e => e.CenterId).HasColumnName("CenterID");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.MarkerSubjectCenterToken).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            });

            modelBuilder.Entity<MarkersGpscoordinates>(entity =>
            {
                entity.HasKey(e => e.MarkersId);

                entity.ToTable("MarkersGPSCoordinates");

                entity.Property(e => e.MarkersId)
                    .HasColumnName("MarkersID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cellphone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CenterId).HasColumnName("CenterID");

                entity.Property(e => e.CentreNumber).HasMaxLength(255);

                entity.Property(e => e.CreatedByUsersId).HasColumnName("CreatedByUsersID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExamId).HasColumnName("ExamID");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.HomeTelephone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdNumber)
                    .HasColumnName("ID_Number")
                    .HasMaxLength(50);

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 12)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 12)");

                entity.Property(e => e.PersalNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalAddress)
                    .HasColumnName("Physical_Address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RaceId)
                    .IsRequired()
                    .HasColumnName("RaceID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.Property(e => e.WorkTelephone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Center)
                    .WithMany(p => p.MarkersGpscoordinates)
                    .HasForeignKey(d => d.CenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarkersGPSCoordinates_Center");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.MarkersGpscoordinates)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarkersGPSCoordinates_Exam");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.MarkersGpscoordinates)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarkersGPSCoordinates_Gender");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.MarkersGpscoordinates)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarkersGPSCoordinates_Position1");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.MarkersGpscoordinates)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarkersGPSCoordinates_Race1");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.MarkersGpscoordinates)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarkersGPSCoordinates_Subject");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.MarkersGpscoordinates)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarkersGPSCoordinates_Users");
            });

            modelBuilder.Entity<MarkingExperience>(entity =>
            {
                entity.Property(e => e.IdentityNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MarkingExperienceYear)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PositionHeld)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Year).HasMaxLength(50);

                entity.HasOne(d => d.IdentityNoNavigation)
                    .WithMany(p => p.MarkingExperience)
                    .HasForeignKey(d => d.IdentityNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarkingExperience_Marker");
            });

            modelBuilder.Entity<Motivation>(entity =>
            {
                entity.Property(e => e.MotivationId).HasColumnName("MotivationID");

                entity.Property(e => e.IdentityNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MotivationDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdentityNoNavigation)
                    .WithMany(p => p.Motivation)
                    .HasForeignKey(d => d.IdentityNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Motivation_Marker");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.PositionDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrescribedWorks>(entity =>
            {
                entity.Property(e => e.PrescribedWorksId).HasColumnName("PrescribedWorksID");

                entity.Property(e => e.ApplicationDetailsId).HasColumnName("ApplicationDetailsID");

                entity.Property(e => e.Drama)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Novel)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Poetry)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ShortStories)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.ApplicationDetails)
                    .WithMany(p => p.PrescribedWorks)
                    .HasForeignKey(d => d.ApplicationDetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PrescribedWorks_ApplicationDetails");
            });

            modelBuilder.Entity<Qualification>(entity =>
            {
                entity.Property(e => e.QualificationId).HasColumnName("QualificationID");

                entity.Property(e => e.CourseLevel)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HighestQualification)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Institution)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LevelOfDegree)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LevelOfDiploma)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MajorSubjects)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.QualificationDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.QualificationYear)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdentityNoNavigation)
                    .WithMany(p => p.Qualification)
                    .HasForeignKey(d => d.IdentityNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Qualification_Marker");
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.Property(e => e.RaceId)
                    .HasColumnName("RaceID")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RaceDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Resident>(entity =>
            {
                entity.Property(e => e.ResidentId).HasColumnName("ResidentID");

                entity.Property(e => e.FullResidentialAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityNo).HasMaxLength(50);

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 12)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 12)");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ResidentialAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdentityNoNavigation)
                    .WithMany(p => p.Resident)
                    .HasForeignKey(d => d.IdentityNo)
                    .HasConstraintName("FK_Resident_Marker");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectToken).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<TeachingExperience>(entity =>
            {
                entity.Property(e => e.TeachingExperienceId).HasColumnName("TeachingExperienceID");

                entity.Property(e => e.ExperienceInNcsCaps)
                    .HasColumnName("ExperienceInNCS/CAPS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fetexperience)
                    .HasColumnName("FETExperience")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Grade)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Language)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NameOfSchooIorInstitution)
                    .HasColumnName("NameOfSchooIOrInstitution")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PercentageofLearners)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectExperience)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TeachingExperience1)
                    .HasColumnName("TeachingExperience")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Year).HasMaxLength(50);

                entity.HasOne(d => d.IdentityNoNavigation)
                    .WithMany(p => p.TeachingExperience)
                    .HasForeignKey(d => d.IdentityNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeachingExperience_Marker");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UserRole");

                entity.Property(e => e.Displayname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PositionDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.RoleDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.Property(e => e.UsersRoleId).HasColumnName("UsersRoleID");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.Property(e => e.CenterId).HasColumnName("CenterID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedByUsersId).HasColumnName("CreatedByUsersID");

                entity.Property(e => e.Displayname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.LastModifiedByUsersId).HasColumnName("LastModifiedByUsersID");

                entity.Property(e => e.LastModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Loginname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalAddress)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.PostalAddress)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UsersToken).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Center)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Center");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Gender");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Role");
            });

            modelBuilder.Entity<UsersRole>(entity =>
            {
                entity.Property(e => e.UsersRoleId).HasColumnName("UsersRoleID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedByUsersId).HasColumnName("CreatedByUsersID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");
            });

            modelBuilder.Entity<VCenter>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vCenter");

                entity.Property(e => e.CenterId)
                    .HasColumnName("CenterID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CenterName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CenterNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedByUsersId).HasColumnName("CreatedByUsersID");

                entity.Property(e => e.LastModifiedByUsersId).HasColumnName("LastModifiedByUsersID");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 12)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 12)");
            });

            modelBuilder.Entity<VExam>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vExam");

                entity.Property(e => e.CenterId).HasColumnName("CenterID");

                entity.Property(e => e.CenterName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CenterNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CityDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ExamId).HasColumnName("ExamID");

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 12)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 12)");

                entity.Property(e => e.PaperNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VMarkersGpscoordinates>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vMarkersGPSCoordinates");

                entity.Property(e => e.Cellphone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CenterId).HasColumnName("CenterID");

                entity.Property(e => e.CenterLatitude).HasColumnType("decimal(18, 12)");

                entity.Property(e => e.CenterLongitude).HasColumnType("decimal(18, 12)");

                entity.Property(e => e.CenterName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CenterNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CentreNumber).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Distance)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GenderDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HomeTelephone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdNumber)
                    .HasColumnName("ID_Number")
                    .HasMaxLength(50);

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 12)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 12)");

                entity.Property(e => e.MarkersId).HasColumnName("MarkersID");

                entity.Property(e => e.PaperNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PayOut)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.PersalNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalAddress)
                    .HasColumnName("Physical_Address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PositionDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.Property(e => e.WorkTelephone)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VmarkerProfile>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VMarkerProfile");

                entity.Property(e => e.CellphoneNo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CentreNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CourseLevel)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentPosition)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(225);

                entity.Property(e => e.EmploymentType)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FaxNo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FullResidentialAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HighestQualification)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HomeTelephoneNo).HasMaxLength(225);

                entity.Property(e => e.IdentityNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Initials)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Institution)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 12)");

                entity.Property(e => e.LevelOfDegree)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LevelOfDiploma)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 12)");

                entity.Property(e => e.MaidenName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MajorSubjects)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NameOftheSchoolOffice)
                    .IsRequired()
                    .HasColumnName("NameOftheSchool/Office")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Persal)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.QualificationDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.QualificationYear)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Race)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ResidentialAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Retiring)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TelephoneNo).HasMaxLength(10);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.WorkSchool)
                    .HasColumnName("Work/School")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Vsubject>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VSubject");

                entity.Property(e => e.CenterId).HasColumnName("CenterID");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdNumber)
                    .HasColumnName("ID_Number")
                    .HasMaxLength(50);

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VusersReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VUsersReport");

                entity.Property(e => e.CenterId).HasColumnName("CenterID");

                entity.Property(e => e.CenterName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CenterNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedByUsersId).HasColumnName("CreatedByUsersID");

                entity.Property(e => e.Displayname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Expr1).HasColumnType("datetime");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GenderDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Loginname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalAddress)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.PostalAddress)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.RoleDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UsersId).HasColumnName("UsersID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}