namespace WebASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhapSP")]
    public partial class PhieuNhapSP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuNhapSP()
        {
            ChiTietNhap = new HashSet<ChiTietNhap>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "MÃ PHIẾU NHẬP")]
        public string MaPN { get; set; }

        [StringLength(10)]
        [Display(Name = "MÃ NCC")]
        public string MaNCC { get; set; }

        [StringLength(10)]
        [Display(Name = "MÃ NHÂN VIÊN")]
        public string MaNV { get; set; }

        [Display(Name = "NGÀY NHẬP")]
        public DateTime? NgayNhap { get; set; }

        [StringLength(255)]
        [Display(Name = "GHI CHÚ")]
        public string GhiChuPN { get; set; }

        [Display(Name = "SỐ LƯỢNG NHẬP")]
        public int? SLNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNhap> ChiTietNhap { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
