namespace WebASP.Areas.Login.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        [StringLength(10)]
        public string MaNV { get; set; }

        [StringLength(10)]
        public string MaLoaiNV { get; set; }

        [StringLength(100)]
        public string TenNV { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(100)]
        public string QueQuan { get; set; }

        public int? GioiTinh { get; set; }

        [StringLength(15)]
        public string SDTNV { get; set; }

        public DateTime? NgayKyHopDong { get; set; }

        [StringLength(20)]
        public string TaiKhoan { get; set; }

        [StringLength(20)]
        public string MatKhau { get; set; }

        [StringLength(70)]
        public string EmailNV { get; set; }

        [StringLength(100)]
        public string DiaChiNV { get; set; }
    }
}
