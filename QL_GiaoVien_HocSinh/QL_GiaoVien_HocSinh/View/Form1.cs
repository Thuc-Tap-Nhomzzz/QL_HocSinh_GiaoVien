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
        private string str { get; set; }
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
            //dtgDanhSachHS.Columns["ma"].Width = 100;
            //dtgDanhSachHS.Columns["ten"].Width = 200;
            //dtgDanhSachHS.Columns["email"].Width = 200;
            //dtgDanhSachHS.Columns["gioitinh"].Width = 90;
            //dtgDanhSachHS.Columns["ngaysinh"].Width = 100;
            //dtgDanhSachHS.Columns["Lopma"].Width = 150;
            //dtgDanhSachHS.Columns["DiaChi"].Width = 150;
        }
        private void BtnThemHS_Click(object sender, EventArgs e)
        {
            (new ThemHS()).ShowDialog();
        }

        private void BtnSuaHS_Click(object sender, EventArgs e)
        {
            (new SuaHS()).ShowDialog();
        }

        private void BtnXoaHS_Click(object sender, EventArgs e)
        {
           
        }
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
            dataGridViewQL_GV.Columns["BoMonMa"].HeaderText = "Mã Bộ Môn";
            dataGridViewQL_GV.Columns["NhiemVu"].HeaderText = "Nhiệm vụ";
            dataGridViewQL_GV.Columns["Luong"].HeaderText = "Lương";
            /* dataGridViewQL_GV.Columns["Ma"].Width = 100;
             dataGridViewQL_GV.Columns["Ten"].Width = 200;
             dataGridViewQL_GV.Columns["Email"].Width = 150;
             dataGridViewQL_GV.Columns["GioiTinh"].Width = 100;
             dataGridViewQL_GV.Columns["NgaySinh"].Width = 100;
             dataGridViewQL_GV.Columns["BoMonMa"].Width = 100;*/
        }
        private void BtnThemGV_Click(object sender, EventArgs e)
        {
            (new ThemGV()).ShowDialog();
        }

        private void BtnSuaGV_Click(object sender, EventArgs e)
        {
            (new SuaGV()).ShowDialog();
        }

        private void BtnTimKiemGV_Click(object sender, EventArgs e)
        {
            (new TimKiem()).ShowDialog();
        }

        private void BtnXoaGV_Click(object sender, EventArgs e)
        {

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
        #endregion

    }
}
