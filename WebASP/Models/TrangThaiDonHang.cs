namespace WebASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrangThaiDonHang")]
    public partial class TrangThaiDonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TrangThaiDonHang()
        {
            DonHang = new HashSet<DonHang>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "MÃ TRẠNG THÁI")]
        public string MaTT { get; set; }

        [StringLength(20)]
        [Display(Name = "TÊN TRẠNG THÁI")]
        public string TenTT { get; set; }

        [StringLength(255)]
        [Display(Name = "MÔ TẢ")]
        public string MoTaTT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHang { get; set; }
    }
}
