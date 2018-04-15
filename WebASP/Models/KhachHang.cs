namespace WebASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            ChiTietKH = new HashSet<ChiTietKH>();
            DonHang = new HashSet<DonHang>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "MÃ KHÁCH HÀNG")]
        public string MaKH { get; set; }

        [StringLength(100)]
        [Display(Name = "HỌ TÊN")]
        public string TenKH { get; set; }

        [StringLength(20)]
        [Display(Name = "TÀI KHOẢN")]
        public string TaiKhoanKH { get; set; }

        [StringLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "MẬT KHẨU")]
        public string MatKhauKH { get; set; }

        [StringLength(100)]
        [Display(Name = "ĐỊA CHỈ")]
        public string DiaChiKH { get; set; }

        [StringLength(15)]
        [Display(Name = "SĐT")]
        [DataType(DataType.PhoneNumber)]
        public string SDTKH { get; set; }

        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "EMAIL")]
        public string EmailKH { get; set; }

        [Display(Name = "GIỚI TÍNH")]
        public int? GioiTinhKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietKH> ChiTietKH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHang { get; set; }
    }
}
