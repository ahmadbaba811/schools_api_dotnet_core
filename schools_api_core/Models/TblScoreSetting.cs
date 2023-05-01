using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_score_settings")]
public partial class TblScoreSetting
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("ca1")]
    public double? Ca1 { get; set; }

    [Column("ca2")]
    public double? Ca2 { get; set; }

    [Column("test1")]
    public double? Test1 { get; set; }

    [Column("test2")]
    public double? Test2 { get; set; }

    [Column("exam")]
    public double? Exam { get; set; }

    [Column("term_id")]
    public int? TermId { get; set; }

    [Column("session_id")]
    public int? SessionId { get; set; }

    [Column("added_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AddedBy { get; set; }

    [Column("added_date", TypeName = "datetime")]
    public DateTime? AddedDate { get; set; }
}
