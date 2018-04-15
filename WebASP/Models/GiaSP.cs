namespace WebASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaSP")]
    public partial class GiaSP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiaSP()
        {
            SanPham = new HashSet<SanPham>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "MÃ GIÁ")]
        public string MaGiaSP { get; set; }

        [Display(Name = "GIÁ SẼ UPDATE")]
        public int? GiaSauUpdate { get; set; }

        [Display(Name = "GIÁ HIỆN TẠI")]
        public int? GiaSPHienTai { get; set; }

        [Display(Name = "NGÀY CẬP NHẬT")]
        public DateTime? NgayCapNhat { get; set; }

        [Display(Name = "NGÀY ÁP DỤNG")]
        public DateTime? NgayApDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
