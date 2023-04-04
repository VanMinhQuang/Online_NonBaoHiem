namespace Online_NonBaoHiem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            BillInfoes = new HashSet<BillInfo>();
            Feedbacks = new HashSet<Feedback>();
        }

        [Key]
        public int IdBill { get; set; }

        public bool? ThanhToan { get; set; }

        public bool? GiaoHang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayGiao { get; set; }

        public int? IdCustomer { get; set; }

        public virtual CustomerAccount CustomerAccount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillInfo> BillInfoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
