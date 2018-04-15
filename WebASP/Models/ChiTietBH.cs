namespace WebASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietBH")]
    public partial class ChiTietBH
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "MÃ CHI TIẾT")]
        public int MaCTBH { get; set; }

        [StringLength(20)]
        [Display(Name = "SỐ SERIAL")]
        public string SerialNumber { get; set; }

        [StringLength(10)]
        [Display(Name = "MÃ NHÂN VIÊN")]
        public string MaNV { get; set; }

        [StringLength(10)]
        [Display(Name = "MÃ BẢO HÀNH")]
        public string MaBH { get; set; }

        [StringLength(100)]
        [Display(Name = "TRẠNG THÁI")]
        public string TrangThai { get; set; }

        [Display(Name = "NGÀY BẢO HÀNH")]
        public DateTime? NgayBH { get; set; }

        [StringLength(255)]
        [Display(Name = "GHI CHÚ")]
        public string GhiChuBH { get; set; }

        [Display(Name = "NGÀY TRẢ")]
        public DateTime? NgayTra { get; set; }

        public virtual BaoHanh BaoHanh { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
