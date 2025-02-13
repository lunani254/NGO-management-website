using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ESSMaterWebApp.Models;

public partial class MaterDBContext : IdentityDbContext
{
    //---------------------------------------------------------------------//
    /// <summary>
    /// Default constructor.
    /// </summary>
    public MaterDBContext()
    {

    }

    //---------------------------------------------------------------------//
    /// <summary>
    /// Constructor with options.
    /// </summary>
    /// <param name="options"></param>
    public MaterDBContext(DbContextOptions<MaterDBContext> options)
        : base(options)
    {

    }

    /// <summary>
    /// Appointments table.
    /// </summary>
    public virtual DbSet<Appointment> Appointments { get; set; }

    /// <summary>
    /// Diagnoses table.
    /// </summary>
    public virtual DbSet<Diagnosis> Diagnoses { get; set; }

    /// <summary>
    /// DonationInterests table.
    /// </summary>
    public virtual DbSet<DonationInterest> DonationInterests { get; set; }

    /// <summary>
    /// Employees table.
    /// </summary>
    public virtual DbSet<Employee> Employees { get; set; }

    /// <summary>
    /// MediaContents table.
    /// </summary>
    public virtual DbSet<MediaContent> MediaContents { get; set; }

    /// <summary>
    /// Questions table.
    /// </summary>
    public virtual DbSet<Question> Questions { get; set; }

    /// <summary>
    /// Questionnaires table.
    /// </summary>
    public virtual DbSet<Questionnaire> Questionnaires { get; set; }

    /// <summary>
    /// Responses table.
    /// </summary>
    public virtual DbSet<Response> Responses { get; set; }

    //---------------------------------------------------------------------//
    /// <summary>
    /// OnModelCreating method.
    /// NOTE: This method is used to configure the database schema.
    /// (Not really sure if this peace of code should still be here or not,
    /// from what I could understand this was only used when the database was 
    /// being created or something of that nature, [Ask Victor for clarifivation])
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointment");

            entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
        });

        

        modelBuilder.Entity<Diagnosis>(entity =>
        {
            entity.ToTable("Diagnosis");

            entity.HasOne(d => d.DiagnosisQuestionnaire).WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.DiagnosisQuestionnaireId)
                .HasConstraintName("FK_Diagnosis_Questionnaire");
        });

        modelBuilder.Entity<DonationInterest>(entity =>
        {
            entity.HasKey(e => e.DonationId).HasName("PK_DonationInterests");

            entity.ToTable("DonationInterest");

            entity.Property(e => e.DonationId).HasColumnName("DonationID");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");
        });

        modelBuilder.Entity<MediaContent>(entity =>
        {
            entity.HasKey(e => e.MediaId);

            entity.ToTable("MediaContent");

            entity.Property(e => e.Url).HasColumnName("URL");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.ToTable("Question");
        });

        modelBuilder.Entity<Questionnaire>(entity =>
        {
            entity.ToTable("Questionnaire");
        });

        modelBuilder.Entity<Response>(entity =>
        {
            entity.ToTable("Response");

            entity.Property(e => e.Response1).HasColumnName("Response");

            entity.HasOne(d => d.ResponseQuestion).WithMany(p => p.Responses)
                .HasForeignKey(d => d.ResponseQuestionId)
                .HasConstraintName("FK_Response_Question");

            entity.HasOne(d => d.ResponseQuestionnaire).WithMany(p => p.Responses)
                .HasForeignKey(d => d.ResponseQuestionnaireId)
                .HasConstraintName("FK_Response_Questionnaire1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    /// <summary>
    /// OnModelCreatingPartial method.
    /// </summary>
    /// <param name="modelBuilder"></param>
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
//**------------------------------------------------------------< END >------------------------------------------------------------**// 