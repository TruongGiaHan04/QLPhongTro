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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void quanLyTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyTaiKhoan frm = new frmQuanLyTaiKhoan();
            frm.ShowDialog();
        }

        private void đôiMâtKhâuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }

        private void quanLyLoaiPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyLoaiPhong frm = new frmQuanLyLoaiPhong();
            frm.ShowDialog();
        }

        private void quanLyPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyPhong frm = new frmQuanLyPhong();
            frm.ShowDialog();
        }

        private void quanLyKhachHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyKhachHang frm = new frmQuanLyKhachHang();
            frm.ShowDialog();
        }

        private void thuêPhongToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmThuePhong frm = new frmThuePhong();
            frm.ShowDialog();
        }

        private void traPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTraPhong frm = new frmTraPhong();
            frm.ShowDialog();
        }

        private void đongTiênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDongTien frm = new frmDongTien();
            frm.ShowDialog();
        }

        private void doanhThuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDoanhThu frm = new frmDoanhThu();
            frm.ShowDialog();
        }

        private void đăngXuâtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
                return;
        }

        private void quanLyGiaThanhPhongTheoThangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyGiaThanh frm = new frmQuanLyGiaThanh();
            frm.ShowDialog();
        }

        private void quanLyTângToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyTang frm = new frmQuanLyTang();
            frm.ShowDialog();
        }
    }
}
