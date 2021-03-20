namespace Shopthucung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class v_sp_ct
    {
        [Key]
        [Column(Order = 0)]
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

        [StringLength(400)]
        public string url { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int loai { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string MaLoaiSP { get; set; }

        [StringLength(300)]
        public string TenPhanLoai { get; set; }

        public string mota { get; set; }
    }
}
