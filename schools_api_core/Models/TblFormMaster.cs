using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblFormMaster
{
    public int Id { get; set; }

    public string? StaffId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Designation { get; set; }

    public string? ClassId { get; set; }

    public string? ClassName { get; set; }

    public string? SessionId { get; set; }

    public string? SessionName { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }
}
