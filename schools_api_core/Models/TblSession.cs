using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_session")]
public partial class TblSession
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("session_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SessionName { get; set; }

    [Column("status")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("start_date", TypeName = "date")]
    public DateTime? StartDate { get; set; }

    [Column("end_date", TypeName = "date")]
    public DateTime? EndDate { get; set; }

    [Column("allow_promotion")]
    public bool? AllowPromotion { get; set; }

    [Column("added_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AddedBy { get; set; }

    [Column("added_date", TypeName = "datetime")]
    public DateTime? AddedDate { get; set; }
}
