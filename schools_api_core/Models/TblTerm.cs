using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblTerm
{
    public int Id { get; set; }

    public string? TermName { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Status { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }
}
