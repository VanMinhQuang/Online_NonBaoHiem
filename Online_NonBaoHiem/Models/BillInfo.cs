namespace Online_NonBaoHiem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BillInfo")]
    public partial class BillInfo
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdBill { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdHelmet { get; set; }

        public int Quanity { get; set; }

        public decimal? ToltalPrice { get; set; }

        public virtual Bill Bill { get; set; }

        public virtual Helmet Helmet { get; set; }
    }
}
