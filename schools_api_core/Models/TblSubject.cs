using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblSubject
{
    public int Id { get; set; }

    public string? SubjectName { get; set; }

    public string? SubjectCategory { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? AddedDate { get; set; }
}
