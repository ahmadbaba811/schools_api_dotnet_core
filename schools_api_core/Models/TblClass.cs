using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblClass
{
    public int Id { get; set; }

    public string? ClassName { get; set; }

    public string? Category { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public bool? Promotion { get; set; }
}
