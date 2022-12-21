using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_promotions")]
public partial class TblPromotion
{
    [Key]
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

    [Column("prev_class_id")]
    [StringLength(10)]
    public string? PrevClassId { get; set; }

    [Column("class_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ClassId { get; set; }

    [Column("session_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SessionId { get; set; }

    [Column("promotion_status")]
    public bool? PromotionStatus { get; set; }

    [Column("promoted_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PromotedBy { get; set; }

    [Column("date_added", TypeName = "datetime")]
    public DateTime? DateAdded { get; set; }
}
