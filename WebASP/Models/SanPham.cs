namespace WebASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietBH = new HashSet<ChiTietBH>();
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
            ChiTietNhap = new HashSet<ChiTietNhap>();
            HinhAnhSP = new HashSet<HinhAnhSP>();
        }

        [Key]
        [StringLength(20)]
        [Display(Name = "SỐ SERIAL")]
        public string SerialNumber { get; set; }

        [StringLength(10)]
        [Display(Name = "MÃ LOẠI")]
        public string MaLoaiSP { get; set; }

        [StringLength(10)]
        [Display(Name = "MÃ NSX")]
        public string MaNSX { get; set; }

        [StringLength(10)]
        [Display(Name = "MÃ GIÁ")]
        public string MaGiaSP { get; set; }

        [StringLength(10)]
        [Display(Name = "MÃ KHUYẾN MÃI")]
        public string MaKM { get; set; }

        [StringLength(10)]
        [Display(Name = "MÃ NHÓM")]
        public string MaNhomSP { get; set; }

        [StringLength(50)]
        [Display(Name = "TÊN SẢN PHẨM")]
        public string TenSP { get; set; }

        [Display(Name = "ĐÃ BÁN")]
        public int? SLTonKho { get; set; }

        [StringLength(50)]
        [Display(Name = "MÔ TẢ")]
        public string MoTaNgan { get; set; }

        [StringLength(255)]
        [Display(Name = "MÔ TẢ CHI TIẾT")]
        public string MoTaChiTiet { get; set; }

        [Display(Name = "THỜI GIAN BẢO HÀNH")]
        public int? TGBaoHanh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietBH> ChiTietBH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNhap> ChiTietNhap { get; set; }

        public virtual GiaSP GiaSP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HinhAnhSP> HinhAnhSP { get; set; }

        public virtual KhuyenMai KhuyenMai { get; set; }

        public virtual LoaiSP LoaiSP { get; set; }

        public virtual NhaSanXuat NhaSanXuat { get; set; }

        public virtual NhomSanPham NhomSanPham { get; set; }
    }
}
