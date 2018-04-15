namespace WebASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietKH")]
    public partial class ChiTietKH
    {
        [Key]
        [Display(Name = "MÃ CHI TIẾT")]
        [StringLength(10)]
        public string MaKHCT { get; set; }

        [StringLength(10)]
        [Display(Name = "MÃ KHÁCH HÀNG")]
        public string MaKH { get; set; }

        [Display(Name = "SỐ HÀNG ĐÃ MUA")]
        public int? SoHangDaMua { get; set; }

        [Display(Name = "TỔNG TIỀN")]
        public int? TongTien { get; set; }

        [StringLength(255)]
        [Display(Name = "ĐỊA CHỈ THƯỜNG DÙNG")]
        public string DiaChiThuongDung { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
