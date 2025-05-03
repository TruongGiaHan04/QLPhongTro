using QLPhongTro.DAL;
using QLPhongTro.VIEWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongTro
{
    public partial class frmDangNhap : Form
    {
        DAL_TaiKhoan db = new DAL_TaiKhoan();
        public static string MaDangNhap_luu;
        public static string MatKhau_luu;
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void bttThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
                return;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtMaDangNhap.Text == "")
            {
                MessageBox.Show("Mã đăng nhập không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDangNhap.Focus();
                return;
            }
            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Mật khẩu không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
                return;
            }
            DataTable dt = new DataTable();
            dt = db.DangNhap(txtMaDangNhap.Text.Trim(), txtMatKhau.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                frmMain frm = new frmMain();
                MaDangNhap_luu = txtMaDangNhap.Text;
                MatKhau_luu = txtMatKhau.Text;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không đúng tên người dùng hoặc mật khẩu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDangNhap.Focus();
            }
        }
    }
}
