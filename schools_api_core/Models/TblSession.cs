using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblSession
{
    public int Id { get; set; }

    public string? SessionName { get; set; }

    public string? Status { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool? AllowPromotion { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? AddedDate { get; set; }
}
