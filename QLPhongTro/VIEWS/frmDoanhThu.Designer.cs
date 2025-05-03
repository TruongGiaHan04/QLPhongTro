
namespace QLPhongTro.VIEWS
{
    partial class frmDoanhThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoanhThu));
            this.grdTheoThang = new System.Windows.Forms.DataGridView();
            this.nmNam1 = new System.Windows.Forms.NumericUpDown();
            this.nmThang1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTongDoanhThuThang = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearchMonth = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdTheoThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmNam1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmThang1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTheoThang
            // 
            this.grdTheoThang.AllowUserToAddRows = false;
            this.grdTheoThang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTheoThang.BackgroundColor = System.Drawing.Color.White;
            this.grdTheoThang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTheoThang.Location = new System.Drawing.Point(2, 51);
            this.grdTheoThang.Name = "grdTheoThang";
            this.grdTheoThang.Size = new System.Drawing.Size(894, 465);
            this.grdTheoThang.TabIndex = 243;
            // 
            // nmNam1
            // 
            this.nmNam1.Location = new System.Drawing.Point(317, 20);
            this.nmNam1.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.nmNam1.Name = "nmNam1";
            this.nmNam1.Size = new System.Drawing.Size(53, 20);
            this.nmNam1.TabIndex = 252;
            this.nmNam1.Value = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            // 
            // nmThang1
            // 
            this.nmThang1.Location = new System.Drawing.Point(259, 20);
            this.nmThang1.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.nmThang1.Name = "nmThang1";
            this.nmThang1.Size = new System.Drawing.Size(56, 20);
            this.nmThang1.TabIndex = 251;
            this.nmThang1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 16);
            this.label3.TabIndex = 276;
            this.label3.Text = "Doanh thu phòng theo tháng";
            // 
            // txtTongDoanhThuThang
            // 
            this.txtTongDoanhThuThang.BackColor = System.Drawing.Color.Red;
            this.txtTongDoanhThuThang.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTongDoanhThuThang.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongDoanhThuThang.ForeColor = System.Drawing.Color.Black;
            this.txtTongDoanhThuThang.Location = new System.Drawing.Point(781, 17);
            this.txtTongDoanhThuThang.Name = "txtTongDoanhThuThang";
            this.txtTongDoanhThuThang.ReadOnly = true;
            this.txtTongDoanhThuThang.Size = new System.Drawing.Size(115, 22);
            this.txtTongDoanhThuThang.TabIndex = 279;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(659, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 16);
            this.label5.TabIndex = 278;
            this.label5.Text = "Tổng doanh thu";
            // 
            // btnSearchMonth
            // 
            this.btnSearchMonth.BackColor = System.Drawing.Color.White;
            this.btnSearchMonth.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchMonth.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchMonth.Image")));
            this.btnSearchMonth.Location = new System.Drawing.Point(381, 10);
            this.btnSearchMonth.Name = "btnSearchMonth";
            this.btnSearchMonth.Size = new System.Drawing.Size(104, 35);
            this.btnSearchMonth.TabIndex = 291;
            this.btnSearchMonth.Text = "Lọc dữ liệu";
            this.btnSearchMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearchMonth.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchMonth.UseVisualStyleBackColor = false;
            this.btnSearchMonth.Click += new System.EventHandler(this.btnSearchMonth_Click);
            // 
            // frmDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(109)))), ((int)(((byte)(178)))));
            this.ClientSize = new System.Drawing.Size(898, 518);
            this.Controls.Add(this.btnSearchMonth);
            this.Controls.Add(this.txtTongDoanhThuThang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nmNam1);
            this.Controls.Add(this.nmThang1);
            this.Controls.Add(this.grdTheoThang);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê doanh thu";
            this.Load += new System.EventHandler(this.frmDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTheoThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmNam1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmThang1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdTheoThang;
        private System.Windows.Forms.NumericUpDown nmNam1;
        private System.Windows.Forms.NumericUpDown nmThang1;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtTongDoanhThuThang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearchMonth;
    }
}