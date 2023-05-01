using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Keyless]
public partial class VwStudentScore
{
    [Column("id")]
    public int Id { get; set; }

    [Column("regno")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Regno { get; set; }

    [Column("full_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? FullName { get; set; }

    [Column("ca_1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Ca1 { get; set; }

    [Column("ca_2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Ca2 { get; set; }

    [Column("test_1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Test1 { get; set; }

    [Column("test_2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Test2 { get; set; }

    [Column("exam")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Exam { get; set; }

    [Column("total", TypeName = "decimal(10, 2)")]
    public decimal? Total { get; set; }

    [Column("grade")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Grade { get; set; }

    [Column("comment")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Comment { get; set; }

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

    [Column("term_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TermId { get; set; }

    [Column("term_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TermName { get; set; }

    [Column("session_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SessionId { get; set; }

    [Column("session_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SessionName { get; set; }
}
