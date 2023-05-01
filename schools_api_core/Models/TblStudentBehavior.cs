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

    [Column("behaviour")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Behaviour { get; set; }

    [Column("behavior_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? BehaviorId { get; set; }

    [Column("score")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Score { get; set; }

    [Column("date_added")]
    [StringLength(150)]
    [Unicode(false)]
    public string? DateAdded { get; set; }

    [Column("added_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AddedBy { get; set; }
}
