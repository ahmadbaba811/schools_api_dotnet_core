using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_parents")]
public partial class TblParent
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("first_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [Column("middle_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MiddleName { get; set; }

    [Column("last_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [Column("address")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Address { get; set; }

    [Column("occupation")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Occupation { get; set; }

    [Column("email")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("phone_number")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [Column("added_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AddedBy { get; set; }

    [Column("added_date", TypeName = "datetime")]
    public DateTime? AddedDate { get; set; }
}
