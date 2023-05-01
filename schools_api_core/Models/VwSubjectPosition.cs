using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Keyless]
public partial class VwSubjectPosition
{
    [Column("regno")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Regno { get; set; }

    [Column("subject_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SubjectId { get; set; }

    [Column("subject_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SubjectName { get; set; }

    [Column("class_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ClassId { get; set; }

    [Column("class_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ClassName { get; set; }

    [Column("session_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SessionId { get; set; }

    [Column("session_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SessionName { get; set; }

    [Column("term_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TermId { get; set; }

    [Column("term_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TermName { get; set; }

    [Column("num_of_students")]
    public int? NumOfStudents { get; set; }

    [Column("subject_total", TypeName = "decimal(38, 2)")]
    public decimal? SubjectTotal { get; set; }

    [Column("average", TypeName = "decimal(38, 6)")]
    public decimal? Average { get; set; }

    [Column("subject_position")]
    public long? SubjectPosition { get; set; }
}
