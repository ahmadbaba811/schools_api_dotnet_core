using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblPromotion
{
    public int Id { get; set; }

    public string? Regno { get; set; }

    public string? FullName { get; set; }

    public string? PrevClassId { get; set; }

    public string? ClassId { get; set; }

    public string? SessionId { get; set; }

    public bool? PromotionStatus { get; set; }

    public string? PromotedBy { get; set; }

    public DateTime? DateAdded { get; set; }
}
