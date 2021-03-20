namespace Shopthucung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        [StringLength(50)]
        public string MaBaiViet { get; set; }

        [StringLength(1000)]
        public string TieuDe { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaydang { get; set; }

        public string mota { get; set; }

        [StringLength(1000)]
        public string anhmota { get; set; }

        [StringLength(1000)]
        public string motangan { get; set; }
    }
}
