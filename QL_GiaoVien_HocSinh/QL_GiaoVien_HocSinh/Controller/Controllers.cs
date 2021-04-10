using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL_GiaoVien_HocSinh.Controller;
using QL_GiaoVien_HocSinh.Models;


namespace QL_GiaoVien_HocSinh.Controller
{
    class Controllers
    {
        DataAccess da = new DataAccess();
        public HocSinh[] getListHocSinh()
        {
            DataTable table = da.Query("select * from hocsinh");
            /*DataTable table = da.Query("select hs.Ma, hs.Ten, hs.GioiTinh, hs.NgaySinh, hs.Sodienthoai , hs.Email,hs.DanToc, "
                + "hs.DiaChi, hs.Sodienthoai, lhp.ma as [Lopma] from Hocsinh hs inner join Lophocphan lhp on hs.Lopma = lhp.ma");*/

            int n = table.Rows.Count;
            int i;
            if (n == 0) return null;
            HocSinh[] list = new HocSinh[n];
            for (i = 0; i < n; i++)
            {
                list[i] = getHocSinh(table.Rows[i]);
            }
            return list;
        }
        public HocSinh getHocSinh(DataRow row)
        {
            HocSinh hs = new HocSinh();
            hs.Ma = row["Ma"].ToString().Trim();
            hs.Ten = row["Ten"].ToString().Trim();
            int gt = 1;
            if (int.TryParse(row["GioiTinh"].ToString().Trim(), out gt))
            {
                hs.GioiTinh = gt;
            }
            DateTime ns = new DateTime();
            if (DateTime.TryParse(row["NgaySinh"].ToString().Trim(), out ns))
            {
                hs.NgaySinh = ns;
            }
            hs.DanToc = row["Dantoc"].ToString().Trim();
            hs.DiaChi = row["Diachi"].ToString().Trim();
            hs.LopMa = row["LopMa"].ToString().Trim();
            hs.SoDienThoai = row["SoDienThoai"].ToString().Trim();
            hs.Email = row["Email"].ToString().Trim();
            return hs;
        }

        public GiaoVien[] getListGiaoVien()
        {
            DataTable table = da.Query("select * from GiaoVien");
          /*  DataTable table = da.Query("select gv.Ma, gv.Ten, gv.GioiTinh, gv.NgaySinh, gv.Email, gv.luong, gv.Vaitro , gv.Bomonma , gv.nhiemvu, "
             + " gv.anh,bm.ma as [Bomonma] from GiaoVien gv inner join Bomon bm on gv.Bomonma  = bm.ma");*/


            int n = table.Rows.Count;
            int i;
            if (n == 0) return new GiaoVien[0];
            GiaoVien[] list = new GiaoVien[n];
            for (i = 0; i < n; i++)
            {
                list[i] = getGiaoVien(table.Rows[i]);
            }
            return list;

        }


        public GiaoVien getGiaoVien(DataRow row)
        {
            GiaoVien gv = new GiaoVien();
            gv.Ma = row["Ma"].ToString().Trim();
            gv.Ten = row["Ten"].ToString().Trim();
            int gt = 1;
            if (int.TryParse(row["GioiTinh"].ToString().Trim(), out gt))
            {
                gv.GioiTinh = gt;
            }
            DateTime ns = new DateTime();
            if (DateTime.TryParse(row["NgaySinh"].ToString().Trim(), out ns))
            {
                gv.NgaySinh = ns;
            }
            gv.Email = row["Email"].ToString().Trim();
            gv.BoMonMa = row["BoMonMa"].ToString().Trim();
            gv.NhiemVu = row["NhiemVu"].ToString().Trim();

            int luong = 0;
            if (int.TryParse(row["Luong"].ToString().Trim(), out luong))
            {
                gv.Luong = luong;
            }

            return gv;
        }

        public LopHocPhan[] getList_Lophophan()
        {
            //DataTable table = da.Query("select l.*, gv.ten as GiaoVienTen from lophocphan l, giaovien gv where gv.ma = l.giaovienma");
            DataTable table = da.Query("select l.ma, l.Hocki, l.Namhoc, l.Siso,l.Tiet, l.Thu, l.NgayBD, l.NgayKT, l.Ngaythi, "
                + " mh.ma as MonMa, mh.Ten as Ten, gv.ten as GiaoVienTen, gv.ma as GiaoVienMa "
                + " from Lophocphan l inner join monhoc mh on l.monma = mh.ma "
                + " inner join giaovien gv on gv.ma = l.Giaovienma");
            int n = table.Rows.Count;

            int i;
            if (n == 0) return new LopHocPhan[0];
            LopHocPhan[] list = new LopHocPhan[n];
            for (i = 0; i < n; i++)
            {
                list[i] = getLopHocPhan(table.Rows[i]);
            }
            return list;
        }

