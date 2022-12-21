using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_principal_comment")]
public partial class TblPrincipalComment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("staff_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? StaffId { get; set; }

    [Column("term_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TermId { get; set; }

    [Column("session_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SessionId { get; set; }

    [Column("comment_text")]
    [Unicode(false)]
    public string? CommentText { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [Column("added_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AddedBy { get; set; }

    [Column("added_date", TypeName = "date")]
    public DateTime? AddedDate { get; set; }
}
