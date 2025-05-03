using QLPhongTro.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongTro.VIEWS
{
    public partial class frmDoanhThu : Form
    {
        DAL_DoanhThu db = new DAL_DoanhThu();
        public frmDoanhThu()
        {
            InitializeComponent();
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            nmNam1.Value = DateTime.Now.Year;
            nmThang1.Value = DateTime.Now.Month;
        }
        private void DanhSach(decimal ThangFrom, decimal NamFrom)
        {
            DataTable dt = db.DoanhThu(ThangFrom, NamFrom);
            grdTheoThang.DataSource = dt;
            grdTheoThang.Columns[0].HeaderText = "Tháng";
            grdTheoThang.Columns[1].HeaderText = "Năm";
            grdTheoThang.Columns[2].HeaderText = "Mã phòng";
            grdTheoThang.Columns[3].HeaderText = "Tiền phòng";
            grdTheoThang.Columns[4].HeaderText = "Số điện";
            grdTheoThang.Columns[5].HeaderText = "Giá điện";
            grdTheoThang.Columns[6].HeaderText = "Tổng tiền điện";
            grdTheoThang.Columns[7].HeaderText = "Số nước";
            grdTheoThang.Columns[8].HeaderText = "Giá nước";
            grdTheoThang.Columns[9].HeaderText = "Tổng tiền nước";
            grdTheoThang.Columns[10].HeaderText = "Tiền Wifi";
            grdTheoThang.Columns[11].HeaderText = "Tiền rác";
            grdTheoThang.Columns[12].HeaderText = "Chi phí khác";
            grdTheoThang.Columns[13].HeaderText = "Tổng tiền";
            grdTheoThang.Columns[14].HeaderText = "Trạng thái thanh toán";
            grdTheoThang.Columns[0].Width = 120;
            grdTheoThang.Columns[1].Width = 200;
            grdTheoThang.Columns[2].Width = 120;
            grdTheoThang.Columns[3].Width = 120;
            grdTheoThang.Columns[4].Width = 120;
            grdTheoThang.Columns[5].Width = 120;
            grdTheoThang.Columns[6].Width = 120;
            grdTheoThang.Columns[7].Width = 120;
            grdTheoThang.Columns[8].Width = 120;
            grdTheoThang.Columns[9].Width = 120;
            grdTheoThang.Columns[10].Width = 120;
            grdTheoThang.Columns[11].Width = 120;
            grdTheoThang.Columns[12].Width = 120;
            grdTheoThang.Columns[13].Width = 120;
            grdTheoThang.Columns[14].Width = 160;
        }

        private void btnSearchMonth_Click(object sender, EventArgs e)
        {
            DanhSach(nmThang1.Value, nmNam1.Value);
            if (grdTheoThang.Rows.Count == 0)
            {
                txtTongDoanhThuThang.Text = "0 VND";
                txtTongDoanhThuThang.ForeColor = SystemColors.HotTrack;
                return;
            }
            int tien = grdTheoThang.Rows.Count;
            decimal thanhtien = 0;
            for (int i = 0; i < tien; i++)
            {
                thanhtien += decimal.Parse(grdTheoThang.Rows[i].Cells["TongTien"].Value.ToString());
            }
            txtTongDoanhThuThang.Text = thanhtien.ToString("#,###") + " VND";
            if (txtTongDoanhThuThang.Text == " VND")
            {
                txtTongDoanhThuThang.Text = "0 VND";
            }
        }
    }
}
