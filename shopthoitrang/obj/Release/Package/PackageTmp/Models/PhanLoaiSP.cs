namespace Shopthucung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanLoaiSP")]
    public partial class PhanLoaiSP
    {
        [Key]
        [StringLength(50)]
        public string MaPL { get; set; }

        [Required]
        [StringLength(50)]
        public string MaLoaiSP { get; set; }

        [StringLength(300)]
        public string TenPhanLoai { get; set; }

        public virtual LoaiSP LoaiSP { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
