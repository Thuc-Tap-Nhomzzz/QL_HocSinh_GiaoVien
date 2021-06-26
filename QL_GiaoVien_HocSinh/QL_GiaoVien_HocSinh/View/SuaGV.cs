using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_GiaoVien_HocSinh.Models;
using QL_GiaoVien_HocSinh.View;
using QL_GiaoVien_HocSinh.Controller;

namespace QL_GiaoVien_HocSinh.View
{
    public partial class SuaGV : Form
    {
        Controllers _control = new Controllers();
        GiaoVien gv = new GiaoVien();
        public SuaGV()
        {
            InitializeComponent();
        }

        public SuaGV(GiaoVien _gv)
        {
            InitializeComponent();
            gv = _gv;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SuaGV_Load(object sender, EventArgs e)
        {
            txtMaGV.Enabled = false;
            txtMaGV.Text = gv.Ma;
            txtHoTenGV.Text = gv.Ten;
            if (gv.GioiTinh == 1)
            {
                rbdNam.Checked = true;
            }
            else rbdNu.Checked = true;
            if (gv.NgaySinh != null)
                dtpNgaySinh.Text = gv.NgaySinh.ToString();
            txtLuong.Text = gv.Luong.ToString();
            txtEmail.Text = gv.Email;
            txtSDT.Text = gv.SoDienThoai;
            cbbBoMon.DataSource = _control.getBoMon();
            cbbBoMon.Text = _control.getBoMon(gv.Ma);
            txtNhiemVu.Text = gv.NhiemVu;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
                gv.Ma = txtMaGV.Text.ToString().Trim();
                gv.Ten = txtHoTenGV.Text.ToString().Trim();
                gv.NgaySinh = dtpNgaySinh.Value;
                if (rbdNam.Checked)
                    gv.GioiTinh = 1;
                else gv.GioiTinh = 0;

                gv.Email = txtEmail.Text.ToString().Trim();
                gv.Luong = int.Parse(txtLuong.Text);
                gv.NhiemVu = txtNhiemVu.Text.ToString().Trim();
                gv.SoDienThoai = txtSDT.Text.ToString().Trim();
                gv.BoMonMa = _control.getMaBoMon(cbbBoMon.Text.ToString().Trim()).ToString();
                if (_control.update_gv(gv))
                {
                    DialogResult result = MessageBox.Show("Thành công", "Chỉnh sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        btnThoat_Click(sender, e);
                    }
                }
            else
            {
                MessageBox.Show("Sửa Thất bại, xin bạn xem lại thao tác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnThoat_Click(sender, e);
            }

        }

    }
}
