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
    public partial class frmQuanLyKhachHang : Form
    {
        DAL_KhachHang db = new DAL_KhachHang();
        public static Boolean save;
        public static string MaKhachHang;
        public frmQuanLyKhachHang()
        {
            InitializeComponent();
        }
        private void DanhSach()
        {
            DataTable dt = db.HienThi();
            dgvMain.DataSource = dt;
            dgvMain.Columns[0].HeaderText = "Mã khách hàng";
            dgvMain.Columns[1].HeaderText = "Tên khách hàng";
            dgvMain.Columns[2].HeaderText = "Điện thoại";
            dgvMain.Columns[3].HeaderText = "Địa chỉ";
            dgvMain.Columns[4].HeaderText = "CMND/CCCD";
            dgvMain.Columns[5].HeaderText = "Email";
            dgvMain.Columns[0].Width = 120;
            dgvMain.Columns[1].Width = 150;
            dgvMain.Columns[2].Width = 100;
            dgvMain.Columns[3].Width = 150;
            dgvMain.Columns[4].Width = 100;
            dgvMain.Columns[5].Width = 120;
        }
        private void frmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            DanhSach();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvMain.DataSource = db.TimKiem(txtTK.Text.Trim());
        }

        private void menuThem_Click(object sender, EventArgs e)
        {
            save = true;
            frmQuanLyKhachHang_ThongTin frm = new frmQuanLyKhachHang_ThongTin();
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
            frmQuanLyKhachHang_ThongTin frm = new frmQuanLyKhachHang_ThongTin();
            frm.txtMaKhachHang.Text = row.Cells[0].Value.ToString();
            MaKhachHang = row.Cells[0].Value.ToString();
            frm.txtTenKhachHang.Text = row.Cells[1].Value.ToString();
            frm.txtDienThoai.Text = row.Cells[2].Value.ToString();
            frm.txtDiaChi.Text = row.Cells[3].Value.ToString();
            frm.txtCMND.Text = row.Cells[4].Value.ToString();
            frm.Text = "Sửa";
            frm.txtEmail.Text = row.Cells[5].Value.ToString();
            frm.ShowDialog();
            DanhSach();
        }

        private void menuXoa_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count == 0)
            {
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
