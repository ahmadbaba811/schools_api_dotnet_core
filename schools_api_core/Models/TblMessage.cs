using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_message")]
public partial class TblMessage
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("senderID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SenderId { get; set; }

    [Column("recieverID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RecieverId { get; set; }

    [Column("senderName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SenderName { get; set; }

    [Column("recieverName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RecieverName { get; set; }

    [Column("messageTitle")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MessageTitle { get; set; }

    [Column("messageBody")]
    [Unicode(false)]
    public string? MessageBody { get; set; }

    [Column("dateSent", TypeName = "date")]
    public DateTime? DateSent { get; set; }

    [Column("timeSent")]
    [Precision(2)]
    public TimeSpan? TimeSent { get; set; }

    [Column("msgRead")]
    public bool? MsgRead { get; set; }

    [Column("recieverphoto")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Recieverphoto { get; set; }

    [Column("senderphoto")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Senderphoto { get; set; }
}
