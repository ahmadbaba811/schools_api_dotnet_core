using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_chats")]
public partial class TblChat
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("sender_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SenderId { get; set; }

    [Column("reciever_id")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RecieverId { get; set; }

    [Column("sender_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SenderName { get; set; }

    [Column("message")]
    [Unicode(false)]
    public string? Message { get; set; }

    [Column("photo")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Photo { get; set; }

    [Column("date_sent", TypeName = "date")]
    public DateTime? DateSent { get; set; }
}
