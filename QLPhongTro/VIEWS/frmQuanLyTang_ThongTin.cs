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
    public partial class frmQuanLyTang_ThongTin : Form
    {
        DAL_Tang db = new DAL_Tang();
        public frmQuanLyTang_ThongTin()
        {
            InitializeComponent();
        }

        private void frmQuanLyTang_ThongTin_Load(object sender, EventArgs e)
        {

        }
        private void btnNhan_Click(object sender, EventArgs e)
        {
            if (txtMaTang.Text == "")
            {
                MessageBox.Show("Mã tầng không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaTang.Focus();
                return;
            }
            if (txtTenTang.Text == "")
            {
                MessageBox.Show("Tên tầng không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenTang.Focus();
                return;
            }
            if (frmQuanLyTang.save == true)
            {
                if (db.KiemTraDuLieuTonTai(txtMaTang.Text) == 0)
                {
                    MessageBox.Show("Thêm thất bại, Tầng này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.Them(txtMaTang.Text.Trim(), txtTenTang.Text.Trim(), txtGhiChu.Text.Trim());
                MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            if (frmQuanLyTang.save == false)
            {
                if (db.KiemTraDuLieuTonTai(txtMaTang.Text) == 0 && txtMaTang.Text != frmQuanLyTang.MaTang)
                {
                    MessageBox.Show("Sửa thất bại,Tầng này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.Sua(txtMaTang.Text.Trim(), frmQuanLyTang.MaTang, txtTenTang.Text.Trim(), txtGhiChu.Text.Trim());
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
