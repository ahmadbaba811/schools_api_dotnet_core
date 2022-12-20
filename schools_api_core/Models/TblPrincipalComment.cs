using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblPrincipalComment
{
    public int Id { get; set; }

    public string? StaffId { get; set; }

    public string? TermId { get; set; }

    public string? SessionId { get; set; }

    public string? CommentText { get; set; }

    public bool? Status { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? AddedDate { get; set; }
}
