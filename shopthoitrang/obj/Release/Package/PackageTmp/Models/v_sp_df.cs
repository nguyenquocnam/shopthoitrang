namespace Shopthucung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class v_sp_df
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MaSp { get; set; }

        [StringLength(50)]
        public string tenSP { get; set; }

        [StringLength(50)]
        public string MaPL { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaythem { get; set; }

        public int? hot { get; set; }

        [StringLength(400)]
        public string url { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int loai { get; set; }
    }
}
