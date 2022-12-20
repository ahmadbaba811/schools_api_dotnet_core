using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblLogin
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public string? SessionId { get; set; }

    public string? Status { get; set; }

    public DateTime? LoginDate { get; set; }

    public TimeSpan? LoginTime { get; set; }

    public string? IpAddress { get; set; }

    public string? Location { get; set; }

    public string? Passport { get; set; }
}
