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

    public  DbSet<TblAssignTeacher> TblAssignTeachers { get; set; }

    public  DbSet<TblChat> TblChats { get; set; }

    public  DbSet<TblClass> TblClasses { get; set; }

    public  DbSet<TblDesignation> TblDesignations { get; set; }

    public  DbSet<TblFormMaster> TblFormMasters { get; set; }

    public  DbSet<TblLogin> TblLogins { get; set; }

    public  DbSet<TblMessage> TblMessages { get; set; }

    public  DbSet<TblParent> TblParents { get; set; }

    public  DbSet<TblPayment> TblPayments { get; set; }

    public  DbSet<TblPrincipalComment> TblPrincipalComments { get; set; }

    public  DbSet<TblPromotion> TblPromotions { get; set; }

    public  DbSet<TblRole> TblRoles { get; set; }

    public  DbSet<TblSession> TblSessions { get; set; }

    public  DbSet<TblStaff> TblStaffs { get; set; }

    public  DbSet<TblStaffActivity> TblStaffActivities { get; set; }

    public  DbSet<TblStudentBehavior> TblStudentBehaviors { get; set; }

    public  DbSet<TblStudentBiodatum> TblStudentBiodata { get; set; }

    public  DbSet<TblStudentScore> TblStudentScores { get; set; }

    public  DbSet<TblSubject> TblSubjects { get; set; }

    public  DbSet<TblSubjectGroup> TblSubjectGroups { get; set; }

    public  DbSet<TblTerm> TblTerms { get; set; }

    public  DbSet<VwClassAverage> VwClassAverages { get; set; }

    public  DbSet<VwClassMaxMin> VwClassMaxMins { get; set; }

    public  DbSet<VwCummulativeScore> VwCummulativeScores { get; set; }

    public  DbSet<VwPosition> VwPositions { get; set; }

    public  DbSet<VwStudentResult> VwStudentResults { get; set; }

    public  DbSet<VwStudentScore> VwStudentScores { get; set; }

    public  DbSet<VwSubjectAverage> VwSubjectAverages { get; set; }

    public  DbSet<VwSubjectMaxMin> VwSubjectMaxMins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-RK4H6L4\\SA;Initial Catalog=schooldb_a121w;User ID=sa;Password=a; Encrypt= false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAssignTeacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Assign_Teacher");

            entity.ToTable("tbl_assign_teacher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("assigned_by");
            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_id");
            entity.Property(e => e.DateAssigned)
                .HasColumnType("datetime")
                .HasColumnName("date_assigned");
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_id");
            entity.Property(e => e.StaffId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("staff_id");
            entity.Property(e => e.SubjectCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("subject_category");
            entity.Property(e => e.SubjectCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("subject_code");
            entity.Property(e => e.TermId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("term_id");
        });

        modelBuilder.Entity<TblChat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_chats");

            entity.ToTable("tbl_chats");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateSent)
                .HasColumnType("date")
                .HasColumnName("date_sent");
            entity.Property(e => e.Message)
                .IsUnicode(false)
                .HasColumnName("message");
            entity.Property(e => e.Photo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("photo");
            entity.Property(e => e.RecieverId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("reciever_id");
            entity.Property(e => e.SenderId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sender_id");
            entity.Property(e => e.SenderName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sender_name");
        });

        modelBuilder.Entity<TblClass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_classes");

            entity.ToTable("tbl_classes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("added_by");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_name");
            entity.Property(e => e.DateAdded)
                .HasColumnType("date")
                .HasColumnName("date_added");
            entity.Property(e => e.Promotion).HasColumnName("promotion");
        });

        modelBuilder.Entity<TblDesignation>(entity =>
        {
            entity.ToTable("tbl_designations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("added_by");
            entity.Property(e => e.AddedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("added_date");
            entity.Property(e => e.DesignationCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("designation_code");
            entity.Property(e => e.DesignationName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("designation_name");
        });

        modelBuilder.Entity<TblFormMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_FormMasters");

            entity.ToTable("tbl_form_masters");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("added_by");
            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_name");
            entity.Property(e => e.DateAdded)
                .HasColumnType("date")
                .HasColumnName("date_added");
            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("designation");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_id");
            entity.Property(e => e.SessionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_name");
            entity.Property(e => e.StaffId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("staff_id");
        });

        modelBuilder.Entity<TblLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Log_ins");

            entity.ToTable("tbl_login");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ip_address");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.LoginDate)
                .HasColumnType("date")
                .HasColumnName("login_date");
            entity.Property(e => e.LoginTime)
                .HasPrecision(2)
                .HasColumnName("login_time");
            entity.Property(e => e.Passport)
                .IsUnicode(false)
                .HasColumnName("passport");
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_id");
        });

        modelBuilder.Entity<TblMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_message");

            entity.ToTable("tbl_message");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateSent)
                .HasColumnType("date")
                .HasColumnName("dateSent");
            entity.Property(e => e.MessageBody)
                .IsUnicode(false)
                .HasColumnName("messageBody");
            entity.Property(e => e.MessageTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("messageTitle");
            entity.Property(e => e.MsgRead).HasColumnName("msgRead");
            entity.Property(e => e.RecieverId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("recieverID");
            entity.Property(e => e.RecieverName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("recieverName");
            entity.Property(e => e.Recieverphoto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("recieverphoto");
            entity.Property(e => e.SenderId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("senderID");
            entity.Property(e => e.SenderName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("senderName");
            entity.Property(e => e.Senderphoto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("senderphoto");
            entity.Property(e => e.TimeSent)
                .HasPrecision(2)
                .HasColumnName("timeSent");
        });

        modelBuilder.Entity<TblParent>(entity =>
        {
            entity.ToTable("tbl_parents");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("added_by");
            entity.Property(e => e.AddedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("added_date");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("middle_name");
            entity.Property(e => e.Occupation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("occupation");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<TblPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Payments");

            entity.ToTable("tbl_payment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("added_by");
            entity.Property(e => e.AddedDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("added_date");
            entity.Property(e => e.Amount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("amount");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentDecription)
                .IsUnicode(false)
                .HasColumnName("payment_decription");
            entity.Property(e => e.ReceiptNumber)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("receipt_number");
            entity.Property(e => e.Regno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("regno");
        });

        modelBuilder.Entity<TblPrincipalComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Principal_comment");

            entity.ToTable("tbl_principal_comment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("added_by");
            entity.Property(e => e.AddedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("added_date");
            entity.Property(e => e.CommentText)
                .IsUnicode(false)
                .HasColumnName("comment_text");
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_id");
            entity.Property(e => e.StaffId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("staff_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TermId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("term_id");
        });

        modelBuilder.Entity<TblPromotion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_promotions");

            entity.ToTable("tbl_promotions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_id");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_added");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.PrevClassId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("prev_class_id");
            entity.Property(e => e.PromotedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("promoted_by");
            entity.Property(e => e.PromotionStatus).HasColumnName("promotion_status");
            entity.Property(e => e.Regno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("regno");
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_id");
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.ToTable("tbl_roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("added_by");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("added_date");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<TblSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_session");

            entity.ToTable("tbl_session");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("added_by");
            entity.Property(e => e.AddedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("added_date");
            entity.Property(e => e.AllowPromotion)
                .HasDefaultValueSql("((0))")
                .HasColumnName("allow_promotion");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.SessionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_name");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))")
                .HasColumnName("status");
        });

        modelBuilder.Entity<TblStaff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AutoInc");

            entity.ToTable("tbl_staff");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("added_by");
            entity.Property(e => e.AddedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("added_date");
            entity.Property(e => e.Address)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Class)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.DateOfHiring)
                .HasColumnType("date")
                .HasColumnName("date_of_hiring");
            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("designation");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Lga)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lga");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("middle_name");
            entity.Property(e => e.Passport)
                .IsUnicode(false)
                .HasColumnName("passport");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Qualification)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("qualification");
            entity.Property(e => e.StaffId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComputedColumnSql("('PAN'+right('00'+CONVERT([varchar](5),[id]),(5)))", true)
                .HasColumnName("staff_id");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<TblStaffActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_staff_Activities");

            entity.ToTable("tbl_staff_activities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedDate)
                .HasColumnType("datetime")
                .HasColumnName("added_date");
            entity.Property(e => e.AuditMessage)
                .IsUnicode(false)
                .HasColumnName("audit_message");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category");
            entity.Property(e => e.StaffId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("staff_id");
        });

        modelBuilder.Entity<TblStudentBehavior>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Student_Behavior");

            entity.ToTable("tbl_student_behavior");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("added_by");
            entity.Property(e => e.Attentiveness)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("attentiveness");
            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_id");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_added");
            entity.Property(e => e.FormMasterComment)
                .IsUnicode(false)
                .HasColumnName("form_master_comment");
            entity.Property(e => e.Honesty)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("honesty");
            entity.Property(e => e.Neatness)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("neatness");
            entity.Property(e => e.PrincipalComment)
                .IsUnicode(false)
                .HasColumnName("principal_comment");
            entity.Property(e => e.Promotion).HasColumnName("promotion");
            entity.Property(e => e.Punctuality)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("punctuality");
            entity.Property(e => e.Regno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("regno");
            entity.Property(e => e.RelWithOthers)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rel_with_others");
            entity.Property(e => e.RelWithTeachers)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rel_with_teachers");
            entity.Property(e => e.Selfcontrol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("selfcontrol");
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_id");
            entity.Property(e => e.TermId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("term_id");
        });

        modelBuilder.Entity<TblStudentBiodatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Student_BioData");

            entity.ToTable("tbl_student_biodata");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("added_by");
            entity.Property(e => e.Address)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_name");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("date_added");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.DateOfGraduation)
                .HasColumnType("date")
                .HasColumnName("date_of_graduation");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Lga)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lga");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("middle_name");
            entity.Property(e => e.ParentId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("parent_id");
            entity.Property(e => e.Passport)
                .IsUnicode(false)
                .HasColumnName("passport");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Regno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("regno");
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_id");
            entity.Property(e => e.SessionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_name");
            entity.Property(e => e.StateOfOrigin)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("state_of_origin");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.SubjectGroup)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("subject_group");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<TblStudentScore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_student_score");

            entity.ToTable("tbl_student_score");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("added_by");
            entity.Property(e => e.Ca1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ca_1");
            entity.Property(e => e.Ca2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ca_2");
            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("class_name");
            entity.Property(e => e.Comment)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_added");
            entity.Property(e => e.Exam)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("exam");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.Grade)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("grade");
            entity.Property(e => e.Regno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("regno");
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_id");
            entity.Property(e => e.SessionName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("session_name");
            entity.Property(e => e.SubjectId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("subject_id");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("subject_name");
            entity.Property(e => e.TermId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("term_id");
            entity.Property(e => e.TermName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("term_name");
            entity.Property(e => e.Test1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("test_1");
            entity.Property(e => e.Test2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("test_2");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(5, 4)")
                .HasColumnName("total");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updated_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updated_date");
        });

        modelBuilder.Entity<TblSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_subjects");

            entity.ToTable("tbl_subjects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("added_by");
            entity.Property(e => e.AddedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("added_date");
            entity.Property(e => e.SubjectCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("subject_category");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("subject_name");
        });

        modelBuilder.Entity<TblSubjectGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_student_details");

            entity.ToTable("tbl_subject_groups");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("added_by");
            entity.Property(e => e.AddedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("added_date");
            entity.Property(e => e.GroupCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("group_code");
            entity.Property(e => e.GroupName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("group_name");
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_id");
            entity.Property(e => e.SessionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_name");
            entity.Property(e => e.SubjectId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("subject_id");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("subject_name");
        });

        modelBuilder.Entity<TblTerm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_term");

            entity.ToTable("tbl_term");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("added_by");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_added");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))")
                .HasColumnName("status");
            entity.Property(e => e.TermName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("term_name");
        });

        modelBuilder.Entity<VwClassAverage>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_class_average");

            entity.Property(e => e.ClassAvg)
                .HasColumnType("decimal(38, 6)")
                .HasColumnName("class_avg");
            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_name");
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_id");
            entity.Property(e => e.SessionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_name");
            entity.Property(e => e.TermId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("term_id");
            entity.Property(e => e.TermName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("term_name");
        });

        modelBuilder.Entity<VwClassMaxMin>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_class_max_min");

            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("class_name");
            entity.Property(e => e.HighestInClass)
                .HasColumnType("decimal(38, 4)")
                .HasColumnName("highest_in_class");
            entity.Property(e => e.LowestInClass)
                .HasColumnType("decimal(38, 4)")
                .HasColumnName("lowest_in_class");
            entity.Property(e => e.NoInClass).HasColumnName("no_in_class");
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_id");
            entity.Property(e => e.SessionName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("session_name");
            entity.Property(e => e.TermId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("term_id");
            entity.Property(e => e.TermName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("term_name");
        });

        modelBuilder.Entity<VwCummulativeScore>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_cummulative_scores");

            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_id");
            entity.Property(e => e.CummAvg)
                .HasColumnType("decimal(38, 6)")
                .HasColumnName("cumm_avg");
            entity.Property(e => e.CummScore)
                .HasColumnType("decimal(38, 4)")
                .HasColumnName("cumm_score");
            entity.Property(e => e.Regno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("regno");
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_id");
        });

        modelBuilder.Entity<VwPosition>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_position");

            entity.Property(e => e.Average)
                .HasColumnType("decimal(38, 6)")
                .HasColumnName("average");
            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("class_name");
            entity.Property(e => e.GrandTotal)
                .HasColumnType("decimal(38, 4)")
                .HasColumnName("grand_total");
            entity.Property(e => e.NumOfStudents).HasColumnName("num_of_students");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Regno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("regno");
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_id");
            entity.Property(e => e.SessionName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("session_name");
            entity.Property(e => e.TermId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("term_id");
            entity.Property(e => e.TermName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("term_name");
        });

        modelBuilder.Entity<VwStudentResult>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_student_results");

            entity.Property(e => e.Ca1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ca_1");
            entity.Property(e => e.Ca2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ca_2");
            entity.Property(e => e.ClassAverage)
                .HasColumnType("decimal(38, 6)")
                .HasColumnName("class_average");
            entity.Property(e => e.ClassHigest)
                .HasColumnType("decimal(38, 4)")
                .HasColumnName("class_higest");
            entity.Property(e => e.ClassLowest)
                .HasColumnType("decimal(38, 4)")
                .HasColumnName("class_lowest");
            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_name");
            entity.Property(e => e.Comment)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.CummulativeAverage)
                .HasColumnType("decimal(38, 6)")
                .HasColumnName("cummulative_average");
            entity.Property(e => e.Exam)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("exam");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.Grade)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("grade");
            entity.Property(e => e.GrandTotal)
                .HasColumnType("decimal(38, 4)")
                .HasColumnName("grand_total");
            entity.Property(e => e.NoInClass).HasColumnName("no_in_class");
            entity.Property(e => e.Regno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("regno");
            entity.Property(e => e.SessionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_name");
            entity.Property(e => e.StudentAverage)
                .HasColumnType("decimal(38, 6)")
                .HasColumnName("student_average");
            entity.Property(e => e.StudentPosition).HasColumnName("student_position");
            entity.Property(e => e.StudentsInClass).HasColumnName("students_in_class");
            entity.Property(e => e.SubjectAverage)
                .HasColumnType("decimal(38, 6)")
                .HasColumnName("subject_average");
            entity.Property(e => e.SubjectHighest)
                .HasColumnType("decimal(5, 4)")
                .HasColumnName("subject_highest");
            entity.Property(e => e.SubjectLowest)
                .HasColumnType("decimal(5, 4)")
                .HasColumnName("subject_lowest");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("subject_name");
            entity.Property(e => e.TermName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("term_name");
            entity.Property(e => e.Test1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("test_1");
            entity.Property(e => e.Test2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("test_2");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(5, 4)")
                .HasColumnName("total");
        });

        modelBuilder.Entity<VwStudentScore>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_student_scores");

            entity.Property(e => e.Ca1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ca_1");
            entity.Property(e => e.Ca2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ca_2");
            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_name");
            entity.Property(e => e.Comment)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.Exam)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("exam");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.Grade)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("grade");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Regno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("regno");
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_id");
            entity.Property(e => e.SessionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_name");
            entity.Property(e => e.SubjectId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("subject_id");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("subject_name");
            entity.Property(e => e.TermId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("term_id");
            entity.Property(e => e.TermName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("term_name");
            entity.Property(e => e.Test1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("test_1");
            entity.Property(e => e.Test2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("test_2");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(5, 4)")
                .HasColumnName("total");
        });

        modelBuilder.Entity<VwSubjectAverage>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_subject_average");

            entity.Property(e => e.Average).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_name");
            entity.Property(e => e.Regno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("regno");
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_id");
            entity.Property(e => e.SessionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_name");
            entity.Property(e => e.TermId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("term_id");
            entity.Property(e => e.TermName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("term_name");
        });

        modelBuilder.Entity<VwSubjectMaxMin>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_subject_max_min");

            entity.Property(e => e.ClassId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_id");
            entity.Property(e => e.ClassName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("class_name");
            entity.Property(e => e.HighestInClass)
                .HasColumnType("decimal(5, 4)")
                .HasColumnName("highest_in_class");
            entity.Property(e => e.LowestInClass)
                .HasColumnType("decimal(5, 4)")
                .HasColumnName("lowest_in_class");
            entity.Property(e => e.SessionId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_id");
            entity.Property(e => e.SessionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("session_name");
            entity.Property(e => e.SubjectId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("subject_id");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("subject_name");
            entity.Property(e => e.TermId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("term_id");
            entity.Property(e => e.TermName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("term_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
