namespace WebASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "MÃ ĐƠN HÀNG")]
        public string MaDonHang { get; set; }

        [StringLength(10)]
        [Display(Name = "MÃ CÁCH THANH TOÁN")]
        public string MaHTTT { get; set; }

        [StringLength(10)]
        [Display(Name = "MÃ KHÁCH HÀNG")]
        public string MaKH { get; set; }

        [StringLength(10)]
        [Display(Name = "MÃ TRẠNG THÁI")]
        public string MaTT { get; set; }

        [StringLength(10)]
        [Display(Name = "MÃ NHÂN VIÊN")]
        public string MaNV { get; set; }

        [Display(Name = "NGÀY MUA")]
        public DateTime? NgayMua { get; set; }

        [StringLength(255)]
        [Display(Name = "GHI CHÚ")]
        public string GhiChuDonHang { get; set; }

        [Display(Name = "SỐ LƯỢNG")]
        public int? SoLuongCT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        public virtual HinhThucThanhToan HinhThucThanhToan { get; set; }

        public virtual TrangThaiDonHang TrangThaiDonHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
