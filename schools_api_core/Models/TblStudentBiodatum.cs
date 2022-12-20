using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblStudentBiodatum
{
    public int Id { get; set; }

    public string? Regno { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? Surname { get; set; }

    public string? ClassId { get; set; }

    public string? ClassName { get; set; }

    public string? SessionId { get; set; }

    public string? SessionName { get; set; }

    public string? SubjectGroup { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Gender { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime? DateOfGraduation { get; set; }

    public string? Password { get; set; }

    public string? StateOfOrigin { get; set; }

    public string? Lga { get; set; }

    public string? ParentId { get; set; }

    public string? Address { get; set; }

    public string? Passport { get; set; }

    public bool? Status { get; set; }

    public DateTime? DateAdded { get; set; }

    public string? AddedBy { get; set; }
}
