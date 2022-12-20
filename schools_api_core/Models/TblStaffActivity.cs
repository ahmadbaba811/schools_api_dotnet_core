using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblStaffActivity
{
    public int Id { get; set; }

    public string? StaffId { get; set; }

    public string? AuditMessage { get; set; }

    public string? Category { get; set; }

    public DateTime? AddedDate { get; set; }
}
