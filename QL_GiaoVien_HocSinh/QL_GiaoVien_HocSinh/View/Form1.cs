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

namespace QL_GiaoVien_HocSinh
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
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

        private void btnThoatQL_GD_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPage1;
        }
    }
}
