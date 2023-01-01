using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_form_masters")]
public partial class TblFormMaster
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("staff_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? StaffId { get; set; }

    [Column("class_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ClassId { get; set; }

    [Column("session_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SessionId { get; set; }

    [Column("added_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AddedBy { get; set; }

    [Column("date_added", TypeName = "date")]
    public DateTime? DateAdded { get; set; }
}
