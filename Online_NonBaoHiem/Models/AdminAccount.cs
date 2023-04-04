namespace Online_NonBaoHiem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminAccount")]
    public partial class AdminAccount
    {
        [Key]
        public int IdAdmin { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Pass { get; set; }

        [Required]
        [StringLength(100)]
        public string DISPLAYNAME { get; set; }

        [StringLength(100)]
        public string SDT { get; set; }

        [StringLength(100)]
        public string DIACHI { get; set; }
    }
}
