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
    public partial class frmQuanLyTaiKhoan : Form
    {
        DAL_TaiKhoan db = new DAL_TaiKhoan();
        public static Boolean save;
        public static string MaDangNhap;
        public static string TenNguoiDung;
        public static string MatKhau;
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            DanhSach();
        }
        private void DanhSach()
        {
            DataTable dt = db.HienThi();
            dgvMain.DataSource = dt;
            dgvMain.Columns[0].HeaderText = "Mã đăng nhập";
            dgvMain.Columns[1].HeaderText = "Tên người dùng";
            dgvMain.Columns[0].Width = 100;
            dgvMain.Columns[1].Width = 150;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvMain.DataSource = db.TimKiem(txtTK.Text.Trim());
        }

        private void menuThem_Click(object sender, EventArgs e)
        {
            save = true;
            frmQuanLyTaiKhoan_ThongTin frm = new frmQuanLyTaiKhoan_ThongTin();
            frm.Text = "Thêm";
            frm.ShowDialog();
            DanhSach();
        }

        private void menuSua_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count == 0)
            {
                return;
            }
            DataGridViewRow row = this.dgvMain.Rows[dgvMain.CurrentCell.RowIndex];
            save = false;
            frmQuanLyTaiKhoan_ThongTin frm = new frmQuanLyTaiKhoan_ThongTin();
            frm.txtMaDangNhap.Text = row.Cells[0].Value.ToString();
            MaDangNhap = row.Cells[0].Value.ToString();
            if (row.Cells[0].Value.ToString() == "ADMIN")
            {
                MessageBox.Show("Không được phép sửa tài khoản quản trị viên", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dt2 = db.ThongTinCaNhan(row.Cells[0].Value.ToString());
            MatKhau = dt2.Rows[0]["MatKhau"].ToString();
            frm.txtTenNguoiDung.Text = row.Cells[1].Value.ToString();
            frm.Text = "Sửa";
            frm.ShowDialog();
            DanhSach();
        }

        private void menuXoa_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count == 0)
            {
                return;
            }
            if (dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells[0].Value.ToString() == "ADMIN")
            {
                MessageBox.Show("Không được phép xóa tài khoản quản trị viên", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn xóa dòng dữ liệu này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Xoa(dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                DanhSach();
            }
            else
                return;
        }

        private void menuLamMoi_Click(object sender, EventArgs e)
        {
            DanhSach();
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
