namespace WebASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HinhAnhSP")]
    public partial class HinhAnhSP
    {
        [Key]
        [StringLength(10)]
        [Display(Name = "MÃ HÌNH ẢNH")]
        public string MaHASP { get; set; }

        [StringLength(20)]
        [Display(Name = "SỐ SERIAL")]
        public string SerialNumber { get; set; }

        [StringLength(255)]
        [Display(Name = "LINK")]
        public string LinkHASP { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
