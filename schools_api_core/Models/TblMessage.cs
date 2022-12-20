using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblMessage
{
    public int Id { get; set; }

    public string? SenderId { get; set; }

    public string? RecieverId { get; set; }

    public string? SenderName { get; set; }

    public string? RecieverName { get; set; }

    public string? MessageTitle { get; set; }

    public string? MessageBody { get; set; }

    public DateTime? DateSent { get; set; }

    public TimeSpan? TimeSent { get; set; }

    public bool? MsgRead { get; set; }

    public string? Recieverphoto { get; set; }

    public string? Senderphoto { get; set; }
}
