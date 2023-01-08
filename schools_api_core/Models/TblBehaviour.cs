using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_behaviour")]
public partial class TblBehaviour
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("behavior_name")]
    [StringLength(150)]
    [Unicode(false)]
    public string? BehaviorName { get; set; }

    [Column("added_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AddedBy { get; set; }

    [Column("date_added", TypeName = "datetime")]
    public DateTime? DateAdded { get; set; }
}
