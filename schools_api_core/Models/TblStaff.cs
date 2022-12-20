using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblStaff
{
    public int Id { get; set; }

    public string? StaffId { get; set; }

    public string? Title { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Gender { get; set; }

    public string? State { get; set; }

    public string? Lga { get; set; }

    public string? Designation { get; set; }

    public string? Class { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime? DateOfHiring { get; set; }

    public string? Qualification { get; set; }

    public string? Address { get; set; }

    public string? Passport { get; set; }

    public bool? Status { get; set; }

    public string? Password { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? AddedDate { get; set; }
}
