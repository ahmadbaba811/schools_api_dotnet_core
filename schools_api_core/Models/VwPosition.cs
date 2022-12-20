using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class VwPosition
{
    public string? Regno { get; set; }

    public string? ClassId { get; set; }

    public string? ClassName { get; set; }

    public string? SessionId { get; set; }

    public string? SessionName { get; set; }

    public string? TermId { get; set; }

    public string? TermName { get; set; }

    public int? NumOfStudents { get; set; }

    public decimal? GrandTotal { get; set; }

    public decimal? Average { get; set; }

    public long? Position { get; set; }
}
