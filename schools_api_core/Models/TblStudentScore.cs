using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblStudentScore
{
    public int Id { get; set; }

    public string? Regno { get; set; }

    public string? FullName { get; set; }

    public string? SubjectId { get; set; }

    public string? SubjectName { get; set; }

    public string? ClassId { get; set; }

    public string? ClassName { get; set; }

    public string? TermId { get; set; }

    public string? TermName { get; set; }

    public string? SessionId { get; set; }

    public string? SessionName { get; set; }

    public string? Ca1 { get; set; }

    public string? Ca2 { get; set; }

    public string? Test1 { get; set; }

    public string? Test2 { get; set; }

    public string? Exam { get; set; }

    public decimal? Total { get; set; }

    public string? Grade { get; set; }

    public string? Comment { get; set; }

    public string? AddedBy { get; set; }

    public DateTime? DateAdded { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedBy { get; set; }
}
