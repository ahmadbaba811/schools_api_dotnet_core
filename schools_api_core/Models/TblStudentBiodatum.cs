using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_student_biodata")]
public partial class TblStudentBiodatum
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("regno")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Regno { get; set; }

    [Column("first_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [Column("middle_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MiddleName { get; set; }

    [Column("surname")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Surname { get; set; }

    [Column("class_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ClassId { get; set; }

    [Column("entry_session")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EntrySession { get; set; }

    [Column("grad_session")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GradSession { get; set; }

    [Column("subject_group")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SubjectGroup { get; set; }

    [Column("email")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("phone")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [Column("gender")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Gender { get; set; }

    [Column("date_of_birth", TypeName = "date")]
    public DateTime? DateOfBirth { get; set; }

    [Column("date_of_graduation", TypeName = "date")]
    public DateTime? DateOfGraduation { get; set; }

    [Column("password")]
    [Unicode(false)]
    public string? Password { get; set; }

    [Column("state_of_origin")]
    [StringLength(50)]
    [Unicode(false)]
    public string? StateOfOrigin { get; set; }

    [Column("lga")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Lga { get; set; }

    [Column("parent_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ParentId { get; set; }

    [Column("address")]
    [Unicode(false)]
    public string? Address { get; set; }

    [Column("passport")]
    [Unicode(false)]
    public string? Passport { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [Column("date_added", TypeName = "date")]
    public DateTime? DateAdded { get; set; }

    [Column("added_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AddedBy { get; set; }
}
