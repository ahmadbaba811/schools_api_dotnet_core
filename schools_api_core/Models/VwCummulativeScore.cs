using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class VwCummulativeScore
{
    public string? Regno { get; set; }

    public string? ClassId { get; set; }

    public string? SessionId { get; set; }

    public decimal? CummScore { get; set; }

    public decimal? CummAvg { get; set; }
}
