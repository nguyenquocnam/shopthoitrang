namespace Shopthucung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class c_sp
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MaSp { get; set; }

        [StringLength(50)]
        public string MaPL { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MaLoaiSP { get; set; }
    }
}
