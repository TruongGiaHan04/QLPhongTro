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
    public partial class frmQuanLyLoaiPhong_ThongTin : Form
    {
        DAL_LoaiPhongTro db = new DAL_LoaiPhongTro();
        public frmQuanLyLoaiPhong_ThongTin()
        {
            InitializeComponent();
        }

        private void frmQuanLyLoaiPhong_ThongTin_Load(object sender, EventArgs e)
        {
            if (frmQuanLyLoaiPhong.save == false)
            {
                txtMaLoaiPhong.Text = frmQuanLyLoaiPhong.MaLoaiPhong;
                txtTenLoaiPhong.Text = frmQuanLyLoaiPhong.TenLoaiPhong;
                txtGhiChu.Text = frmQuanLyLoaiPhong.GhiChu;
                nmDienTichPhong.Value = frmQuanLyLoaiPhong.DienTichPhong;
                nmGiaPhong.Value = frmQuanLyLoaiPhong.GiaPhong;
            }
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            if (txtMaLoaiPhong.Text == "")
            {
                MessageBox.Show("Mã loại phòng không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaLoaiPhong.Focus();
                return;
            }
            if (txtTenLoaiPhong.Text == "")
            {
                MessageBox.Show("Tên loại phòng không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenLoaiPhong.Focus();
                return;
            }

            if (frmQuanLyLoaiPhong.save == true)
            {
                if (db.KiemTraDuLieuTonTai(txtMaLoaiPhong.Text) == 0)
                {
                    MessageBox.Show("Thêm thất bại, Loại phòng này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.Them(txtMaLoaiPhong.Text.Trim(), txtTenLoaiPhong.Text.Trim(), nmDienTichPhong.Value, nmGiaPhong.Value, txtGhiChu.Text.Trim());
                MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            if (frmQuanLyLoaiPhong.save == false)
            {
                if (db.KiemTraDuLieuTonTai(txtMaLoaiPhong.Text) == 0 && txtMaLoaiPhong.Text != frmQuanLyLoaiPhong.MaLoaiPhong)
                {
                    MessageBox.Show("Sửa thất bại, Loại phòng này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.Sua(txtMaLoaiPhong.Text.Trim(), frmQuanLyLoaiPhong.MaLoaiPhong, txtTenLoaiPhong.Text.Trim(), nmDienTichPhong.Value, nmGiaPhong.Value, txtGhiChu.Text.Trim());
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
