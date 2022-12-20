using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblChat
{
    public int Id { get; set; }

    public string? SenderId { get; set; }

    public string? RecieverId { get; set; }

    public string? SenderName { get; set; }

    public string? Message { get; set; }

    public string? Photo { get; set; }

    public DateTime? DateSent { get; set; }
}
