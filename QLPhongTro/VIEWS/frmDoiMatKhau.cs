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
    public partial class frmDoiMatKhau : Form
    {
        DAL_TaiKhoan db = new DAL_TaiKhoan();
        DataTable dt;
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMaDangNhap.Text = frmDangNhap.MaDangNhap_luu;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtMatKhauCu.Text == "")
            {
                MessageBox.Show("Mật khẩu cũ không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhauCu.Focus();
                return;
            }
            if (txtMatKhauMoi.Text == "")
            {
                MessageBox.Show("Mật khẩu mới không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhauMoi.Focus();
                return;
            }
            if ((txtMatKhauMoi.Text != txtMatKhauNL.Text))
            {
                MessageBox.Show("Nhập lại mật khẩu không trùng khớp", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhauNL.Focus();
                return;
            }
            if (txtMatKhauCu.Text != frmDangNhap.MatKhau_luu)
            {
                MessageBox.Show("Mật khẩu cũ không chính xác", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhauCu.Focus();
                return;
            }
            db.DoiMatKhau(txtMatKhauMoi.Text.Trim(), txtMaDangNhap.Text.Trim());
            MessageBox.Show("Đổi mật khẩu thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            this.Close();
        }

        private void bttThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
