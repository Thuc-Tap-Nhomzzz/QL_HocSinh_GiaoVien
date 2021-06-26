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
        //-------------------------------------------------
        public HocSinh[] getListHocSinhTheoMa(string ma)
        {
            string str = string.Format("select * from hocsinh where (Ma LIKE N'%" + ma + "%' OR '" + ma + "' = '')");
            DataTable table = da.Query(str);
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
        public HocSinh[] getListHocSinhTheoTen(string ten)
        {
            DataTable table = da.Query("select * from hocsinh where(Ten LIKE N'%" + ten + "%' OR '" + ten + "' = '')");
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
        public HocSinh[] getListHocSinhTheoLop(string lop)
        {
            DataTable table = da.Query("select * from hocsinh where (LopMa LIKE N'%" + lop + "%' OR '" + lop + "' = '')");
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
        public HocSinh[] getListHocSinhTheoDanToc(string dantoc)
        {
            DataTable table = da.Query("select * from hocsinh where (DanToc LIKE N'%" + dantoc + "%' OR '" + dantoc + "' = '')");
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
        public int chuyenGT(string gt)
        {
            int _gt = 0;
            if (int.TryParse(gt, out _gt))
            {
                return _gt;
            }
            else
                return _gt;
        }
        public HocSinh[] getListHocSinhTheoGioiTinh(string gt)
        {
            
            DataTable table = da.Query("select * from hocsinh where (GioiTinh =" + chuyenGT(gt) + " OR '" + gt + "' = '')");
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
        public HocSinh[] getListHocSinhTheoDiaChi(string diachi)
        {
            DataTable table = da.Query("select * from hocsinh where (DiaChi LIKE N'%" + diachi + "%' OR '" + diachi + "' = '')");
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
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public HocSinh getHocSinh(DataRow row)
        {
            HocSinh hs = new HocSinh();
            hs.Ma = row["Ma"].ToString().Trim();
            hs.Ten = row["Ten"].ToString().Trim();
            if (bool.Parse(row["Gioitinh"].ToString()))
            {
                hs.GioiTinh = 1;
            }
            else hs.GioiTinh = 0;
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
            //DataTable table = da.Query("select * from GiaoVien");
            DataTable table = da.Query("select gv.*,"
             + " bm.ten as BoMonTen from GiaoVien gv inner join Bomon bm on gv.Bomonma  = bm.ma");


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
            gv.SoDienThoai = row["SoDienThoai"].ToString().Trim();
            if (bool.Parse(row["Gioitinh"].ToString()))
            {
                gv.GioiTinh = 1;
            }
            else gv.GioiTinh = 0;
            DateTime ns = new DateTime();
            if (DateTime.TryParse(row["NgaySinh"].ToString().Trim(), out ns))
            {
                gv.NgaySinh = ns;
            }
            gv.Email = row["Email"].ToString().Trim();
            gv.BoMonMa = row["BoMonTen"].ToString().Trim();
            gv.NhiemVu = row["NhiemVu"].ToString().Trim();

            int luong = 0;
            if (int.TryParse(row["Luong"].ToString().Trim(), out luong))
            {
                gv.Luong = luong;
            }

            return gv;
        }
        //------------------------------------------------------------------------------
        public GiaoVien[] getListGiaoVienTheoMa(string ma)
        {
            DataTable table = da.Query("select gv.*,"
             + " bm.ten as BoMonTen from GiaoVien gv inner join Bomon bm on gv.Bomonma  = bm.ma where (gv.Ma LIKE N'%" + ma + "%' OR '" + ma + "' = '')");
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
        public GiaoVien[] getListGiaoVienTheoTen(string ten)
        {
            DataTable table = da.Query("select gv.*,"
             + " bm.ten as BoMonTen from GiaoVien gv inner join Bomon bm on gv.Bomonma  = bm.ma where (gv.Ten LIKE N'%" + ten + "%' OR '" + ten + "' = '')");
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
        public GiaoVien[] getListGiaoVienTheoGT(string gt)
        {
            DataTable table = da.Query("select gv.*,"
             + " bm.ten as BoMonTen from GiaoVien gv inner join Bomon bm on gv.Bomonma  = bm.ma where (gv.GioiTinh = " + chuyenGT(gt) + " OR '" + gt + "' = '')");
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
        public GiaoVien[] getListGiaoVienTheoBoMon(string bomon)
        {
            DataTable table = da.Query("select gv.*,"
             + " bm.ten as BoMonTen from GiaoVien gv inner join Bomon bm on gv.Bomonma  = bm.ma where (bm.Ten LIKE N'%" + bomon + "%' OR '" + bomon + "' = '')");
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
        public String[] getMaGV()
        {
            DataTable table = da.Query("select Ma from GiaoVien");
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
        public string getTenGV(string ma)
        {
            DataTable table = da.Query("select Ten from GiaoVien where Ma ='" + ma + "'");
            int n = table.Rows.Count;
            string ten = "";
            if (n== 1)
            {
                ten = table.Rows[0]["Ten"].ToString().Trim();
            }
            return ten;
        }
       ///-------------------------------------------------------------------------------------------------------------------
        public LopHocPhan[] getList_Lophophan()
        {
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
            l.Tiet = row["Tiet"].ToString().Trim();
            l.Ten = row["Ten"].ToString().Trim();
            l.GiaoVienMa = row["GiaoVienMa"].ToString().Trim();
            l.GiaoVienTen = row["GiaoVienTen"].ToString().Trim();
            l.SiSo = int.Parse(row["SiSo"].ToString().Trim());
            l.NgayBatDau = DateTime.Parse(row["NgayBD"].ToString().Trim());
            l.NgayKetThuc = DateTime.Parse(row["NgayKT"].ToString().Trim());
            l.NgayThi = DateTime.Parse(row["NgayThi"].ToString().Trim());

            return l;
        }
        public bool  update_hs(HocSinh hs)
        {
            da.NonQuery("update HocSinh set ten =N'"+ hs.Ten+"', gioitinh = "+hs.GioiTinh+", ngaysinh = '"+hs.NgaySinh+"', email = N'"+hs.Email+"', dantoc = N'"+hs.DanToc+"'," +
                "diachi = N'"+hs.DiaChi+"', sodienthoai = '"+hs.SoDienThoai+"', lopma = '"+hs.LopMa+"' where ma = '"+hs.Ma+"'");
            return true;
        }

        public bool update_gv(GiaoVien gv)
        {
            da.NonQuery("update GiaoVien set Ten=N'"+gv.Ten+"', Gioitinh ="+gv.GioiTinh+",Ngaysinh= '"+gv.NgaySinh+"', " +
                "Email =N'"+ gv.Email+"', Luong ="+ gv.Luong+", Nhiemvu =N'"+ gv.NhiemVu+"',Sodienthoai = N'"+gv.SoDienThoai+"'," +
                " bomonma ='"+gv.BoMonMa+ "' where ma = '" + gv.Ma + "'");
            return true;
        }
        public bool  XoaHS(string ma)
        {
            da.NonQuery("update HocSinh set ten =N'Học sinh này đãy bị xóa', gioitinh = 0, ngaysinh = getdate(), email = '', dantoc = ''," +
                "diachi = '', sodienthoai = '' where ma = '"  + ma + "'");
            return true;
        }

        public bool  XoaGV(string ma)
        {
            da.NonQuery("update GiaoVien set ten = N'Giáo Viên này đã xóa', gioitinh = 0, ngaysinh =getdate(), email ='', luong = 0, nhiemvu='', sodienthoai ='' where  ma='" + ma + "'");
            return true;
        }

        public bool ThemHS(HocSinh hs)
        {
            da.NonQuery("insert into HocSinh(Ma, Ten ,Ngaysinh, Gioitinh, Email, Dantoc, Diachi,Sodienthoai, Lopma) values" +
                "('"+hs.Ma+"', N'"+hs.Ten+"', '"+hs.NgaySinh+"' , "+hs.GioiTinh+", N'"+hs.Email+"', N'"+hs.DanToc+"'," +
                " N'"+hs.DiaChi+"', '"+hs.SoDienThoai+"', '"+hs.LopMa+"')");
            return true;
        }
       
        public bool ThemGV(GiaoVien gv)
        {
            da.NonQuery("insert into GiaoVien(Ma, Ten, Gioitinh,Ngaysinh,Email,Luong,Nhiemvu,Sodienthoai,Bomonma) " +
                "values ('"+gv.Ma+"', N'"+gv.Ten+"', "+gv.GioiTinh+", '"+gv.NgaySinh+"'," +
                "N'"+gv.Email+"', "+gv.Luong+", N'"+gv.NhiemVu+"',N'"+gv.SoDienThoai+"','"+gv.BoMonMa+"')");
            return true;
        }
        public bool update_LHP(LopHocPhan Lophocphan)
        {
            da.NonQuery("update LopHocPhan set Ten =N'"+ Lophocphan.Ten+ "' , Hocki =N'"+ Lophocphan.HocKy+ "', NgayBD='"+ Lophocphan.NgayBatDau+ "'," +
                " NgayKT ='"+ Lophocphan.NgayKetThuc+ "', Ngaythi ='"+ Lophocphan.NgayThi+ "', Siso ="+ Lophocphan.SiSo+ ", Thu =N'"+ Lophocphan.Thu+ "'," +
                " Tiet =N'"+ Lophocphan.Tiet+ "', Namhoc =N'"+ Lophocphan.NamHoc+ "', Giaovienma ='"+ Lophocphan.GiaoVienMa+ "' where Ma = '"+ Lophocphan.Ma+ "'");
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
        public List<String> getMaLopHocPhan()
        {
            DataTable table = da.Query("Select ma from Lophocphan ");
            List<String> listLop = new List<string>();
            int n = table.Rows.Count;
            int i;
            if (n == 0) return new List<string>();
            for (i = 0; i < n; i++)
            {
                listLop.Add(table.Rows[i]["Ma"].ToString().Trim());
            }

            return listLop;
        }
        public String getMaLopHocPhan(String ma)
        {
            if (ma == "") return "";
            DataTable table = da.Query("Select ma from Lophocphan where ma = '" + ma + "'");
            int n = table.Rows.Count;
            if (n == 1)
            {
                return table.Rows[0]["Ma"].ToString().Trim();
            }

            return "";
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
            else
            return "";
        }

        /*public bool isChecked_GV(String magiaovien, String tengiaovien)
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
        }*/
    }
}
