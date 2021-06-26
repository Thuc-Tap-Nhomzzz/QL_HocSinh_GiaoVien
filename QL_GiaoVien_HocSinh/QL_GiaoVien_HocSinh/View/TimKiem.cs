using QL_GiaoVien_HocSinh.Controller;
using QL_GiaoVien_HocSinh.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_GiaoVien_HocSinh.View
{
    public partial class TimKiem : Form
    {
        DataAccess da = new DataAccess();
        Controllers _control = new Controllers();
        string a;
        public TimKiem()
        {
            InitializeComponent();
        }
        public TimKiem(string _a)
        {
            InitializeComponent();
            a = _a;
        }
        private void TXTma_TextChanged(object sender, EventArgs e)
        {
            string tim = TXTma.Text;
            if (radioButtonHocSinh.Checked == true)
            {
                if (cbbSearch.Text.Equals("Tìm kiếm theo mã"))
                {
                    dataGridViewDanhSach.DataSource = _control.getListHocSinhTheoMa(tim);
                }
                else if (cbbSearch.Text.Equals("Tìm kiếm theo tên"))
                {
                    dataGridViewDanhSach.DataSource = _control.getListHocSinhTheoTen(tim);
                }
                else if (cbbSearch.Text.Equals("Tìm kiếm theo dân tộc"))
                {
                    dataGridViewDanhSach.DataSource = _control.getListHocSinhTheoDanToc(tim);
                }
                else if (cbbSearch.Text.Equals("Tìm kiếm theo giới tính"))
                {
                    dataGridViewDanhSach.DataSource = _control.getListHocSinhTheoGioiTinh(tim);
                }
                else if (cbbSearch.Text.Equals("Tìm kiếm theo địa chỉ"))
                {
                    dataGridViewDanhSach.DataSource = _control.getListHocSinhTheoDiaChi(tim);
                }
                else if (cbbSearch.Text.Equals("Tìm kiếm theo lớp"))
                {
                    dataGridViewDanhSach.DataSource = _control.getListHocSinhTheoLop(tim);
                }
            }
            else if(radioButtonGiaoVien.Checked.Equals(true))
            {
                if (cbbSearch.Text.Equals("Tìm kiếm theo mã"))
                {
                    dataGridViewDanhSach.DataSource = _control.getListGiaoVienTheoMa(tim);
                }
                else if (cbbSearch.Text.Equals("Tìm kiếm theo tên"))
                {
                    dataGridViewDanhSach.DataSource = _control.getListGiaoVienTheoTen(tim);
                }

                else if (cbbSearch.Text.Equals("Tìm kiếm theo giới tính"))
                {
                    dataGridViewDanhSach.DataSource = _control.getListGiaoVienTheoGT(tim);
                }

                else if (cbbSearch.Text.Equals("Tìm kiếm theo bộ môn"))
                {
                    dataGridViewDanhSach.DataSource = _control.getListGiaoVienTheoBoMon(tim);
                }
            }    

        }

        private void TimKiem_Load(object sender, EventArgs e)
        {
            if(a =="hocsinh")
            {
                dataGridViewDanhSach.DataSource = _control.getListHocSinh();
                radioButtonHocSinh.Checked = true;
                cbbSearch.Items.Add("Tìm kiếm theo mã");
                cbbSearch.Items.Add("Tìm kiếm theo tên");
                cbbSearch.Items.Add("Tìm kiếm theo lớp");
                cbbSearch.Items.Add("Tìm kiếm theo dân tộc");
                cbbSearch.Items.Add("Tìm kiếm theo giới tính");
                cbbSearch.Items.Add("Tìm kiếm theo địa chỉ");
                radioButtonGiaoVien.Enabled = false;
            }   
            else if(a=="giaovien")
            {
                dataGridViewDanhSach.DataSource = _control.getListGiaoVien();
                radioButtonGiaoVien.Checked = true;
                cbbSearch.Items.Add("Tìm kiếm theo mã");
                cbbSearch.Items.Add("Tìm kiếm theo tên");
                cbbSearch.Items.Add("Tìm kiếm theo bộ môn");
                cbbSearch.Items.Add("Tìm kiếm theo giới tính");
                radioButtonHocSinh.Enabled = false;
            }    
        }
    }
}
