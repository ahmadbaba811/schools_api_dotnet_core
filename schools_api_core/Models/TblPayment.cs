using System;
using System.Collections.Generic;

namespace schools_api_core.Models;

public partial class TblPayment
{
    public int Id { get; set; }

    public string? Regno { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? ReceiptNumber { get; set; }

    public string? PaymentDecription { get; set; }

    public string? AddedDate { get; set; }

    public string? AddedBy { get; set; }
}
