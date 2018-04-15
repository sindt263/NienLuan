namespace WebASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HinhThucThanhToan")]
    public partial class HinhThucThanhToan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HinhThucThanhToan()
        {
            DonHang = new HashSet<DonHang>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "MÃ CÁCH THANH TOÁN")]
        public string MaHTTT { get; set; }

        [StringLength(20)]
        [Display(Name = "TÊN CÁCH THANH TOÁN")]
        public string TenHTTT { get; set; }

        [StringLength(255)]
        [Display(Name = "MÔ TẢ")]
        public string MoToHTTT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHang { get; set; }
    }
}
