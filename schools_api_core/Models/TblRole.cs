using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblRole
{
    public int Id { get; set; }

    public string? RoleName { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? AddedDate { get; set; }
}
