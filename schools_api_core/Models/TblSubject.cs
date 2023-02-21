using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_subjects")]
public partial class TblSubject
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("subject_code")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SubjectCode { get; set; }

    [Column("subject_name")]
    [StringLength(150)]
    [Unicode(false)]
    public string? SubjectName { get; set; }

    [Column("added_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AddedBy { get; set; }

    [Column("added_date", TypeName = "datetime")]
    public DateTime? AddedDate { get; set; }
}
