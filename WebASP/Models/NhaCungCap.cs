namespace WebASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaCungCap")]
    public partial class NhaCungCap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaCungCap()
        {
            PhieuNhapSP = new HashSet<PhieuNhapSP>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "MÃ NCC")]
        public string MaNCC { get; set; }

        [StringLength(100)]
        [Display(Name = "TÊN NCC")]
        public string TenNCC { get; set; }

        [StringLength(15)]
        [Display(Name = "SĐT")]
        public string SDTNCC { get; set; }

        [StringLength(100)]
        [Display(Name = "ĐỊA CHỈ")]
        public string DiaChiNCC { get; set; }

        [StringLength(255)]
        [Display(Name = "GHI CHÚ")]
        public string GhiChuNCC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhapSP> PhieuNhapSP { get; set; }
    }
}
