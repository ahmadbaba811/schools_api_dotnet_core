using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class VwSubjectMaxMin
{
    public string? SubjectId { get; set; }

    public string? SubjectName { get; set; }

    public string? ClassId { get; set; }

    public string? ClassName { get; set; }

    public string? TermId { get; set; }

    public string? TermName { get; set; }

    public string? SessionId { get; set; }

    public string? SessionName { get; set; }

    public decimal? HighestInClass { get; set; }

    public decimal? LowestInClass { get; set; }
}
