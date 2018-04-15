namespace WebASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            ChiTietBH = new HashSet<ChiTietBH>();
            DonHang = new HashSet<DonHang>();
            PhieuNhapSP = new HashSet<PhieuNhapSP>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "MÃ NHÂN VIÊN")]
        public string MaNV { get; set; }

        [StringLength(10)]
        [Display(Name = "MÃ LOẠI")]
        public string MaLoaiNV { get; set; }

        [StringLength(100)]
        [Display(Name = "HỌ TÊN NV")]
        public string TenNV { get; set; }

        [Display(Name = "NGÀY SINH")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(100)]
        [Display(Name = "QUÊ QUÁN")]
        public string QueQuan { get; set; }

        [Display(Name = "GIỚI TÍNH")]
        public int? GioiTinh { get; set; }

        [StringLength(15)]
        [Display(Name = "SĐT")]
        [DataType(DataType.PhoneNumber)]
        public string SDTNV { get; set; }

        [Display(Name = "NGÀY KÝ HỢP ĐỒNG")]
        public DateTime? NgayKyHopDong { get; set; }

        [StringLength(20)]
        [Display(Name = "TÀI KHOẢN")]
        public string TaiKhoan { get; set; }

        [StringLength(20)]
        [Display(Name = "MẬT KHẨU")]
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }

        [StringLength(70)]
        [Display(Name = "EMAIL")]
        [DataType(DataType.EmailAddress)]
        public string EmailNV { get; set; }

        [StringLength(100)]
        [Display(Name = "ĐỊA CHỈ")]
        public string DiaChiNV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietBH> ChiTietBH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHang { get; set; }

        public virtual LoaiNV LoaiNV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhapSP> PhieuNhapSP { get; set; }
    }
}
