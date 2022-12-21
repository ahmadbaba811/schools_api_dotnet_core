using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Keyless]
public partial class VwStudentResult
{
    [Column("regno")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Regno { get; set; }

    [Column("full_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? FullName { get; set; }

    [Column("class_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ClassName { get; set; }

    [Column("term_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TermName { get; set; }

    [Column("session_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SessionName { get; set; }

    [Column("subject_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SubjectName { get; set; }

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

    [Column("total", TypeName = "decimal(5, 4)")]
    public decimal? Total { get; set; }

    [Column("grade")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Grade { get; set; }

    [Column("comment")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Comment { get; set; }

    [Column("subject_highest", TypeName = "decimal(5, 4)")]
    public decimal? SubjectHighest { get; set; }

    [Column("subject_lowest", TypeName = "decimal(5, 4)")]
    public decimal? SubjectLowest { get; set; }

    [Column("subject_average", TypeName = "decimal(38, 6)")]
    public decimal? SubjectAverage { get; set; }

    [Column("no_in_class")]
    public int? NoInClass { get; set; }

    [Column("class_higest", TypeName = "decimal(38, 4)")]
    public decimal? ClassHigest { get; set; }

    [Column("class_lowest", TypeName = "decimal(38, 4)")]
    public decimal? ClassLowest { get; set; }

    [Column("class_average", TypeName = "decimal(38, 6)")]
    public decimal? ClassAverage { get; set; }

    [Column("students_in_class")]
    public int? StudentsInClass { get; set; }

    [Column("grand_total", TypeName = "decimal(38, 4)")]
    public decimal? GrandTotal { get; set; }

    [Column("student_average", TypeName = "decimal(38, 6)")]
    public decimal? StudentAverage { get; set; }

    [Column("student_position")]
    public long? StudentPosition { get; set; }

    [Column("cummulative_average", TypeName = "decimal(38, 6)")]
    public decimal? CummulativeAverage { get; set; }
}
