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
    public partial class ThemGV : Form
    {
        Controllers _control = new Controllers();
        DataGridView dataGridView;
        DataAccess da = new DataAccess();
        public ThemGV()
        {
            InitializeComponent();
        }
        public ThemGV(DataGridView _dataGridView)
        {
            InitializeComponent();
            dataGridView = _dataGridView;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkAdd())
            {
                GiaoVien gv = new GiaoVien();
                gv.Ma = txtMaGV.Text.ToString().Trim();
                gv.Ten = txtHoTenGV.Text.ToString().Trim();
                if (rbdNam.Checked) gv.GioiTinh = 1;
                else gv.GioiTinh = 0;
                gv.NgaySinh = DateTime.Parse(dtpNgaySinh.Value.ToShortDateString());
                gv.Email = txtEmail.Text.ToString().Trim();
                gv.Luong = int.Parse(txtLuong.Text.ToString().Trim());
                gv.NhiemVu = txtNhiemVu.Text.ToString().Trim();
                gv.SoDienThoai = txtSDT.Text.ToString().Trim();
                gv.BoMonMa = _control.getMaBoMon(cbbBoMon.Text);

                bool themgv= _control.ThemGV(gv);
                if(themgv==true)
                { 
                    DialogResult result = MessageBox.Show("Thêm thành công", "Thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        btnThoat_Click(sender, e);
                    }
                }    
                else
                {
                    MessageBox.Show("Thêm Thất bại, xin bạn xem lại dữ liệu nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnThoat_Click(sender, e);
                }
            }
        }
        private bool checkAdd()
        {

            if (txtMaGV.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("bạn chưa nhập mã giáo viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (DateTime.Parse(dtpNgaySinh.Value.ToShortDateString()) == DateTime.Now)
            {
                MessageBox.Show("bạn chưa nhập chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!(rbdNam.Checked || rbdNu.Checked))
            {
                MessageBox.Show("bạn chưa nhập chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtEmail.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("bạn chưa nhập Mail!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtHoTenGV.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("bạn chưa nhập họ tên giáo viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            if (txtLuong.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("bạn chưa nhập lương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtNhiemVu.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("bạn chưa nhập nhiệm vụ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtSDT.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("bạn chưa nhập số điện thoại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbbBoMon.Text.ToString().Trim().Equals(""))
            {
                MessageBox.Show("bạn chưa chọn Bộ Môn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ThemGV_Load(object sender, EventArgs e)
        {
            cbbBoMon.DataSource = _control.getBoMon();
            txtMaGV.Text = "GV" + da.LaySTT(dataGridView.Rows.Count + 1);
        }
    }
}
