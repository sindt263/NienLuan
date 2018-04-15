namespace WebASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "MÃ CHI TIẾT")]
        public int MaCTDH { get; set; }

        [StringLength(10)]
        [Display(Name = "MÃ ĐƠN HÀNG")]
        public string MaDonHang { get; set; }

        [StringLength(20)]
        [Display(Name = "SỐ SERIAL")]
        public string SerialNumber { get; set; }

        [Display(Name = "GIÁ CHI TIẾT")]
        public int? DonGiaCT { get; set; }

        [StringLength(100)]
        [Display(Name = "ĐỊA CHỈ GIAO HÀNG")]
        public string DiaChiGiaoHang { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