        public String[] getList_Lophophan_ID()
        {
            DataTable table = da.Query("select l.ma, l.Hocki, l.Namhoc, l.Siso,l.Tiet, l.Thu, mh.ma as monma, mh.ten as monten, "
                + " gv.ma as giaovienma, gv.ten as giaovienten from Lophocphan l inner  join monhoc mh on l.monma = mh.ma "
                + " inner join giaovien gv on gv.ma = l.Giaovienma");
            int n = table.Rows.Count;

            int i;
            if (n == 0) return new String[0];
            String[] list = new String[n];
            for (i = 0; i < n; i++)
            {
                list[i] = table.Rows[i]["Ma"].ToString().Trim();
            }
            return list;
        }
        private LopHocPhan getLopHocPhan(DataRow row)
        {
            LopHocPhan l = new LopHocPhan();
            l.Ma = row["Ma"].ToString().Trim();
            l.HocKy = row["HocKi"].ToString().Trim();
            l.NamHoc = row["NamHoc"].ToString().Trim();
            l.Thu = row["Thu"].ToString().Trim();
            l.MonHocMa = row["MonMa"].ToString().Trim();
            l.Tiet = Convert.ToInt32(row["Tiet"].ToString().Trim());
            l.Ten = row["Ten"].ToString().Trim();
            l.GiaoVienMa = row["GiaoVienMa"].ToString().Trim();
            l.GiaoVienTen = row["GiaoVienTen"].ToString().Trim();
            l.SiSo = int.Parse(row["SiSo"].ToString().Trim());
            l.NgayBatDau = DateTime.Parse(row["NgayBD"].ToString().Trim());
            l.NgayKetThuc = DateTime.Parse(row["NgayKT"].ToString().Trim());
            l.NgayThi = DateTime.Parse(row["NgayThi"].ToString().Trim());

            return l;
        }
        public void update_hs(HocSinh hs)
        {
            SqlParameter[] para =
             {
                new SqlParameter("Ma", hs.Ma),
                new SqlParameter("Ten", hs.Ten),
                new SqlParameter("GioiTinh", hs.GioiTinh),
                new SqlParameter("NgaySinh", hs.NgaySinh),
                new SqlParameter("Email", hs.Email),
                new SqlParameter("DanToc", hs.DanToc),
                new SqlParameter("DiaChi", hs.DiaChi),
                new SqlParameter("SoDienThoai", hs.SoDienThoai),
                new SqlParameter("LopMa", hs.LopMa),
            };
            da.Query("updateHS", para);
        }

        public void update_gv(GiaoVien gv)
        {
            SqlParameter[] para =
                   {
                new SqlParameter("Ma", gv.Ma),
                new SqlParameter("Ten", gv.Ten),
                new SqlParameter("GioiTinh", gv.GioiTinh),
                new SqlParameter("NgaySinh", gv.NgaySinh),
                new SqlParameter("Email", gv.Email),
                new SqlParameter("Luong",gv.Luong),
                new SqlParameter("NhiemVu", gv.NhiemVu),
                new SqlParameter("BoMonMa", gv.BoMonMa),
            };

            da.Query("updateGV", para);
        }
        public void XoaHS(string ma)
        {
            da.NonQuery("delete Hocsinh where ma='" + ma + "'");
        }

        public void XoaGV(string ma)
        {
            da.NonQuery("delete GiaoVien where  ma='" + ma + "'");
        }

        public bool ThemHS(HocSinh hs)
        {

            SqlParameter[] paraHS =
                       {
                new SqlParameter("Ten", hs.Ten),
                new SqlParameter("LopMa", hs.LopMa),
                new SqlParameter("NgaySinh",hs.NgaySinh),
                new SqlParameter("GioiTinh", hs.GioiTinh),
                new SqlParameter("DanToc", hs.DanToc),
                new SqlParameter("DiaChi", hs.DiaChi),
                new SqlParameter("Email", hs.Email),
                new SqlParameter("SoDienThoai",hs.SoDienThoai)




        };
            da.Query("proc_insertHS", paraHS);
            return true;
        }

        public bool ThemGV(GiaoVien gv)
        {

            SqlParameter[] paraGV ={
                new SqlParameter("Ten", gv.Ten),
                new SqlParameter("GioiTinh", gv.GioiTinh),
                new SqlParameter("NgaySinh",gv.NgaySinh),
                new SqlParameter("Email", gv.Email),
                new SqlParameter("Luong" , gv.Luong),
                new SqlParameter("NhiemVu" , gv.NhiemVu),
                new SqlParameter("BoMonMa" , gv.BoMonMa),
             };
            da.Query("proc_insertGV", paraGV);
            return true;
        }

        public String getBoMon(String bomonma)
        {
            if (bomonma == "") return "";
            DataTable table = da.Query("Select ten from bomon where bomon.ma = '" + bomonma + "'");
            int n = table.Rows.Count;
            if (n == 1)
            {
                return table.Rows[0]["Ten"].ToString().Trim();
            }

            return "";
        }
        public List<String> getBoMon()
        {
            DataTable table = da.Query("Select ten from bomon ");
            List<String> listBM = new List<string>();
            int n = table.Rows.Count;
            int i;
            if (n == 0) return new List<string>();
            for (i = 0; i < n; i++)
            {
                listBM.Add(table.Rows[i]["Ten"].ToString().Trim());
            }

            return listBM;
        }
        public String getMaBoMon(String tenbomon)
        {
            if (tenbomon == "") return "";
            DataTable table = da.Query("Select ma from bomon where bomon.ten = N'" + tenbomon + "'");
            int n = table.Rows.Count;
            if (n == 1)
            {
                return table.Rows[0]["Ma"].ToString().Trim();
            }

            return "";
        }

        public bool isChecked_GV(String magiaovien, String tengiaovien)
        {
            if (magiaovien == "") return false;
            DataTable table = da.Query("Select ma from giaovien gv where gv.ma = '" + magiaovien + "'");
            if (table.Rows.Count != 1)
                return false;
            return true;
        }
        public bool UpdateLopHocPhan(LopHocPhan lophocphan)
        {
            SqlParameter[] para ={
                new SqlParameter("Ma", lophocphan.Ma),
                new SqlParameter("HocKi", lophocphan.HocKy),
                new SqlParameter("NgayBD", lophocphan.NgayBatDau),
                new SqlParameter("NgayKT", lophocphan.NgayKetThuc),
                new SqlParameter("NgayThi", lophocphan.NgayThi),
                new SqlParameter("SiSo", lophocphan.SiSo),
                new SqlParameter("GiaoVienMa", lophocphan.GiaoVienMa)
        };
            da.Query("UpdateLopHocPhan", para);
            return true;
        }
    }
}
