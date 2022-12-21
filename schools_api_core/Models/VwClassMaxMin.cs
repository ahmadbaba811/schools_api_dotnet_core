using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Keyless]
public partial class VwClassMaxMin
{
    [Column("class_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ClassId { get; set; }

    [Column("class_name")]
    [StringLength(10)]
    public string? ClassName { get; set; }

    [Column("term_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? TermId { get; set; }

    [Column("term_name")]
    [StringLength(10)]
    public string? TermName { get; set; }

    [Column("session_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SessionId { get; set; }

    [Column("session_name")]
    [StringLength(10)]
    public string? SessionName { get; set; }

    [Column("no_in_class")]
    public int? NoInClass { get; set; }

    [Column("highest_in_class", TypeName = "decimal(38, 4)")]
    public decimal? HighestInClass { get; set; }

    [Column("lowest_in_class", TypeName = "decimal(38, 4)")]
    public decimal? LowestInClass { get; set; }
}
