namespace Online_NonBaoHiem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        [Key]
        public int IdFeedback { get; set; }

        public int IdBill { get; set; }

        [Required]
        [StringLength(300)]
        public string GhiChu { get; set; }

        public virtual Bill Bill { get; set; }
    }
}
