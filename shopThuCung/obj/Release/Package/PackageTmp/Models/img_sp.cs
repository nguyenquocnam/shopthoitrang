namespace Shopthucung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class img_sp
    {
        [Key]
        [Column(Order = 0)]
        public int MaIMG { get; set; }

        [StringLength(50)]
        public string MaSp { get; set; }

        [StringLength(400)]
        public string url { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int loai { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
