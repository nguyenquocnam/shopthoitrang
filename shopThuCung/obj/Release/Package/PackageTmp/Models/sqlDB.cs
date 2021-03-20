using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace Shopthucung.Models
{
    
    public class sqlDB
    {
        private shopDBmodel conn = null;

        public sqlDB()
        {
            conn = new shopDBmodel();
        }

        public List<v_sp_df> getSP(string MaPL)
        {
            string sql = "SELECT dbo.SanPham.MaSp, dbo.SanPham.tenSP, dbo.SanPham.MaPL, dbo.SanPham.ngaythem, dbo.SanPham.hot, dbo.img_sp.url, dbo.img_sp.loai FROM     dbo.SanPham INNER JOIN dbo.img_sp ON dbo.SanPham.MaSp = dbo.img_sp.MaSp";
            List<v_sp_df> list = conn.Database.SqlQuery<v_sp_df>(sql).Where(c => c.MaPL == MaPL && c.loai==0).OrderByDescending(c => c.ngaythem).Take(21).ToList();
            return list;
        }
        public List<v_sp_df> getSPLike(string MaPL,string MaSp)
        {
            string sql = "SELECT dbo.SanPham.MaSp, dbo.SanPham.tenSP, dbo.SanPham.MaPL, dbo.SanPham.ngaythem, dbo.SanPham.hot, dbo.img_sp.url, dbo.img_sp.loai FROM     dbo.SanPham INNER JOIN dbo.img_sp ON dbo.SanPham.MaSp = dbo.img_sp.MaSp";
            List<v_sp_df> list = conn.Database.SqlQuery<v_sp_df>(sql).Where(c => c.MaPL == MaPL&& c.MaSp!=MaSp).OrderByDescending(c => c.ngaythem).Take(21).ToList();
            return list;
        }
        public List<v_sp_df> getSP(int hot)
        {
            string sql = "SELECT  dbo.SanPham.MaSp, dbo.SanPham.tenSP, dbo.SanPham.MaPL, dbo.SanPham.ngaythem, dbo.SanPham.hot, dbo.img_sp.url, dbo.img_sp.loai FROM     dbo.SanPham INNER JOIN dbo.img_sp ON dbo.SanPham.MaSp = dbo.img_sp.MaSp";

            List<v_sp_df> list = conn.Database.SqlQuery<v_sp_df>(sql).Where(c=>c.hot==hot && c.loai==0).OrderByDescending(c => c.ngaythem).Take(21).ToList();
            return list;
        }
        public List<v_sp_ct> getSPChiTiet(string MaSP)
        {
            string sql = "SELECT dbo.SanPham.MaSp, dbo.SanPham.tenSP, dbo.SanPham.MaPL, dbo.SanPham.mausac, dbo.SanPham.gioitinh, dbo.SanPham.tuoi, dbo.SanPham.tinhtrang, dbo.SanPham.timvacxin, dbo.SanPham.taygiun, dbo.SanPham.xuatxu,  dbo.SanPham.ngaythem, dbo.SanPham.hot, dbo.img_sp.url, dbo.img_sp.loai, dbo.PhanLoaiSP.MaLoaiSP,dbo.PhanLoaiSP.TenPhanLoai,dbo.SanPham.mota FROM     dbo.SanPham INNER JOIN dbo.PhanLoaiSP ON dbo.PhanLoaiSP.MaPL = dbo.SanPham.MaPL INNER JOIN dbo.img_sp ON dbo.img_sp.MaSp = dbo.SanPham.MaSp";

            List<v_sp_ct> list = conn.Database.SqlQuery<v_sp_ct>(sql).Where(c => c.MaSp== MaSP).ToList();
            return list;
        }
        public List<PhanLoaiSP> getPhanLoai(string MaLoai)
        {
            List<PhanLoaiSP> list = conn.PhanLoaiSPs.Where(c => c.MaLoaiSP == MaLoai).ToList();
            return list;
        }
        public List<LoaiSP> getLoaiSP()
        {
            List<LoaiSP> list = conn.LoaiSPs.ToList();
            return list;
        }
        public List<PhanLoaiSP> getPhanLoai()
        {
            List<PhanLoaiSP> list = conn.PhanLoaiSPs.ToList();

            return list;
        }
       
        public List<v_list_sp> getListSPTK(string TenSp)
        {
            return null;
        }
        public List<v_list_sp> getListSP(string MaLoaiSP,int Page,int pageSize)
        {
            string sql = "SELECT dbo.SanPham.MaSp, dbo.SanPham.tenSP, dbo.SanPham.MaPL, dbo.SanPham.ngaythem, dbo.img_sp.url, dbo.img_sp.loai, dbo.PhanLoaiSP.TenPhanLoai, dbo.PhanLoaiSP.MaLoaiSP FROM dbo.SanPham INNER JOIN dbo.img_sp ON dbo.SanPham.MaSp = dbo.img_sp.MaSp INNER JOIN dbo.PhanLoaiSP ON dbo.SanPham.MaPL = dbo.PhanLoaiSP.MaPL";
            List<v_list_sp> list = conn.Database.SqlQuery<v_list_sp>(sql).Where(c => c.MaLoaiSP == MaLoaiSP && c.loai==0).OrderByDescending(c => c.ngaythem).Skip((Page-1)* pageSize * 2).Take(pageSize * 2).ToList();
            
            return list;
        }
        public List<v_list_sp> getListSP(string MaLoaiSP, string MaPL,int Page,int pageSize)
        {
            string sql = "SELECT dbo.SanPham.MaSp, dbo.SanPham.tenSP, dbo.SanPham.MaPL, dbo.SanPham.ngaythem, dbo.img_sp.url, dbo.img_sp.loai, dbo.PhanLoaiSP.TenPhanLoai, dbo.PhanLoaiSP.MaLoaiSP FROM dbo.SanPham INNER JOIN dbo.img_sp ON dbo.SanPham.MaSp = dbo.img_sp.MaSp INNER JOIN dbo.PhanLoaiSP ON dbo.SanPham.MaPL = dbo.PhanLoaiSP.MaPL";
            List<v_list_sp> list = conn.Database.SqlQuery<v_list_sp>(sql).Where(c => c.MaLoaiSP == MaLoaiSP &&c.MaPL==MaPL && c.loai == 0).OrderByDescending(c => c.ngaythem).Skip((Page-1)* pageSize * 2).Take(pageSize * 2).ToList();
            return list;
            
        }
        public int countSP()
        {
            return conn.c_sp.Count();
        }
        public IEnumerable<c_sp> countSPForMaLoai(string MaLoaiSP,int page,int pageSize)
        {
            return conn.c_sp.Where(c=> c.MaLoaiSP == MaLoaiSP).OrderBy(c=>c.MaSp).ToPagedList(page,pageSize);
        }
        public IEnumerable<c_sp> countSPForMaPL(string MaPL, int page, int pageSize)
        {
            return conn.c_sp.Where(c => c.MaPL == MaPL).OrderBy(c => c.MaSp).ToPagedList(page, pageSize);
        }
        public List<TinTuc> getTinTuc(int Page, int pageSize)
        {
            List<TinTuc> list = conn.TinTucs.OrderByDescending(c => c.ngaydang).Skip((Page - 1) * pageSize ).Take(pageSize).ToList(); 
            return list;
        }
        public TinTuc getTinTuc(string MaBaiViet)
        {
            TinTuc tinTuc = conn.TinTucs.Where(c => c.MaBaiViet == MaBaiViet).FirstOrDefault();
            
            return tinTuc;
        }
        public IEnumerable<TinTuc> countPageTinTuc(int page, int pageSize)
        {
            return conn.TinTucs.OrderBy(c => c.ngaydang).ToPagedList(page, pageSize);
        }

    }
}