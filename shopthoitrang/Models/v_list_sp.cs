namespace Shopthucung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class v_list_sp
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MaSp { get; set; }

        [StringLength(50)]
        public string tenSP { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaythem { get; set; }

        [StringLength(400)]
        public string url { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int loai { get; set; }

        [StringLength(300)]
        public string TenPhanLoai { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaLoaiSP { get; set; }

        public decimal? price { get; set; }

        public int? MaPL { get; set; }
    }
}
