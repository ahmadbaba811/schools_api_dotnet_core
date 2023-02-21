using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_staff")]
public partial class TblStaff
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("staff_id")]
    [StringLength(7)]
    [Unicode(false)]
    public string? StaffId { get; set; }

    [Column("title")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Title { get; set; }

    [Column("first_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [Column("middle_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MiddleName { get; set; }

    [Column("surname")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Surname { get; set; }

    [Column("email")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("phone")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [Column("gender")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Gender { get; set; }

    [Column("state")]
    [StringLength(50)]
    [Unicode(false)]
    public string? State { get; set; }

    [Column("lga")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Lga { get; set; }

    [Column("designation")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Designation { get; set; }

    [Column("date_of_birth", TypeName = "date")]
    public DateTime? DateOfBirth { get; set; }

    [Column("date_of_hiring", TypeName = "date")]
    public DateTime? DateOfHiring { get; set; }

    [Column("qualification")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Qualification { get; set; }

    [Column("address")]
    [Unicode(false)]
    public string? Address { get; set; }

    [Column("passport")]
    [Unicode(false)]
    public string? Passport { get; set; }

    [Column("status")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("password")]
    [Unicode(false)]
    public string? Password { get; set; }

    [Column("added_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AddedBy { get; set; }

    [Column("added_date", TypeName = "datetime")]
    public DateTime? AddedDate { get; set; }
}
