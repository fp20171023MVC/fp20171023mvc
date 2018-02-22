namespace WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transaction
    {
        [Key]
        [Required]
        public int code { get; set; }

        [Required]
        public int account_code { get; set; }

        [Required]
        public DateTime transaction_date { get; set; }

        [Required]
        public DateTime capture_date { get; set; }

        [Column(TypeName = "money")]
        public decimal amount { get; set; }

        [Required]
        [StringLength(100)]
        public string description { get; set; }

        public virtual Account Account { get; set; }
    }
}
