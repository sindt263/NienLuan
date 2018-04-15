namespace WebASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhuyenMai")]
    public partial class KhuyenMai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhuyenMai()
        {
            SanPham = new HashSet<SanPham>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "MÃ KHUYẾN MÃI")]
        public string MaKM { get; set; }

        [StringLength(50)]
        [Display(Name = "TÊN KHUYẾN MÃI")]
        public string TenKM { get; set; }

        [StringLength(255)]
        [Display(Name = "MÔ TẢ")]
        public string MoTaKM { get; set; }

        [Display(Name = "NGÀY BẮT ĐẦU")]
        public DateTime? NgayBatDauKM { get; set; }

        [Display(Name = "THỜI GIAN")]
        public int? ThoiGianKM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
