using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace gymsy.App.Models;

public partial class GymsyDbContext : DbContext
{
    public GymsyDbContext()
    {
    }

    public GymsyDbContext(DbContextOptions<GymsyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<AdminAudit> AdminAudits { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientAudit> ClientAudits { get; set; }

    public virtual DbSet<DataFisic> DataFisics { get; set; }

    public virtual DbSet<DataFisicAudit> DataFisicAudits { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<ImageAudit> ImageAudits { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<InstructorAudit> InstructorAudits { get; set; }

    public virtual DbSet<Pay> Pays { get; set; }

    public virtual DbSet<PayAudit> PayAudits { get; set; }

    public virtual DbSet<PayType> PayTypes { get; set; }

    public virtual DbSet<PayTypeAudit> PayTypeAudits { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonAudit> PersonAudits { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolAudit> RolAudits { get; set; }

    public virtual DbSet<TrainingPlan> TrainingPlans { get; set; }

    public virtual DbSet<TrainingPlanAudit> TrainingPlanAudits { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }

    public virtual DbSet<WalletAudit> WalletAudits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=JEREASUS\\MSSQLSERVER01;Database=gymsy;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PK_Admin_id_admin");

            entity.ToTable("Admin", tb => tb.HasTrigger("trg_Admin_Audit"));

            entity.Property(e => e.IdAdmin).HasColumnName("id_admin");
            entity.Property(e => e.IdPerson).HasColumnName("id_person");
            entity.Property(e => e.Recaudacion).HasColumnName("recaudacion");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Admins)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admin_id_person");
        });

        modelBuilder.Entity<AdminAudit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__Admin_Au__5AF33E33A2412711");

            entity.ToTable("Admin_Audit");

            entity.Property(e => e.AuditId).HasColumnName("audit_id");
            entity.Property(e => e.ActionDate)
                .HasColumnType("datetime")
                .HasColumnName("actionDate");
            entity.Property(e => e.ActionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("actionType");
            entity.Property(e => e.ActionUser)
                .HasMaxLength(100)
                .HasColumnName("actionUser");
            entity.Property(e => e.IdAdmin).HasColumnName("id_admin");
            entity.Property(e => e.IdPerson).HasColumnName("id_person");
            entity.Property(e => e.RecaudacionAntigua).HasColumnName("recaudacion_antigua");
            entity.Property(e => e.RecaudacionNueva).HasColumnName("recaudacion_nueva");

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.AdminAudits)
                .HasForeignKey(d => d.IdAdmin)
                .HasConstraintName("FK_AdminAudit_id_admin");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PK_Client_id_client");

            entity.ToTable("Client", tb => tb.HasTrigger("trg_Client_Audit"));

            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdPerson).HasColumnName("id_person");
            entity.Property(e => e.IdTrainingPlan).HasColumnName("id_trainingPlan");
            entity.Property(e => e.LastExpiration)
                .HasColumnType("date")
                .HasColumnName("lastExpiration");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_id_person");

            entity.HasOne(d => d.IdTrainingPlanNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdTrainingPlan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_id_triningPlan");
        });

        modelBuilder.Entity<ClientAudit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__Client_A__5AF33E33F8C9BBCA");

            entity.ToTable("Client_Audit");

            entity.Property(e => e.AuditId).HasColumnName("audit_id");
            entity.Property(e => e.ActionDate)
                .HasColumnType("datetime")
                .HasColumnName("actionDate");
            entity.Property(e => e.ActionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("actionType");
            entity.Property(e => e.ActionUser)
                .HasMaxLength(100)
                .HasColumnName("actionUser");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdPerson).HasColumnName("id_person");
            entity.Property(e => e.IdTrainingPlan).HasColumnName("id_trainingPlan");
            entity.Property(e => e.LastExpirationAntigua)
                .HasColumnType("date")
                .HasColumnName("lastExpiration_antigua");
            entity.Property(e => e.LastExpirationNueva)
                .HasColumnType("date")
                .HasColumnName("lastExpiration_nueva");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.ClientAudits)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("FK_Client_Audit_id_client");
        });

        modelBuilder.Entity<DataFisic>(entity =>
        {
            entity.HasKey(e => e.IdDataFisic).HasName("PK_DataFisic_id_dataFisic");

            entity.ToTable("DataFisic", tb => tb.HasTrigger("trg_DataFisic_Audit"));

            entity.Property(e => e.IdDataFisic).HasColumnName("id_dataFisic");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("createdAt");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.Inactive).HasColumnName("inactive");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("notes");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.DataFisics)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DataFisic_id_client");
        });

        modelBuilder.Entity<DataFisicAudit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__DataFisi__5AF33E3305C3381F");

            entity.ToTable("DataFisic_Audit");

            entity.Property(e => e.AuditId).HasColumnName("audit_id");
            entity.Property(e => e.ActionDate)
                .HasColumnType("datetime")
                .HasColumnName("actionDate");
            entity.Property(e => e.ActionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("actionType");
            entity.Property(e => e.ActionUser)
                .HasMaxLength(100)
                .HasColumnName("actionUser");
            entity.Property(e => e.CreatedAtAntigua)
                .HasColumnType("date")
                .HasColumnName("createdAt_antigua");
            entity.Property(e => e.CreatedAtNueva)
                .HasColumnType("date")
                .HasColumnName("createdAt_nueva");
            entity.Property(e => e.HeightAntigua).HasColumnName("height_antigua");
            entity.Property(e => e.HeightNueva).HasColumnName("height_nueva");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdDataFisic).HasColumnName("id_dataFisic");
            entity.Property(e => e.InactiveAntigua).HasColumnName("inactive_antigua");
            entity.Property(e => e.InactiveNueva).HasColumnName("inactive_nueva");
            entity.Property(e => e.NotesAntigua)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("notes_antigua");
            entity.Property(e => e.NotesNueva)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("notes_nueva");
            entity.Property(e => e.TitleAntigua)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title_antigua");
            entity.Property(e => e.TitleNueva)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("title_nueva");
            entity.Property(e => e.WeightAntigua).HasColumnName("weight_antigua");
            entity.Property(e => e.WeightNueva).HasColumnName("weight_nueva");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.DataFisicAudits)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DataFisic_Audit_id_client");

            entity.HasOne(d => d.IdDataFisicNavigation).WithMany(p => p.DataFisicAudits)
                .HasForeignKey(d => d.IdDataFisic)
                .HasConstraintName("FK_DataFisic_Audit_id_dataFisic");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.IdImage).HasName("PK_Image_id_image");

            entity.ToTable("Image", tb => tb.HasTrigger("trg_Image_Audit"));

            entity.Property(e => e.IdImage).HasColumnName("id_image");
            entity.Property(e => e.IdDataFisic).HasColumnName("id_dataFisic");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("imageURL");
            entity.Property(e => e.Inactive).HasColumnName("inactive");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("notes");

            entity.HasOne(d => d.IdDataFisicNavigation).WithMany(p => p.Images)
                .HasForeignKey(d => d.IdDataFisic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Image_id_dataFisic");
        });

        modelBuilder.Entity<ImageAudit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__Image_Au__5AF33E334513B819");

            entity.ToTable("Image_Audit");

            entity.Property(e => e.AuditId).HasColumnName("audit_id");
            entity.Property(e => e.ActionDate)
                .HasColumnType("datetime")
                .HasColumnName("actionDate");
            entity.Property(e => e.ActionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("actionType");
            entity.Property(e => e.ActionUser)
                .HasMaxLength(100)
                .HasColumnName("actionUser");
            entity.Property(e => e.IdDataFisic).HasColumnName("id_dataFisic");
            entity.Property(e => e.IdImage).HasColumnName("id_image");
            entity.Property(e => e.ImageUrlAntigua)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("imageURL_antigua");
            entity.Property(e => e.ImageUrlNueva)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("imageURL_nueva");
            entity.Property(e => e.InactiveAntigua).HasColumnName("inactive_antigua");
            entity.Property(e => e.InactiveNueva).HasColumnName("inactive_nueva");
            entity.Property(e => e.NotesAntigua)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("notes_antigua");
            entity.Property(e => e.NotesNueva)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("notes_nueva");

            entity.HasOne(d => d.IdDataFisicNavigation).WithMany(p => p.ImageAudits)
                .HasForeignKey(d => d.IdDataFisic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Image_Audit_id_dataFisic");

            entity.HasOne(d => d.IdImageNavigation).WithMany(p => p.ImageAudits)
                .HasForeignKey(d => d.IdImage)
                .HasConstraintName("FK_Image_Audit_id_image");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.IdInstructor).HasName("PK_Instructor_id_instructor");

            entity.ToTable("Instructor", tb => tb.HasTrigger("trg_Instructor_Audit"));

            entity.Property(e => e.IdInstructor).HasColumnName("id_instructor");
            entity.Property(e => e.IdPerson).HasColumnName("id_person");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Instructors)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Instructor_id_person");
        });

        modelBuilder.Entity<InstructorAudit>(entity =>
        {
            entity.HasKey(e => e.IdInstructor).HasName("PK__Instruct__1CCC4C12FB73B8CA");

            entity.ToTable("Instructor_Audit");

            entity.Property(e => e.IdInstructor)
                .ValueGeneratedOnAdd()
                .HasColumnName("id_instructor");
            entity.Property(e => e.IdPerson).HasColumnName("id_person");

            entity.HasOne(d => d.IdInstructorNavigation).WithOne(p => p.InstructorAudit)
                .HasForeignKey<InstructorAudit>(d => d.IdInstructor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Instructor_Audit_id_instructor");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.InstructorAudits)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Instructor_Audit_id_person");
        });

        modelBuilder.Entity<Pay>(entity =>
        {
            entity.HasKey(e => e.IdPay).HasName("PK_Pay_id_pay");

            entity.ToTable("Pay", tb => tb.HasTrigger("trg_Pay_Audit"));

            entity.Property(e => e.IdPay).HasColumnName("id_pay");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("createdAt");
            entity.Property(e => e.DestinatarioId).HasColumnName("destinatario_id");
            entity.Property(e => e.IdPayType).HasColumnName("id_payType");
            entity.Property(e => e.Inactive).HasColumnName("inactive");
            entity.Property(e => e.RemitenteId).HasColumnName("remitente_id");

            entity.HasOne(d => d.Destinatario).WithMany(p => p.PayDestinatarios)
                .HasForeignKey(d => d.DestinatarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pay_id_personDes");

            entity.HasOne(d => d.IdPayTypeNavigation).WithMany(p => p.Pays)
                .HasForeignKey(d => d.IdPayType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pay_id_payType");

            entity.HasOne(d => d.Remitente).WithMany(p => p.PayRemitentes)
                .HasForeignKey(d => d.RemitenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pay_id_personRem");
        });

        modelBuilder.Entity<PayAudit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__Pay_Audi__5AF33E338442FDC5");

            entity.ToTable("Pay_Audit");

            entity.Property(e => e.AuditId).HasColumnName("audit_id");
            entity.Property(e => e.ActionDate)
                .HasColumnType("datetime")
                .HasColumnName("actionDate");
            entity.Property(e => e.ActionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("actionType");
            entity.Property(e => e.ActionUser)
                .HasMaxLength(100)
                .HasColumnName("actionUser");
            entity.Property(e => e.AmountAntigua).HasColumnName("amount_antigua");
            entity.Property(e => e.AmountNueva).HasColumnName("amount_nueva");
            entity.Property(e => e.CreatedAtAntigua)
                .HasColumnType("date")
                .HasColumnName("createdAt_antigua");
            entity.Property(e => e.CreatedAtNueva)
                .HasColumnType("date")
                .HasColumnName("createdAt_nueva");
            entity.Property(e => e.DestinatarioId).HasColumnName("destinatario_id");
            entity.Property(e => e.IdPay).HasColumnName("id_pay");
            entity.Property(e => e.IdPayType).HasColumnName("id_payType");
            entity.Property(e => e.InactiveAntigua).HasColumnName("inactive_antigua");
            entity.Property(e => e.InactiveNueva).HasColumnName("inactive_nueva");
            entity.Property(e => e.RemitenteId).HasColumnName("remitente_id");

            entity.HasOne(d => d.Destinatario).WithMany(p => p.PayAuditDestinatarios)
                .HasForeignKey(d => d.DestinatarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pay_Audit_destinatario_id");

            entity.HasOne(d => d.IdPayNavigation).WithMany(p => p.PayAudits)
                .HasForeignKey(d => d.IdPay)
                .HasConstraintName("FK_Pay_Audit_id_pay");

            entity.HasOne(d => d.IdPayTypeNavigation).WithMany(p => p.PayAudits)
                .HasForeignKey(d => d.IdPayType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pay_Audit_id_payType");

            entity.HasOne(d => d.Remitente).WithMany(p => p.PayAuditRemitentes)
                .HasForeignKey(d => d.RemitenteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pay_Audit_remitente_id");
        });

        modelBuilder.Entity<PayType>(entity =>
        {
            entity.HasKey(e => e.IdPayType).HasName("PK_PayType_id_payType");

            entity.ToTable("PayType", tb => tb.HasTrigger("trg_PayType_Audit"));

            entity.Property(e => e.IdPayType).HasColumnName("id_payType");
            entity.Property(e => e.Inactive).HasColumnName("inactive");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<PayTypeAudit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__PayType___5AF33E338E876567");

            entity.ToTable("PayType_Audit");

            entity.Property(e => e.AuditId).HasColumnName("audit_id");
            entity.Property(e => e.ActionDate)
                .HasColumnType("datetime")
                .HasColumnName("actionDate");
            entity.Property(e => e.ActionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("actionType");
            entity.Property(e => e.ActionUser)
                .HasMaxLength(100)
                .HasColumnName("actionUser");
            entity.Property(e => e.IdPayType).HasColumnName("id_payType");
            entity.Property(e => e.InactiveAntigua).HasColumnName("inactive_antigua");
            entity.Property(e => e.InactiveNueva).HasColumnName("inactive_nueva");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.IdPayTypeNavigation).WithMany(p => p.PayTypeAudits)
                .HasForeignKey(d => d.IdPayType)
                .HasConstraintName("FK_PayType_Audit_id_payType");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.IdPerson).HasName("PK_Person_id_person");

            entity.ToTable("Person", tb => tb.HasTrigger("trg_Person_Audit"));

            entity.HasIndex(e => e.Nickname, "Q_Person_nickname").IsUnique();

            entity.Property(e => e.IdPerson).HasColumnName("id_person");
            entity.Property(e => e.Avatar)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("avatar");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("birthday");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("createdAt");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.Inactive).HasColumnName("inactive");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nickname)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("nickname");
            entity.Property(e => e.NumberPhone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RolId).HasColumnName("rol_id");

            entity.HasOne(d => d.Rol).WithMany(p => p.People)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Person_id_person");
        });

        modelBuilder.Entity<PersonAudit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__Person_A__5AF33E3375EB044C");

            entity.ToTable("Person_Audit");

            entity.Property(e => e.AuditId).HasColumnName("audit_id");
            entity.Property(e => e.ActionDate)
                .HasColumnType("datetime")
                .HasColumnName("actionDate");
            entity.Property(e => e.ActionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("actionType");
            entity.Property(e => e.ActionUser)
                .HasMaxLength(100)
                .HasColumnName("actionUser");
            entity.Property(e => e.AvatarAntigua)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("avatar_antigua");
            entity.Property(e => e.AvatarNueva)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("avatar_nueva");
            entity.Property(e => e.BirthdayAntigua)
                .HasColumnType("date")
                .HasColumnName("birthday_antigua");
            entity.Property(e => e.BirthdayNueva)
                .HasColumnType("date")
                .HasColumnName("birthday_nueva");
            entity.Property(e => e.CreatedAtAntigua)
                .HasColumnType("date")
                .HasColumnName("createdAt_antigua");
            entity.Property(e => e.CreatedAtNueva)
                .HasColumnType("date")
                .HasColumnName("createdAt_nueva");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.GenderAntigua)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender_antigua");
            entity.Property(e => e.GenderNueva)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("gender_nueva");
            entity.Property(e => e.IdPerson).HasColumnName("id_person");
            entity.Property(e => e.InactiveAntigua).HasColumnName("inactive_antigua");
            entity.Property(e => e.InactiveNueva).HasColumnName("inactive_nueva");
            entity.Property(e => e.LastNameAntigua)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LastName_antigua");
            entity.Property(e => e.LastNameNueva)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LastName_nueva");
            entity.Property(e => e.NicknameAntigua)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("nickname_antigua");
            entity.Property(e => e.NicknameNueva)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("nickname_nueva");
            entity.Property(e => e.NumberPhoneAntigua)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NumberPhone_antigua");
            entity.Property(e => e.NumberPhoneNueva)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NumberPhone_nueva");
            entity.Property(e => e.PasswordAntigua)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("password_antigua");
            entity.Property(e => e.PasswordNueva)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("password_nueva");
            entity.Property(e => e.RolId).HasColumnName("rol_id");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.PersonAudits)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK_Person_Audit_id_person");

            entity.HasOne(d => d.Rol).WithMany(p => p.PersonAudits)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Person_Audit_rol_id");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK_Rol_idRol");

            entity.ToTable("Rol", tb => tb.HasTrigger("trg_Rol_Audit"));

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Inactive).HasColumnName("inactive");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<RolAudit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__Rol_Audi__5AF33E3393C910E3");

            entity.ToTable("Rol_Audit");

            entity.Property(e => e.AuditId).HasColumnName("audit_id");
            entity.Property(e => e.ActionDate)
                .HasColumnType("datetime")
                .HasColumnName("actionDate");
            entity.Property(e => e.ActionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("actionType");
            entity.Property(e => e.ActionUser)
                .HasMaxLength(100)
                .HasColumnName("actionUser");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.InactiveAntigua).HasColumnName("inactive_antigua");
            entity.Property(e => e.InactiveNueva).HasColumnName("inactive_nueva");
            entity.Property(e => e.NameAntigua)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name_antigua");
            entity.Property(e => e.NameNueva)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name_nueva");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolAudits)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK_Rol_Audit_id_rol");
        });

        modelBuilder.Entity<TrainingPlan>(entity =>
        {
            entity.HasKey(e => e.IdTrainingPlan).HasName("PK_TrainingPlan_id_trainingPlan");

            entity.ToTable("TrainingPlan", tb => tb.HasTrigger("trg_TrainingPlan_Audit"));

            entity.Property(e => e.IdTrainingPlan).HasColumnName("id_trainingPlan");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IdInstructor).HasColumnName("id_instructor");
            entity.Property(e => e.Inactive).HasColumnName("inactive");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.IdInstructorNavigation).WithMany(p => p.TrainingPlans)
                .HasForeignKey(d => d.IdInstructor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrainingPlan_id_instructor");
        });

        modelBuilder.Entity<TrainingPlanAudit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__Training__5AF33E3360477CE6");

            entity.ToTable("TrainingPlan_Audit");

            entity.Property(e => e.AuditId).HasColumnName("audit_id");
            entity.Property(e => e.ActionDate)
                .HasColumnType("datetime")
                .HasColumnName("actionDate");
            entity.Property(e => e.ActionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("actionType");
            entity.Property(e => e.ActionUser)
                .HasMaxLength(100)
                .HasColumnName("actionUser");
            entity.Property(e => e.DescriptionAntigua)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description_antigua");
            entity.Property(e => e.DescriptionNueva)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description_nueva");
            entity.Property(e => e.IdInstructor).HasColumnName("id_instructor");
            entity.Property(e => e.IdTrainingPlan).HasColumnName("id_trainingPlan");
            entity.Property(e => e.InactiveAntigua).HasColumnName("inactive_antigua");
            entity.Property(e => e.InactiveNueva).HasColumnName("inactive_nueva");
            entity.Property(e => e.PriceAntigua).HasColumnName("price_antigua");
            entity.Property(e => e.PriceNueva).HasColumnName("price_nueva");

            entity.HasOne(d => d.IdInstructorNavigation).WithMany(p => p.TrainingPlanAudits)
                .HasForeignKey(d => d.IdInstructor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TrainingPlan_Audit_id_instructor");

            entity.HasOne(d => d.IdTrainingPlanNavigation).WithMany(p => p.TrainingPlanAudits)
                .HasForeignKey(d => d.IdTrainingPlan)
                .HasConstraintName("FK_TrainingPlan_Audit_id_trainingPlan");
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.HasKey(e => e.IdWallet).HasName("PK_Wallet_id_wallet");

            entity.ToTable("Wallet", tb => tb.HasTrigger("trg_Wallet_Audit"));

            entity.Property(e => e.IdWallet).HasColumnName("id_wallet");
            entity.Property(e => e.IdPerson).HasColumnName("id_person");
            entity.Property(e => e.Inactive).HasColumnName("inactive");
            entity.Property(e => e.Retirable).HasColumnName("retirable");
            entity.Property(e => e.Total).HasColumnName("total");

            entity.Property(e => e.CBU)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CBU");


            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Wallets)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wallet_id_person");
        });

        modelBuilder.Entity<WalletAudit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__Wallet_A__5AF33E33638F8F67");

            entity.ToTable("Wallet_Audit");

            entity.Property(e => e.AuditId).HasColumnName("audit_id");
            entity.Property(e => e.ActionDate)
                .HasColumnType("datetime")
                .HasColumnName("actionDate");
            entity.Property(e => e.ActionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("actionType");
            entity.Property(e => e.ActionUser)
                .HasMaxLength(100)
                .HasColumnName("actionUser");
            entity.Property(e => e.IdPerson).HasColumnName("id_person");
            entity.Property(e => e.IdWallet).HasColumnName("id_wallet");
            entity.Property(e => e.InactiveAntigua).HasColumnName("inactive_antigua");
            entity.Property(e => e.InactiveNueva).HasColumnName("inactive_nueva");
            entity.Property(e => e.RetirableAntigua).HasColumnName("retirable_antigua");
            entity.Property(e => e.RetirableNueva).HasColumnName("retirable_nueva");
            entity.Property(e => e.TotalAntigua).HasColumnName("total_antigua");
            entity.Property(e => e.TotalNueva).HasColumnName("total_nueva");
            entity.Property(e => e.CBU_antigua).HasColumnName("CBU_antigua");
            entity.Property(e => e.CBU_nueva).HasColumnName("CBU_nueva");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.WalletAudits)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wallet_Audit_id_person");

            entity.HasOne(d => d.IdWalletNavigation).WithMany(p => p.WalletAudits)
                .HasForeignKey(d => d.IdWallet)
                .HasConstraintName("FK_Wallet_Audit_id_wallet");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
