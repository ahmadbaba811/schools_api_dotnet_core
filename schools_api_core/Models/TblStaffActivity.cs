using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_staff_activities")]
public partial class TblStaffActivity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("staff_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? StaffId { get; set; }

    [Column("audit_message")]
    [Unicode(false)]
    public string? AuditMessage { get; set; }

    [Column("category")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Category { get; set; }

    [Column("added_date", TypeName = "datetime")]
    public DateTime? AddedDate { get; set; }
}
