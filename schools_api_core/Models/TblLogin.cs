using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_login")]
public partial class TblLogin
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? UserId { get; set; }

    [Column("session_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SessionId { get; set; }

    [Column("status")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("login_date", TypeName = "datetime")]
    public DateTime? LoginDate { get; set; }

    [Column("ip_address")]
    [StringLength(50)]
    [Unicode(false)]
    public string? IpAddress { get; set; }

    [Column("location")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Location { get; set; }
}
