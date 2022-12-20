using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblSubjectGroup
{
    public int Id { get; set; }

    public string? GroupCode { get; set; }

    public string? GroupName { get; set; }

    public string? SessionId { get; set; }

    public string? SessionName { get; set; }

    public string? SubjectId { get; set; }

    public string? SubjectName { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? AddedDate { get; set; }
}
