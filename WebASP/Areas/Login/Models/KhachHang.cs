namespace WebASP.Areas.Login.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [Key]
        [StringLength(10)]
        public string MaKH { get; set; }

        [StringLength(100)]
        public string TenKH { get; set; }

        [StringLength(20)]
        public string TaiKhoanKH { get; set; }

        [StringLength(20)]
        public string MatKhauKH { get; set; }

        [StringLength(100)]
        public string DiaChiKH { get; set; }

        [StringLength(15)]
        public string SDTKH { get; set; }

        [StringLength(100)]
        public string EmailKH { get; set; }

        public int? GioiTinhKH { get; set; }
    }
}
