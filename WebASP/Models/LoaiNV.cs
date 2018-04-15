namespace WebASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiNV")]
    public partial class LoaiNV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiNV()
        {
            NhanVien = new HashSet<NhanVien>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "MÃ LOẠI")]
        public string MaLoaiNV { get; set; }

        [StringLength(20)]
        [Display(Name = "TÊN LOẠI")]
        public string TenLoaiNV { get; set; }

        [StringLength(255)]
        [Display(Name = "MÔ TẢ")]
        public string MoTaLoaiNV { get; set; }

        [Display(Name = "GIỚI HẠN QUYỀN")]
        public int? QuyenSD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanVien { get; set; }
    }
}
