using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_subject_groups")]
public partial class TblSubjectGroup
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("group_code")]
    [StringLength(50)]
    [Unicode(false)]
    public string? GroupCode { get; set; }

    [Column("group_name")]
    [StringLength(150)]
    [Unicode(false)]
    public string? GroupName { get; set; }

    [Column("session_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SessionId { get; set; }

    [Column("session_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SessionName { get; set; }

    [Column("subject_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SubjectId { get; set; }

    [Column("subject_name")]
    [StringLength(250)]
    [Unicode(false)]
    public string? SubjectName { get; set; }

    [Column("added_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AddedBy { get; set; }

    [Column("added_date", TypeName = "datetime")]
    public DateTime? AddedDate { get; set; }
}
