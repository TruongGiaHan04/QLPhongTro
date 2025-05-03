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
    public partial class frmQuanLyTaiKhoan_ThongTin : Form
    {
       DAL_TaiKhoan db = new DAL_TaiKhoan();
        public frmQuanLyTaiKhoan_ThongTin()
        {
            InitializeComponent();
        }

        private void frmQuanLyTaiKhoan_ThongTin_Load(object sender, EventArgs e)
        {
            if (frmQuanLyTaiKhoan.save == false)
            {
                txtMatKhau.Text = frmQuanLyTaiKhoan.MatKhau;
                txtMatKhauNL.Text = txtMatKhau.Text;
            }
        }
        private void btnNhan_Click(object sender, EventArgs e)
        {
            if (txtMaDangNhap.Text == "")
            {
                MessageBox.Show("Mã đăng nhập không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDangNhap.Focus();
                return;
            }
            if (txtTenNguoiDung.Text == "")
            {
                MessageBox.Show("Tên người dùng không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNguoiDung.Focus();
                return;
            }
            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Mật khẩu không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
                return;
            }
            if ((txtMatKhau.Text != txtMatKhauNL.Text))
            {
                MessageBox.Show("Nhập lại mật khẩu không trùng khớp", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhauNL.Focus();
                return;
            }
            if (frmQuanLyTaiKhoan.save == true)
            {
                if (db.KiemTraDuLieuTonTai(txtMaDangNhap.Text) == 0)
                {
                    MessageBox.Show("Thêm thất bại, Tài khoản này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.Them(txtMaDangNhap.Text.Trim(), txtTenNguoiDung.Text.Trim(), txtMatKhau.Text.Trim());
                MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            if (frmQuanLyTaiKhoan.save == false)
            {
                if (db.KiemTraDuLieuTonTai(txtMaDangNhap.Text) == 0 && txtMaDangNhap.Text != frmQuanLyTaiKhoan.MaDangNhap)
                {
                    MessageBox.Show("Sửa thất bại, Tài khoản này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.Sua(txtMaDangNhap.Text.Trim(), frmQuanLyTaiKhoan.MaDangNhap, txtTenNguoiDung.Text.Trim(), txtMatKhau.Text.Trim());
                MessageBox.Show("Sửa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
        }

        private void bttThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
