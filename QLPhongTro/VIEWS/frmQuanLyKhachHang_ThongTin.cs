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
    public partial class frmQuanLyKhachHang_ThongTin : Form
    {
        DAL_KhachHang db = new DAL_KhachHang();
        public frmQuanLyKhachHang_ThongTin()
        {
            InitializeComponent();
        }
        private void btnNhan_Click(object sender, EventArgs e)
        {
            if (txtMaKhachHang.Text == "")
            {
                MessageBox.Show("Mã khách hàng không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKhachHang.Focus();
                return;
            }
            if (txtTenKhachHang.Text == "")
            {
                MessageBox.Show("Tên khách hàng không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenKhachHang.Focus();
                return;
            }
            if (frmQuanLyKhachHang.save == true)
            {
                if (db.KiemTraDuLieuTonTai(txtMaKhachHang.Text) == 0)
                {
                    MessageBox.Show("Thêm thất bại, Khách hàng này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.Them(txtMaKhachHang.Text.Trim(), txtTenKhachHang.Text.Trim(), txtDienThoai.Text.Trim(), txtDiaChi.Text.Trim(), txtCMND.Text.Trim(),txtEmail.Text);
                MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            if (frmQuanLyKhachHang.save == false)
            {
                if (db.KiemTraDuLieuTonTai(txtMaKhachHang.Text) == 0 && txtMaKhachHang.Text != frmQuanLyKhachHang.MaKhachHang)
                {
                    MessageBox.Show("Sửa thất bại, Khách hàng này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.Sua(txtMaKhachHang.Text.Trim(), frmQuanLyKhachHang.MaKhachHang, txtTenKhachHang.Text.Trim(), txtDienThoai.Text.Trim(), txtDiaChi.Text.Trim(), txtCMND.Text.Trim(), txtEmail.Text);
                MessageBox.Show("Sửa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
        }

        private void bttThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQuanLyKhachHang_ThongTin_Load(object sender, EventArgs e)
        {
        }
    }
}
