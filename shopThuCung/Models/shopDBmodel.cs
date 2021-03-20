namespace Shopthucung.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class shopDBmodel : DbContext
    {
        public shopDBmodel()
            : base("name=shopDBmodel")
        {
        }

        public virtual DbSet<chitiethoadon> chitiethoadons { get; set; }
        public virtual DbSet<hoadon> hoadons { get; set; }
        public virtual DbSet<LoaiSP> LoaiSPs { get; set; }
        public virtual DbSet<PhanLoaiSP> PhanLoaiSPs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<img_sp> img_sp { get; set; }
        public virtual DbSet<c_sp> c_sp { get; set; }
        public virtual DbSet<v_admin_sp> v_admin_sp { get; set; }
        public virtual DbSet<v_ct_hd> v_ct_hd { get; set; }
        public virtual DbSet<v_list_sp> v_list_sp { get; set; }
        public virtual DbSet<v_sp_ct> v_sp_ct { get; set; }
        public virtual DbSet<v_sp_df> v_sp_df { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<chitiethoadon>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<chitiethoadon>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.shipMobie)
                .IsUnicode(false);

            modelBuilder.Entity<hoadon>()
                .HasMany(e => e.chitiethoadons)
                .WithRequired(e => e.hoadon)
                .HasForeignKey(e => e.OrderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiSP>()
                .HasMany(e => e.PhanLoaiSPs)
                .WithRequired(e => e.LoaiSP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaSp)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.chitiethoadons)
                .WithRequired(e => e.SanPham)
                .HasForeignKey(e => e.ProductID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TinTuc>()
                .Property(e => e.MaBaiViet)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<img_sp>()
                .Property(e => e.MaSp)
                .IsUnicode(false);

            modelBuilder.Entity<c_sp>()
                .Property(e => e.MaSp)
                .IsUnicode(false);

            modelBuilder.Entity<v_admin_sp>()
                .Property(e => e.MaSp)
                .IsUnicode(false);

            modelBuilder.Entity<v_admin_sp>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<v_ct_hd>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<v_ct_hd>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<v_list_sp>()
                .Property(e => e.MaSp)
                .IsUnicode(false);

            modelBuilder.Entity<v_list_sp>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<v_sp_ct>()
                .Property(e => e.MaSp)
                .IsUnicode(false);

            modelBuilder.Entity<v_sp_ct>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<v_sp_df>()
                .Property(e => e.MaSp)
                .IsUnicode(false);

            modelBuilder.Entity<v_sp_df>()
                .Property(e => e.price)
                .HasPrecision(18, 0);
        }
    }
}
