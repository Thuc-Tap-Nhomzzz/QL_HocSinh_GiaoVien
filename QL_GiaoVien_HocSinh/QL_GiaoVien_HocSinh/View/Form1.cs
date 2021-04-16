using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_GiaoVien_HocSinh.View;
using QL_GiaoVien_HocSinh.Models;
using QL_GiaoVien_HocSinh.Controller;

namespace QL_GiaoVien_HocSinh
{
    public partial class FrmMain : Form
    {
        Controllers _control = new Controllers();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Load_gv();
            Load_hs();
            Load_quanly();
        }
        private void BtnQLHS_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPageQLHS;
        }

        private void BtnQLGV_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPageQLGV;

        }

        private void labelqlhs_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPageQLHS;

        }

        private void labelqlgv_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPageQLGV;

        }

        private void BtnQLGD_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPageQLGD;

        }

        private void BtnHD_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPageHD;

        }

        private void labelqlgd_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPageQLGD;

        }

        private void labelhuongdan_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPageHD;

        }

        private void BtnThoatHS_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPage1;
        }

        private void BtnThoatGV_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPage1;
        }
        private void btnThoatQL_GD_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPage1;
        }
        #region học sinh
        HocSinh hs = new HocSinh();
        private void Load_hs()
        {
            dataGridViewQL_HS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewQL_HS.DataSource = _control.getListHocSinh();

            dataGridViewQL_HS.Columns["Ma"].HeaderText = "Mã";
            dataGridViewQL_HS.Columns["Ten"].HeaderText = "Họ tên";
            dataGridViewQL_HS.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dataGridViewQL_HS.Columns["GioiTinh"].HeaderText = "Giới tính";
            dataGridViewQL_HS.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dataGridViewQL_HS.Columns["LopMa"].HeaderText = "Mã lớp học phần";
            dataGridViewQL_HS.Columns["Email"].HeaderText = "Email";
            dataGridViewQL_HS.Columns["DanToc"].HeaderText = "Dân Tộc";
            dataGridViewQL_HS.Columns["SoDienThoai"].HeaderText = "Điện thoại";
            //dataGridViewQL_HS.Columns["ma"].Width = 100;
            //dataGridViewQL_HS.Columns["ten"].Width = 200;
            //dataGridViewQL_HS.Columns["email"].Width = 200;
            //dataGridViewQL_HS.Columns["gioitinh"].Width = 90;
            //dataGridViewQL_HS.Columns["ngaysinh"].Width = 100;
            //dataGridViewQL_HS.Columns["Lopma"].Width = 150;
            //dataGridViewQL_HS.Columns["DiaChi"].Width = 150;
        }
       
        public void Load_lai_hs()
        {
            dataGridViewQL_HS.DataSource = _control.getListHocSinh();
        }
        #region Phần của Nghĩa
        private void BtnThemHS_Click(object sender, EventArgs e)
        {
            (new ThemHS()).ShowDialog();
            Load_lai_hs();
        }
        #endregion
        #region Phần của Chung
        private void BtnSuaHS_Click(object sender, EventArgs e)
        {
            //ma, ten, gt, ns, mail,dantoc,dt,malop, diachi
            hs.Ma = dataGridViewQL_HS.Rows[dataGridViewQL_HS.CurrentRow.Index].Cells[0].Value.ToString();
            hs.Ten = dataGridViewQL_HS.Rows[dataGridViewQL_HS.CurrentRow.Index].Cells[1].Value.ToString();
            hs.GioiTinh = 1;
            /*if (bool.Parse(dataGridViewQL_HS.Rows[dataGridViewQL_HS.CurrentRow.Index].Cells[2].Value.ToString()))
            {
                hs.GioiTinh = 1;
            }
            else hs.GioiTinh = 0;*/
            DateTime ns = DateTime.Now;
            if (DateTime.TryParse(dataGridViewQL_HS.Rows[dataGridViewQL_HS.CurrentRow.Index].Cells[3].Value.ToString(), out ns))
            {
                hs.NgaySinh = ns;
            }
            hs.NgaySinh = ns;
            hs.Email = dataGridViewQL_HS.Rows[dataGridViewQL_HS.CurrentRow.Index].Cells[4].Value.ToString();
            hs.DanToc = dataGridViewQL_HS.Rows[dataGridViewQL_HS.CurrentRow.Index].Cells[5].Value.ToString();

            hs.SoDienThoai = dataGridViewQL_HS.Rows[dataGridViewQL_HS.CurrentRow.Index].Cells[6].Value.ToString();
            hs.LopMa = dataGridViewQL_HS.Rows[dataGridViewQL_HS.CurrentRow.Index].Cells[7].Value.ToString();
            hs.DiaChi = dataGridViewQL_HS.Rows[dataGridViewQL_HS.CurrentRow.Index].Cells[8].Value.ToString();

            (new SuaHS(hs)).ShowDialog();
            Load_lai_hs();
        }
        #endregion
        #region Phần của anh Trung
        private void BtnXoaHS_Click(object sender, EventArgs e)
        {
            hs.Ma = dataGridViewQL_HS.Rows[dataGridViewQL_HS.CurrentRow.Index].Cells[0].Value.ToString();
            hs.Ten = dataGridViewQL_HS.Rows[dataGridViewQL_HS.CurrentRow.Index].Cells[1].Value.ToString();
            DialogResult xoa = MessageBox.Show("Bạn chắc chắn muốn xóa Học sinh: " + hs.Ten + " có mã là: " + hs.Ma + " chứ", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //bool xoahs = _control.XoaHS(hs.Ma);
            if (_control.XoaHS(hs.Ma) && xoa == DialogResult.Yes)
            {
                DialogResult result = MessageBox.Show("Thành công", "Xóa", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    Load_lai_hs();
                }
            }
        }
        #endregion
        private void BtnTimKiemHS_Click(object sender, EventArgs e)
        {
            (new TimKiem()).ShowDialog();
        }
        #endregion

        #region Giáo Viên
        private void Load_gv()
        {
            dataGridViewQL_GV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewQL_GV.DataSource = _control.getListGiaoVien();

            dataGridViewQL_GV.Columns["Ma"].HeaderText = "Mã";
            dataGridViewQL_GV.Columns["Ten"].HeaderText = "Họ tên";
            dataGridViewQL_GV.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dataGridViewQL_GV.Columns["GioiTinh"].HeaderText = "Giới tính";
            dataGridViewQL_GV.Columns["Email"].HeaderText = "Email";
            dataGridViewQL_GV.Columns["SoDienThoai"].HeaderText = "Điện thoại";
            dataGridViewQL_GV.Columns["BoMonMa"].HeaderText = "Bộ Môn";
            dataGridViewQL_GV.Columns["NhiemVu"].HeaderText = "Nhiệm vụ";
            dataGridViewQL_GV.Columns["Luong"].HeaderText = "Lương";
            /* dataGridViewQL_GV.Columns["Ma"].Width = 100;
             dataGridViewQL_GV.Columns["Ten"].Width = 200;
             dataGridViewQL_GV.Columns["Email"].Width = 150;
             dataGridViewQL_GV.Columns["GioiTinh"].Width = 100;
             dataGridViewQL_GV.Columns["NgaySinh"].Width = 100;
             dataGridViewQL_GV.Columns["BoMonMa"].Width = 100;*/
        }
        public void Load_lai_gv()
        {
            dataGridViewQL_GV.DataSource = _control.getListGiaoVien();
        }
        #region Phần của Nghĩa
        private void BtnThemGV_Click(object sender, EventArgs e)
        {
            (new ThemGV()).ShowDialog();
            Load_lai_gv();
        }
        #endregion
        #region Phần của Chung
        private void BtnSuaGV_Click(object sender, EventArgs e)
        {
            // max, teen, gioi tinh, ngayf sinh, email, luong, nhiemvu, dt, mabm
            GiaoVien gv = new GiaoVien();
            int index = dataGridViewQL_GV.CurrentCell == null ? -1 : dataGridViewQL_GV.CurrentCell.RowIndex;
            if (index != -1)
            {
                gv.Ma = dataGridViewQL_GV.Rows[index].Cells[0].Value.ToString();
                gv.Ten = dataGridViewQL_GV.Rows[index].Cells[1].Value.ToString();
                gv.GioiTinh = 1;
                /*if (bool.Parse(dataGridViewQL_GV.Rows[index].Cells[2].Value.ToString()))
                {
                    gv.GioiTinh = 1;
                }
                else gv.GioiTinh = 0;*/
                DateTime ns = DateTime.Now;
                if (DateTime.TryParse(dataGridViewQL_GV.Rows[index].Cells[3].Value.ToString(), out ns))
                {
                    gv.NgaySinh = ns;
                }
                gv.Email = dataGridViewQL_GV.Rows[index].Cells[4].Value.ToString();
                gv.Luong = int.Parse(dataGridViewQL_GV.Rows[index].Cells[5].Value.ToString());
                gv.NhiemVu = dataGridViewQL_GV.Rows[index].Cells[6].Value.ToString();
                gv.SoDienThoai = dataGridViewQL_GV.Rows[index].Cells[7].Value.ToString();
                gv.BoMonMa = dataGridViewQL_GV.Rows[index].Cells[8].Value.ToString();
            }
            (new SuaGV(gv)).ShowDialog();
            Load_lai_gv();
        }
        #endregion
        #region Phần của anh Trung
        private void BtnXoaGV_Click(object sender, EventArgs e)
        {
            GiaoVien gv = new GiaoVien();
            gv.Ma = dataGridViewQL_GV.Rows[dataGridViewQL_GV.CurrentRow.Index].Cells[0].Value.ToString();
            //gv.Ten = dataGridViewQL_GV.Rows[dataGridViewQL_GV.CurrentRow.Index].Cells[1].Value.ToString();
            DialogResult xoa = MessageBox.Show( "Bạn chắc chắn muốn xóa Giáo Viên: " + gv.Ten + " có mã là: " + gv.Ma+ " chứ", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //bool xoagv = _control.XoaGV(gv.Ma);
            if (_control.XoaGV(gv.Ma) && xoa == DialogResult.Yes)
            {
                DialogResult result = MessageBox.Show("Thành công", "Xóa", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    Load_lai_gv();
                }
            }
        }
        #endregion
        private void BtnTimKiemGV_Click(object sender, EventArgs e)
        {
            (new TimKiem()).ShowDialog();
        }
        #endregion

        #region Giảng Dạy
        private void Load_quanly()
        {
            //dataGridViewQL_GiangDay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewQL_GiangDay.DataSource = _control.getList_Lophophan();
            dataGridViewQL_GiangDay.Columns["Ma"].HeaderText = "Mã lớp học phần";
            dataGridViewQL_GiangDay.Columns["Ten"].HeaderText = "Tên môn học";
            dataGridViewQL_GiangDay.Columns["MonHocMa"].HeaderText = "Mã môn học";
            dataGridViewQL_GiangDay.Columns["HocKy"].HeaderText = "Học kỳ";
            dataGridViewQL_GiangDay.Columns["NamHoc"].HeaderText = "Năm học";
            dataGridViewQL_GiangDay.Columns["SiSo"].HeaderText = "Sĩ số";
            dataGridViewQL_GiangDay.Columns["Thu"].HeaderText = "Thứ";
            dataGridViewQL_GiangDay.Columns["Tiet"].HeaderText = "Tiết";
           // dataGridViewQL_GiangDay.Columns["NgayBD"].HeaderText = "Ngày bắt đầu";
            //dataGridViewQL_GiangDay.Columns["NgayKT"].HeaderText = "Ngày kết thúc";
            dataGridViewQL_GiangDay.Columns["NgayThi"].HeaderText = "Ngày thi";
            dataGridViewQL_GiangDay.Columns["GiaoVienMa"].HeaderText = "Giáo viên mã";
            dataGridViewQL_GiangDay.Columns["GiaoVienTen"].HeaderText = "Giáo viên";
            dataGridViewQL_GiangDay.Columns["HocKy"].Width = 70;
            dataGridViewQL_GiangDay.Columns["SiSo"].Width = 55;
            dataGridViewQL_GiangDay.Columns["Thu"].Width = 45;
            dataGridViewQL_GiangDay.Columns["Tiet"].Width = 45;
            dataGridViewQL_GiangDay.Columns["GiaoVienTen"].Width = 150;
            dataGridViewQL_GiangDay.Columns["Ten"].Width = 150;
        }
        private void dataGridViewQL_GiangDay_SelectionChanged(object sender, EventArgs e)
        {
            // Mã lớp học phần, tên môn học, mã môn học, học kỳ, năm học, sĩ số, thứ, tiết,
            // ngày bắt đầu, ngày kết thuc, ngày thi, mã giáo viên, giáo viên
            tbQuanLyGD_MaLHP.Enabled = false;
            tbQuanLyGD_TenMonHoc.Enabled = false;
            tbQuanLyGD_GiaoVienMa.Enabled = false;
            tbQuanLyGD_GiaoVienTen.Enabled = false;
            tbQuanLyGD_MaLHP.Enabled = false;
            tbQuanLyGD_MaLHP.Enabled = false;
            tbQuanLyGD_MaLHP.Enabled = false;
            int index = dataGridViewQL_GiangDay.CurrentCell == null ? -1 : dataGridViewQL_GiangDay.CurrentCell.RowIndex;
            if (index != -1)
            {
                tbQuanLyGD_MaLHP.Text = dataGridViewQL_GiangDay.Rows[index].Cells[0].Value.ToString();
                tbQuanLyGD_TenMonHoc.Text = dataGridViewQL_GiangDay.Rows[index].Cells[1].Value.ToString();
                tbQuanLyGD_HocKy.Text = dataGridViewQL_GiangDay.Rows[index].Cells[3].Value.ToString();
                tbQuanLyGD_NamHoc.Text = dataGridViewQL_GiangDay.Rows[index].Cells[4].Value.ToString();
                tbQuanLyGD_SiSo.Text = dataGridViewQL_GiangDay.Rows[index].Cells[5].Value.ToString();
                tbQuanLyGD_Thu.Text = dataGridViewQL_GiangDay.Rows[index].Cells[6].Value.ToString();
                tbQuanLyGD_Tiet.Text = dataGridViewQL_GiangDay.Rows[index].Cells[7].Value.ToString();
                dtpNgayBD.Text = dataGridViewQL_GiangDay.Rows[index].Cells[8].Value.ToString();
                dtpNgayKT.Text = dataGridViewQL_GiangDay.Rows[index].Cells[9].Value.ToString();
                dtpNgayThi.Text = dataGridViewQL_GiangDay.Rows[index].Cells[10].Value.ToString();
                tbQuanLyGD_GiaoVienMa.Text = dataGridViewQL_GiangDay.Rows[index].Cells[11].Value.ToString();
                tbQuanLyGD_GiaoVienTen.Text = dataGridViewQL_GiangDay.Rows[index].Cells[12].Value.ToString();

            }
        }
            #endregion


        
    }
}
