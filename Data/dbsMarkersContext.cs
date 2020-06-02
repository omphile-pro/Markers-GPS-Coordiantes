using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Markers_GPS_Coordiantes.Data
{
    public partial class dbsMarkersContext : DbContext
    {
        public dbsMarkersContext()
        {
        }

        public dbsMarkersContext(DbContextOptions<dbsMarkersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Center> Center { get; set; }
        public virtual DbSet<CenterManger> CenterManger { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Marker> Marker { get; set; }
        public virtual DbSet<MarkerExam> MarkerExam { get; set; }
        public virtual DbSet<MarkerSubjectCenter> MarkerSubjectCenter { get; set; }
        public virtual DbSet<MarkersGpscoordinates> MarkersGpscoordinates { get; set; }
        public virtual DbSet<MarkersReport> MarkersReport { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Race> Race { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersRole> UsersRole { get; set; }
        public virtual DbSet<VCenter> VCenter { get; set; }
        public virtual DbSet<VExam> VExam { get; set; }
        public virtual DbSet<VMarkersGpscoordinates> VMarkersGpscoordinates { get; set; }
        public virtual DbSet<Vsubject> Vsubject { get; set; }
        public virtual DbSet<VusersReport> VusersReport { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=197.242.147.140,1433;Database=dbsMarkers;User Id=markers_user;Password=S3rv3R_ErR0R; Trusted_Connection=True; Integrated Security=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                entity.Property(e => e.MarkerId)
                    .HasColumnName("MarkerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CenterId).HasColumnName("CenterID");

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

                entity.Property(e => e.MarkerToken).HasDefaultValueSql("(newid())");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.HasOne(d => d.Center)
                    .WithMany(p => p.Marker)
                    .HasForeignKey(d => d.CenterId)
                    .HasConstraintName("FK_Marker_Center");

                entity.HasOne(d => d.CreatedByUsers)
                    .WithMany(p => p.MarkerCreatedByUsers)
                    .HasForeignKey(d => d.CreatedByUsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Marker_CreatedByUsers");

                entity.HasOne(d => d.DeletedByUsers)
                    .WithMany(p => p.MarkerDeletedByUsers)
                    .HasForeignKey(d => d.DeletedByUsersId)
                    .HasConstraintName("FK_Marker_DeletedByUsers");

                entity.HasOne(d => d.LastModifiedByUsers)
                    .WithMany(p => p.MarkerLastModifiedByUsers)
                    .HasForeignKey(d => d.LastModifiedByUsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Marker_LastModifiedByUsers");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Marker)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Marker_Position");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.MarkerUsers)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Marker_Users");
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

                entity.Property(e => e.MarkerId).HasColumnName("MarkerID");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.MarkerExam)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarkerExam_Exam");

                entity.HasOne(d => d.Marker)
                    .WithMany(p => p.MarkerExam)
                    .HasForeignKey(d => d.MarkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarkerExam_Marker");
            });

            modelBuilder.Entity<MarkerSubjectCenter>(entity =>
            {
                entity.Property(e => e.MarkerSubjectCenterId).HasColumnName("MarkerSubjectCenterID");

                entity.Property(e => e.CenterId).HasColumnName("CenterID");

                entity.Property(e => e.CreateDate).HasColumnType("smalldatetime");

                entity.Property(e => e.MarkerId).HasColumnName("MarkerID");

                entity.Property(e => e.MarkerSubjectCenterToken).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Marker)
                    .WithMany(p => p.MarkerSubjectCenter)
                    .HasForeignKey(d => d.MarkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarkerSubject_Marker");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.MarkerSubjectCenter)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarkerSubject_Subject");
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
                    .HasMaxLength(255);

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

                entity.Property(e => e.RaceId).HasColumnName("RaceID");

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
                    .HasConstraintName("FK_MarkersGPSCoordinates_Position");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.MarkersGpscoordinates)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MarkersGPSCoordinates_Race");

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

            modelBuilder.Entity<MarkersReport>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MarkersReport");

                entity.Property(e => e.CenterDescription)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.CenterId).HasColumnName("CenterID");

                entity.Property(e => e.CenterName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CenterNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.PositionDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.Property(e => e.RaceId).HasColumnName("RaceID");

                entity.Property(e => e.RaceDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
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

                entity.HasOne(d => d.CreatedByUsers)
                    .WithMany(p => p.UsersRoleCreatedByUsers)
                    .HasForeignKey(d => d.CreatedByUsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersRole_CreatedByUsers");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UsersRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersRole_Role");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.UsersRoleUsers)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersRole_Users");
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

              

                entity.Property(e => e.HomeTelephone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdNumber)
                    .HasColumnName("ID_Number")
                    .HasMaxLength(255);

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
                    .HasMaxLength(255);

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
