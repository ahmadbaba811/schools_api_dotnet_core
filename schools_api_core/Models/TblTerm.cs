using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_term")]
public partial class TblTerm
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("term_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TermName { get; set; }

    [Column("start_date", TypeName = "date")]
    public DateTime? StartDate { get; set; }

    [Column("end_date", TypeName = "date")]
    public DateTime? EndDate { get; set; }

    [Column("status")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("added_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AddedBy { get; set; }

    [Column("date_added", TypeName = "datetime")]
    public DateTime? DateAdded { get; set; }
}
