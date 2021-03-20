using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using Shopthucung.Models;

namespace Shopthucung.Areas.admin.Models
{
    public class sqlAdmin
    {
        private shopDBmodel conn = null;

        public sqlAdmin()
        {
            conn = new shopDBmodel();
        }

        public List<v_admin_sp> getSp(int Page, int pageSize)
        {
            List<v_admin_sp> list = conn.v_admin_sp.OrderByDescending(c => c.ngaythem).Skip((Page - 1) * pageSize).Take(pageSize).ToList();
            return list;
        }
        public IEnumerable<v_admin_sp> countPageSP(int page, int pageSize)
        {
            return conn.v_admin_sp.OrderByDescending(c => c.ngaythem).ToPagedList(page, pageSize);
        }
        public List<PhanLoaiSP> getPhanLoai(string MaLoai)
        {
            List<PhanLoaiSP> list = conn.PhanLoaiSPs.Where(c => c.MaLoaiSP == MaLoai).ToList();
            return list;
        }
        public bool deleteImgSp(string MaSp)
        {
            try
            {
                conn.img_sp.RemoveRange(this.findImg(MaSp));
                conn.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool deleteSp(string MaSp)
        {
            try
            {
                SanPham sp = this.findSP(MaSp);
                conn.img_sp.RemoveRange(this.findImg(MaSp));
                conn.SaveChanges();
                conn.SanPhams.Remove(sp);
                conn.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public SanPham findSP(String MaSp)
        {
            SanPham sp = conn.SanPhams.Where(c => c.MaSp == MaSp).Single();
            return sp;
        }
        public List<img_sp> findImg(String MaSp)
        {
            List<img_sp> list = conn.img_sp.Where(c => c.MaSp == MaSp).ToList();
            return list;
        }
        public List<PhanLoaiSP> getPhanLoai()
        {
            return conn.PhanLoaiSPs.OrderBy(c=>c.MaLoaiSP).ToList();
        }
        public bool insertSP(SanPham sp)
        {
            try
            {
                conn.SanPhams.Add(sp);
                conn.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool insertImg(string MaSp,string img,int loai)
        {
            try
            {
                string sql = "insert into img_sp values('" + MaSp + "','" + img + "'," + loai + ")";
                conn.Database.ExecuteSqlCommand(sql);
                conn.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateSP(SanPham sp) {
            try
            {
                var sp1 = conn.SanPhams.Find(sp.MaSp);
                sp1.MaSp = sp.MaSp;
                sp1.tenSP = sp.tenSP;
                sp1.MaPL = sp.MaPL;
                sp1.mausac = sp.mausac;
                sp1.gioitinh = sp.gioitinh;
                sp1.tuoi = sp.tuoi;
                sp1.tinhtrang = sp.tinhtrang;
                sp1.timvacxin = sp.timvacxin;
                sp1.taygiun = sp.taygiun;
                sp1.xuatxu = sp.xuatxu;
                sp1.ngaythem = sp.ngaythem;
                sp1.hot = sp.hot;
                sp1.mota = sp.mota;
                conn.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }
        public List<v_sp_ct> getSPChiTiet(string MaSP)
        {
            string sql = "SELECT dbo.SanPham.MaSp, dbo.SanPham.tenSP, dbo.SanPham.MaPL, dbo.SanPham.mausac, dbo.SanPham.gioitinh, dbo.SanPham.tuoi, dbo.SanPham.tinhtrang, dbo.SanPham.timvacxin, dbo.SanPham.taygiun, dbo.SanPham.xuatxu,  dbo.SanPham.ngaythem, dbo.SanPham.hot, dbo.img_sp.url, dbo.img_sp.loai, dbo.PhanLoaiSP.MaLoaiSP,dbo.PhanLoaiSP.TenPhanLoai,dbo.SanPham.mota FROM     dbo.SanPham INNER JOIN dbo.PhanLoaiSP ON dbo.PhanLoaiSP.MaPL = dbo.SanPham.MaPL INNER JOIN dbo.img_sp ON dbo.img_sp.MaSp = dbo.SanPham.MaSp";

            List<v_sp_ct> list = conn.Database.SqlQuery<v_sp_ct>(sql).Where(c => c.MaSp == MaSP).ToList();
            return list;
        }
        public List<TinTuc> getTinTuc(int Page, int pageSize)
        {
            List<TinTuc> list = conn.TinTucs.OrderByDescending(c => c.ngaydang).Skip((Page - 1) * pageSize).Take(pageSize).ToList();
            return list;
        }
        public IEnumerable<TinTuc> countPageTT(int page, int pageSize)
        {
            return conn.TinTucs.OrderByDescending(c => c.ngaydang).ToPagedList(page, pageSize);
        }
        public bool deleteTinTuc(string MaTinTuc)
        {
            try
            {
                TinTuc tt = conn.TinTucs.Find(MaTinTuc);
                
                conn.TinTucs.Remove(tt);
                conn.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public TinTuc findTT(String MaTinTuc)
        {
            TinTuc tt = conn.TinTucs.Where(c => c.MaBaiViet == MaTinTuc).Single();
            return tt;
        }
        public bool insertTT(TinTuc tt)
        {
            try
            {
                conn.TinTucs.Add(tt);
                conn.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateTT(TinTuc tt)
        {
            try
            {
                var tt1 = conn.TinTucs.Find(tt.MaBaiViet);
                tt1.MaBaiViet = tt.MaBaiViet;
                tt1.TieuDe = tt.TieuDe;
                tt1.ngaydang = tt.ngaydang;
                tt1.mota = tt.mota;
                tt1.anhmota = tt.anhmota;
                tt1.motangan = tt.motangan;
                conn.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}