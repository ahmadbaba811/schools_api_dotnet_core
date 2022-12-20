using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblParent
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? Occupation { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? AddedDate { get; set; }
}
