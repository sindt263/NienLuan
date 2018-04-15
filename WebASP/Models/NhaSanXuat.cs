namespace WebASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaSanXuat")]
    public partial class NhaSanXuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaSanXuat()
        {
            SanPham = new HashSet<SanPham>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "MÃ NSX")]
        public string MaNSX { get; set; }

        [StringLength(50)]
        [Display(Name = "TÊN NSX")]
        public string TenNSX { get; set; }

        [StringLength(50)]
        [Display(Name = "QUỐC GIA")]
        public string QuocGiaNSX { get; set; }

        [StringLength(100)]
        [Display(Name = "ĐỊA CHỈ")]
        public string DiaChiNSX { get; set; }

        [StringLength(255)]
        [Display(Name = "MÔ TẢ")]
        public string MoTaNSX { get; set; }

        [StringLength(255)]
        [Display(Name = "GHI CHÚ")]
        public string GhiChuNSX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
