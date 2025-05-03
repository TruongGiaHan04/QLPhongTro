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
    public partial class frmQuanLyPhong_ThongTin : Form
    {
        DAL_PhongTro db = new DAL_PhongTro();
        public frmQuanLyPhong_ThongTin()
        {
            InitializeComponent();
        }

        private void frmQuanLyPhong_ThongTin_Load(object sender, EventArgs e)
        {
            if (frmQuanLyPhong.save == true)
            {
                DanhSachLoaiPhong();
                DanhSachTinhTrangPhong();
                DanhSachTang();
            }
            else
            {
                DanhSachLoaiPhong();
                DanhSachTinhTrangPhong();
                DanhSachTang();
                cboMaLoaiPhong.SelectedValue = frmQuanLyPhong.MaLoaiPhong;
                cboTrangThai.SelectedValue = frmQuanLyPhong.TrangThai;
                cboMaTang.SelectedValue = frmQuanLyPhong.MaTang;
            }
        }
        private void DanhSachLoaiPhong()
        {
            DataTable dt = db.LoadDanhSachLoaiPhong();
            cboMaLoaiPhong.DataSource = dt;
            cboMaLoaiPhong.DisplayMember = "TenLoaiPhong";
            cboMaLoaiPhong.ValueMember = "MaLoaiPhong";
        }
        private void DanhSachTinhTrangPhong()
        {
            DataTable dt = db.LoadDanhSachTinhTrangPhong();
            cboTrangThai.DataSource = dt;
            cboTrangThai.DisplayMember = "Ten";
            cboTrangThai.ValueMember = "Ma";
        }
        private void DanhSachTang()
        {
            DataTable dt = db.LoadDanhSachTang();
            cboMaTang.DataSource = dt;
            cboMaTang.DisplayMember = "TenTang";
            cboMaTang.ValueMember = "MaTang";
        }
        private void btnNhan_Click(object sender, EventArgs e)
        {
            if (txtMaPhongTro.Text == "")
            {
                MessageBox.Show("Mã phòng không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaPhongTro.Focus();
                return;
            }
            if (txtTenPhong.Text == "")
            {
                MessageBox.Show("Tên phòng không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenPhong.Focus();
                return;
            }
            if (frmQuanLyPhong.save == true)
            {
                if (db.KiemTraDuLieuTonTai(txtMaPhongTro.Text) == 0)
                {
                    MessageBox.Show("Thêm thất bại, Phòng này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.Them(txtMaPhongTro.Text.Trim(), txtTenPhong.Text.Trim(), cboMaLoaiPhong.SelectedValue.ToString(), cboTrangThai.SelectedValue.ToString(), txtGhiChu.Text.Trim(), cboMaTang.SelectedValue.ToString());
                MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            if (frmQuanLyPhong.save == false)
            {
                if (db.KiemTraDuLieuTonTai(txtMaPhongTro.Text) == 0 && txtMaPhongTro.Text != frmQuanLyPhong.MaPhongTro)
                {
                    MessageBox.Show("Sửa thất bại, Phòng này này đã tồn tại trong cơ sở dữ liệu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.Sua(txtMaPhongTro.Text.Trim(), frmQuanLyPhong.MaPhongTro, txtTenPhong.Text.Trim(), cboMaLoaiPhong.SelectedValue.ToString(), cboTrangThai.SelectedValue.ToString(), txtGhiChu.Text.Trim(), cboMaTang.SelectedValue.ToString());
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
