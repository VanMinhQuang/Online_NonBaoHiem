namespace Online_NonBaoHiem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustomerAccount")]
    public partial class CustomerAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerAccount()
        {
            Bills = new HashSet<Bill>();
        }

        [Key]
        public int IdCustomer { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerUserName { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerPass { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerDISPLAYNAME { get; set; }

        [StringLength(100)]
        public string CustomerSDT { get; set; }

        [StringLength(100)]
        public string CustomerDIACHI { get; set; }

        [StringLength(50)]
        public string CustomerEmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
