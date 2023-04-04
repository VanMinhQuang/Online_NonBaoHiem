namespace Online_NonBaoHiem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Helmet")]
    public partial class Helmet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Helmet()
        {
            BillInfoes = new HashSet<BillInfo>();
        }

        [Key]
        public int IdHelmet { get; set; }

        [Required]
        [StringLength(100)]
        public string HelmetName { get; set; }

        public int IdCategory { get; set; }

        public double Price { get; set; }

        [StringLength(200)]
        public string Thumbnail { get; set; }

        public int? Quanity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateTime { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillInfo> BillInfoes { get; set; }

        public virtual Category Category { get; set; }
    }
}
