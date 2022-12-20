using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblAssignTeacher
{
    public int Id { get; set; }

    public string? StaffId { get; set; }

    public string? SubjectCode { get; set; }

    public string? SubjectCategory { get; set; }

    public string? ClassId { get; set; }

    public string? TermId { get; set; }

    public string? SessionId { get; set; }

    public DateTime? DateAssigned { get; set; }

    public string? AssignedBy { get; set; }
}
