namespace WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonAccount")]
    public partial class PersonAccount
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string id_number { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public string surname { get; set; }

        [Column(Order = 2)]
        [StringLength(50)]
        public string name { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string account_number { get; set; }
    }
}
