namespace WebASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietNhap")]
    public partial class ChiTietNhap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "MÃ CHI TIẾT")]
        public int MaCTNhap { get; set; }

        [StringLength(10)]
        [Display(Name = "MÃ PHIẾU")]
        public string MaPN { get; set; }

        [StringLength(20)]
        [Display(Name = "SỐ SERIAL")]
        public string SerialNumber { get; set; }

        [Display(Name = "GIÁ NHẬP")]
        public int? GiaNhap { get; set; }

        public virtual PhieuNhapSP PhieuNhapSP { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
