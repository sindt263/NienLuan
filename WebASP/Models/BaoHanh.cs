namespace WebASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaoHanh")]
    public partial class BaoHanh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaoHanh()
        {
            ChiTietBH = new HashSet<ChiTietBH>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "MÃ BẢO HÀNH")]
        public string MaBH { get; set; }

        [StringLength(50)]
        [Display(Name = "CÁCH BẢO HÀNH")]
        public string HinhThucBH { get; set; }

        [StringLength(255)]
        [Display(Name = "MÔ TẢ")]
        public string MoTaBH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietBH> ChiTietBH { get; set; }
    }
}
