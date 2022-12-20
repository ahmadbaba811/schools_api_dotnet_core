using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblDesignation
{
    public int Id { get; set; }

    public string? DesignationCode { get; set; }

    public string? DesignationName { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? AddedDate { get; set; }
}
