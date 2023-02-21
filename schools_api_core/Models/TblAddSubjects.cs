using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace schools_api_core.Models
{
    [Table("tbl_addSubjects")]
    public partial class TblAddSubjects
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("Subject")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Subject { get; set; }

        [Column("added_by")]
        [StringLength(50)]
        [Unicode(false)]
        public string? added_by { get; set; }

        [Column("date_added")]
        [StringLength(50)]
        [Unicode(false)]
        public string? date_added { get; set; }

    }

}
