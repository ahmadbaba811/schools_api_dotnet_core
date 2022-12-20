using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class VwStudentResult
{
    public string? Regno { get; set; }

    public string? FullName { get; set; }

    public string? ClassName { get; set; }

    public string? TermName { get; set; }

    public string? SessionName { get; set; }

    public string? SubjectName { get; set; }

    public string? Ca1 { get; set; }

    public string? Ca2 { get; set; }

    public string? Test1 { get; set; }

    public string? Test2 { get; set; }

    public string? Exam { get; set; }

    public decimal? Total { get; set; }

    public string? Grade { get; set; }

    public string? Comment { get; set; }

    public decimal? SubjectHighest { get; set; }

    public decimal? SubjectLowest { get; set; }

    public decimal? SubjectAverage { get; set; }

    public int? NoInClass { get; set; }

    public decimal? ClassHigest { get; set; }

    public decimal? ClassLowest { get; set; }

    public decimal? ClassAverage { get; set; }

    public int? StudentsInClass { get; set; }

    public decimal? GrandTotal { get; set; }

    public decimal? StudentAverage { get; set; }

    public long? StudentPosition { get; set; }

    public decimal? CummulativeAverage { get; set; }
}
