using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models;

[Table("tbl_payment")]
public partial class TblPayment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("regno")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Regno { get; set; }

    [Column("full_name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? FullName { get; set; }

    [Column("email")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("amount")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Amount { get; set; }

    [Column("payment_date", TypeName = "datetime")]
    public DateTime? PaymentDate { get; set; }

    [Column("receipt_number")]
    [StringLength(150)]
    [Unicode(false)]
    public string? ReceiptNumber { get; set; }

    [Column("payment_decription")]
    [Unicode(false)]
    public string? PaymentDecription { get; set; }

    [Column("added_date")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AddedDate { get; set; }

    [Column("added_by")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AddedBy { get; set; }
}
