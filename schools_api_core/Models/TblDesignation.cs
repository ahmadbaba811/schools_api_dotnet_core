using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_designations")]
public partial class TblDesignation
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("designation_code")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DesignationCode { get; set; }

    [Column("designation_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DesignationName { get; set; }

    [Column("added_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AddedBy { get; set; }

    [Column("added_date", TypeName = "datetime")]
    public DateTime? AddedDate { get; set; }
}
