using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_assign_teacher")]
public partial class TblAssignTeacher
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("staff_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? StaffId { get; set; }

    [Column("subject_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SubjectId { get; set; }

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

    [Column("date_assigned", TypeName = "datetime")]
    public DateTime? DateAssigned { get; set; }

    [Column("assigned_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AssignedBy { get; set; }
}
