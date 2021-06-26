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
    public partial class SuaHS : Form
    {
        Controllers _control = new Controllers();
        HocSinh hs;

        public SuaHS()
        {
            InitializeComponent();
        }
        
        public SuaHS(HocSinh _hs)
        {
            InitializeComponent();
            hs = _hs;
        }

        private void SuaHS_Load(object sender, EventArgs e)
        {
            txtMaHS.Enabled = false;
            txtMaHS.Text = hs.Ma;
            txtHoTenHS.Text = hs.Ten;
            if (hs.GioiTinh == 1)
            {
                rdbnam.Checked = true;
            }
            else rdbNu.Checked = true;
            if (hs.NgaySinh != null)
                dtpNgaySinh.Text = hs.NgaySinh.ToString();
            txtDanToc.Text = hs.DanToc.ToString();
            txtEmail.Text = hs.Email;
            cbbLop.DataSource = _control.getMaLopHocPhan();
            cbbLop.Text = _control.getMaLopHocPhan(hs.LopMa);
            txtSDT.Text = hs.SoDienThoai;
            txtDiaChi.Text = hs.DanToc;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            txtMaHS.Enabled = true;
            hs.Ma = txtMaHS.Text;
            hs.Ten = txtHoTenHS.Text.ToString().Trim();
            hs.NgaySinh = DateTime.Parse(dtpNgaySinh.Value.ToShortDateString());
            if (rdbnam.Checked)
                hs.GioiTinh = 1;
            else hs.GioiTinh = 0;
            hs.LopMa = _control.getMaLopHocPhan(cbbLop.Text.ToString().Trim()).ToString();
            hs.SoDienThoai = txtSDT.Text.ToString().Trim();
            hs.Email = txtEmail.Text.ToString().Trim();
            hs.DanToc = txtDanToc.Text.ToString().Trim();
            hs.DiaChi = txtDiaChi.Text.ToString().Trim();

            bool suahs=_control.update_hs(hs);
            if (suahs)
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
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
