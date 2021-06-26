
namespace QL_GiaoVien_HocSinh.View
{
    partial class TimKiem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonHocSinh = new System.Windows.Forms.RadioButton();
            this.radioButtonGiaoVien = new System.Windows.Forms.RadioButton();
            this.lbma = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TXTma = new System.Windows.Forms.TextBox();
            this.cbbSearch = new System.Windows.Forms.ComboBox();
            this.dataGridViewDanhSach = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.radioButtonHocSinh);
            this.groupBox1.Controls.Add(this.radioButtonGiaoVien);
            this.groupBox1.Controls.Add(this.lbma);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TXTma);
            this.groupBox1.Controls.Add(this.cbbSearch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 95);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // radioButtonHocSinh
            // 
            this.radioButtonHocSinh.AutoSize = true;
            this.radioButtonHocSinh.Location = new System.Drawing.Point(190, 27);
            this.radioButtonHocSinh.Name = "radioButtonHocSinh";
            this.radioButtonHocSinh.Size = new System.Drawing.Size(69, 17);
            this.radioButtonHocSinh.TabIndex = 18;
            this.radioButtonHocSinh.Text = "Học Sinh";
            this.radioButtonHocSinh.UseVisualStyleBackColor = true;
            // 
            // radioButtonGiaoVien
            // 
            this.radioButtonGiaoVien.AutoSize = true;
            this.radioButtonGiaoVien.Location = new System.Drawing.Point(31, 27);
            this.radioButtonGiaoVien.Name = "radioButtonGiaoVien";
            this.radioButtonGiaoVien.Size = new System.Drawing.Size(71, 17);
            this.radioButtonGiaoVien.TabIndex = 17;
            this.radioButtonGiaoVien.Text = "Giáo Viên";
            this.radioButtonGiaoVien.UseVisualStyleBackColor = true;
            // 
            // lbma
            // 
            this.lbma.AutoSize = true;
            this.lbma.Location = new System.Drawing.Point(587, 27);
            this.lbma.Name = "lbma";
            this.lbma.Size = new System.Drawing.Size(78, 13);
            this.lbma.TabIndex = 16;
            this.lbma.Text = "Nhập từ khóa :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(438, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Danh sách ";
            // 
            // TXTma
            // 
            this.TXTma.Location = new System.Drawing.Point(687, 24);
            this.TXTma.Name = "TXTma";
            this.TXTma.Size = new System.Drawing.Size(165, 20);
            this.TXTma.TabIndex = 15;
            this.TXTma.TextChanged += new System.EventHandler(this.TXTma_TextChanged);
            // 
            // cbbSearch
            // 
            this.cbbSearch.FormattingEnabled = true;
            this.cbbSearch.Location = new System.Drawing.Point(350, 23);
            this.cbbSearch.Name = "cbbSearch";
            this.cbbSearch.Size = new System.Drawing.Size(160, 21);
            this.cbbSearch.TabIndex = 13;
            this.cbbSearch.Text = "Chọn từ khóa tìm kiếm";
            // 
            // dataGridViewDanhSach
            // 
            this.dataGridViewDanhSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDanhSach.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridViewDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDanhSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewDanhSach.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridViewDanhSach.Location = new System.Drawing.Point(0, 95);
            this.dataGridViewDanhSach.Name = "dataGridViewDanhSach";
            this.dataGridViewDanhSach.Size = new System.Drawing.Size(960, 535);
            this.dataGridViewDanhSach.TabIndex = 13;
            // 
            // TimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(960, 450);
            this.Controls.Add(this.dataGridViewDanhSach);
            this.Controls.Add(this.groupBox1);
            this.Name = "TimKiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm Kiếm";
            this.Load += new System.EventHandler(this.TimKiem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbma;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXTma;
        private System.Windows.Forms.ComboBox cbbSearch;
        private System.Windows.Forms.DataGridView dataGridViewDanhSach;
        private System.Windows.Forms.RadioButton radioButtonHocSinh;
        private System.Windows.Forms.RadioButton radioButtonGiaoVien;
    }
}