using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using schools_api_core.Models;

namespace schools_api_core.Data;

public partial class schoolDbContext : DbContext
{
    public schoolDbContext()
    {
    }

    public schoolDbContext(DbContextOptions<schoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAssignTeacher> TblAssignTeachers { get; set; }

    public virtual DbSet<TblBehaviour> TblBehaviours { get; set; }

    public virtual DbSet<TblChat> TblChats { get; set; }

    public virtual DbSet<TblClass> TblClasses { get; set; }

    public virtual DbSet<TblDesignation> TblDesignations { get; set; }

    public virtual DbSet<TblFormMaster> TblFormMasters { get; set; }

    public virtual DbSet<TblLogin> TblLogins { get; set; }

    public virtual DbSet<TblMessage> TblMessages { get; set; }

    public virtual DbSet<TblParent> TblParents { get; set; }

    public virtual DbSet<TblPayment> TblPayments { get; set; }

    public virtual DbSet<TblPrincipalComment> TblPrincipalComments { get; set; }

    public virtual DbSet<TblPromotion> TblPromotions { get; set; }

    public virtual DbSet<TblResultComment> TblResultComments { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblSession> TblSessions { get; set; }

    public virtual DbSet<TblStaff> TblStaffs { get; set; }

    public virtual DbSet<TblStaffActivity> TblStaffActivities { get; set; }

    public virtual DbSet<TblStudentBehavior> TblStudentBehaviors { get; set; }

    public virtual DbSet<TblStudentBiodatum> TblStudentBiodata { get; set; }

    public virtual DbSet<TblStudentScore> TblStudentScores { get; set; }

    public virtual DbSet<TblSubject> TblSubjects { get; set; }

    public virtual DbSet<TblSubjectGroup> TblSubjectGroups { get; set; }

    public virtual DbSet<TblTerm> TblTerms { get; set; }

    public virtual DbSet<VwClassAverage> VwClassAverages { get; set; }

    public virtual DbSet<VwClassMaxMin> VwClassMaxMins { get; set; }

    public virtual DbSet<VwCummulativeScore> VwCummulativeScores { get; set; }

    public virtual DbSet<VwPosition> VwPositions { get; set; }

    public virtual DbSet<VwStudentResult> VwStudentResults { get; set; }

    public virtual DbSet<VwStudentScore> VwStudentScores { get; set; }

    public virtual DbSet<VwSubjectAverage> VwSubjectAverages { get; set; }

    public virtual DbSet<VwSubjectMaxMin> VwSubjectMaxMins { get; set; }

    public virtual DbSet<VwTest> VwTests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-NL26F2F\\SQL_SERVER;Initial Catalog=schooldb_a121w;User ID=sa;Password=a; Encrypt= false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAssignTeacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Assign_Teacher");

            entity.Property(e => e.DateAssigned).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblBehaviour>(entity =>
        {
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblChat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_chats");
        });

        modelBuilder.Entity<TblClass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_classes");

            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblDesignation>(entity =>
        {
            entity.Property(e => e.AddedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblFormMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_FormMasters");

            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Log_ins");
        });

        modelBuilder.Entity<TblMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_message");
        });

        modelBuilder.Entity<TblParent>(entity =>
        {
            entity.Property(e => e.AddedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Payments");
        });

        modelBuilder.Entity<TblPrincipalComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Principal_comment");

            entity.Property(e => e.AddedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblPromotion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_promotions");

            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PrevClassId).IsFixedLength();
        });

        modelBuilder.Entity<TblResultComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tbl_comments");
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.Property(e => e.AddedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_session");

            entity.Property(e => e.AddedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.AllowPromotion).HasDefaultValueSql("((0))");
            entity.Property(e => e.Status).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<TblStaff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AutoInc");

            entity.Property(e => e.AddedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StaffId).HasComputedColumnSql("('ST'+right('00'+CONVERT([varchar](5),[id]),(5)))", true);
        });

        modelBuilder.Entity<TblStaffActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_staff_Activities");
        });

        modelBuilder.Entity<TblStudentBehavior>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Student_Behavior");

            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblStudentBiodatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Student_BioData");

            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblStudentScore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_student_score");

            entity.Property(e => e.ClassName).IsFixedLength();
            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SessionName).IsFixedLength();
            entity.Property(e => e.TermName).IsFixedLength();
        });

        modelBuilder.Entity<TblSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_subjects");

            entity.Property(e => e.AddedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblSubjectGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_student_details");

            entity.Property(e => e.AddedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<TblTerm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_term");

            entity.Property(e => e.DateAdded).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<VwClassAverage>(entity =>
        {
            entity.ToView("vw_class_average");
        });

        modelBuilder.Entity<VwClassMaxMin>(entity =>
        {
            entity.ToView("vw_class_max_min");

            entity.Property(e => e.ClassName).IsFixedLength();
            entity.Property(e => e.SessionName).IsFixedLength();
            entity.Property(e => e.TermName).IsFixedLength();
        });

        modelBuilder.Entity<VwCummulativeScore>(entity =>
        {
            entity.ToView("vw_cummulative_scores");
        });

        modelBuilder.Entity<VwPosition>(entity =>
        {
            entity.ToView("vw_position");

            entity.Property(e => e.ClassName).IsFixedLength();
            entity.Property(e => e.SessionName).IsFixedLength();
            entity.Property(e => e.TermName).IsFixedLength();
        });

        modelBuilder.Entity<VwStudentResult>(entity =>
        {
            entity.ToView("vw_student_results");
        });

        modelBuilder.Entity<VwStudentScore>(entity =>
        {
            entity.ToView("vw_student_scores");
        });

        modelBuilder.Entity<VwSubjectAverage>(entity =>
        {
            entity.ToView("vw_subject_average");
        });

        modelBuilder.Entity<VwSubjectMaxMin>(entity =>
        {
            entity.ToView("vw_subject_max_min");
        });

        modelBuilder.Entity<VwTest>(entity =>
        {
            entity.ToView("vw_test");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
