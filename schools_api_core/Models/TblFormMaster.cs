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

    [Column("full_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? FullName { get; set; }

    [Column("email")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("designation")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Designation { get; set; }

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

    [Column("added_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AddedBy { get; set; }

    [Column("date_added", TypeName = "date")]
    public DateTime? DateAdded { get; set; }
}
