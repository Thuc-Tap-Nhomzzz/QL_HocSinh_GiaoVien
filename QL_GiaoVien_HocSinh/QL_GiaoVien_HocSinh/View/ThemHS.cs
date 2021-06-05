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
    
    public partial class ThemHS : Form
    {
        Controllers _control = new Controllers();
        HocSinh hs = new HocSinh();
        public ThemHS()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkThemHS())
            {
                hs.Ma = txtMaHS.Text.ToString().Trim();
                hs.Ten = txtHoTenHS.Text.ToString().Trim();
                hs.NgaySinh = DateTime.Parse(dtpNgaySinh.Value.ToShortDateString());
                if (rdbnam.Checked)
                    hs.GioiTinh = 1;
                else hs.GioiTinh = 0;
                hs.LopMa = cbbLop.Text.ToString().Trim();
                //hs.LopMa = _control.getMaLopHocPhan(cbbLop.Text.ToString().Trim()).ToString();
                hs.SoDienThoai = txtSDT.Text.ToString().Trim();
                hs.Email = txtEmail.Text.ToString().Trim();
                hs.DanToc = txtDanToc.Text.ToString().Trim();
                hs.DiaChi = txtDiaChi.Text.ToString().Trim();

                bool themhs = _control.ThemHS(hs);
                if (themhs)
                {
                    DialogResult result = MessageBox.Show("Thành công", "Thêm", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        btnThoat_Click(sender, e);
                    }
                }
            }
        }
        private bool checkThemHS()
        {

            if (txtMaHS.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("bạn chưa nhập mã Học Sinh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtHoTenHS.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("bạn chưa nhập tên Học Sinh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbbLop.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("bạn chưa chọn mã lớp cho Học Sinh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtDiaChi.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("bạn chưa nhập Dịa chỉ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtDanToc.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("bạn chưa nhập Dân tộc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        
    }
}
