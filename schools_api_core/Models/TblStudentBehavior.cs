using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_student_behavior")]
public partial class TblStudentBehavior
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("regno")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Regno { get; set; }

    [Column("class_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ClassId { get; set; }

    [Column("term_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TermId { get; set; }

    [Column("session_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SessionId { get; set; }

    [Column("punctuality")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Punctuality { get; set; }

    [Column("attentiveness")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Attentiveness { get; set; }

    [Column("neatness")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Neatness { get; set; }

    [Column("honesty")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Honesty { get; set; }

    [Column("selfcontrol")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Selfcontrol { get; set; }

    [Column("rel_with_others")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RelWithOthers { get; set; }

    [Column("rel_with_teachers")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RelWithTeachers { get; set; }

    [Column("form_master_comment")]
    [Unicode(false)]
    public string? FormMasterComment { get; set; }

    [Column("principal_comment")]
    [Unicode(false)]
    public string? PrincipalComment { get; set; }

    [Column("promotion")]
    public bool? Promotion { get; set; }

    [Column("date_added", TypeName = "datetime")]
    public DateTime? DateAdded { get; set; }

    [Column("added_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AddedBy { get; set; }
}
