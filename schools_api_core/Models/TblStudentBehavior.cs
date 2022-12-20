using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblStudentBehavior
{
    public int Id { get; set; }

    public string? Regno { get; set; }

    public string? ClassId { get; set; }

    public string? TermId { get; set; }

    public string? SessionId { get; set; }

    public string? Punctuality { get; set; }

    public string? Attentiveness { get; set; }

    public string? Neatness { get; set; }

    public string? Honesty { get; set; }

    public string? Selfcontrol { get; set; }

    public string? RelWithOthers { get; set; }

    public string? RelWithTeachers { get; set; }

    public string? FormMasterComment { get; set; }

    public string? PrincipalComment { get; set; }

    public bool? Promotion { get; set; }

    public DateTime? DateAdded { get; set; }

    public string? AddedBy { get; set; }
}
