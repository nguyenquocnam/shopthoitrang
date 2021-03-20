namespace Shopthucung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            img_sp = new HashSet<img_sp>();
        }

        [Key]
        [StringLength(50)]
        public string MaSp { get; set; }

        [StringLength(50)]
        public string tenSP { get; set; }

        [StringLength(50)]
        public string MaPL { get; set; }

        [StringLength(50)]
        public string mausac { get; set; }

        [StringLength(50)]
        public string gioitinh { get; set; }

        [StringLength(50)]
        public string tuoi { get; set; }

        [StringLength(50)]
        public string tinhtrang { get; set; }

        public int? timvacxin { get; set; }

        public int? taygiun { get; set; }

        [StringLength(100)]
        public string xuatxu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaythem { get; set; }

        public int? hot { get; set; }

        public string mota { get; set; }

        public virtual PhanLoaiSP PhanLoaiSP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<img_sp> img_sp { get; set; }
    }
}
