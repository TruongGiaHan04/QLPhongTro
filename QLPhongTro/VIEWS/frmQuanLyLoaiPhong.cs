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
    public partial class frmQuanLyLoaiPhong : Form
    {
        DAL_LoaiPhongTro db = new DAL_LoaiPhongTro();
        public static Boolean save;
        public static string MaLoaiPhong;
        public static string TenLoaiPhong;
        public static decimal DienTichPhong;
        public static decimal GiaPhong;
        public static string GhiChu;
        public frmQuanLyLoaiPhong()
        {
            InitializeComponent();
        }
        private void DanhSach()
        {
            DataTable dt = db.HienThi();
            dgvMain.DataSource = dt;
            dgvMain.Columns[0].HeaderText = "Mã loại phòng";
            dgvMain.Columns[1].HeaderText = "Tên loại phòng";
            dgvMain.Columns[2].HeaderText = "Diện tích phòng";
            dgvMain.Columns[3].HeaderText = "Giá phòng";
            dgvMain.Columns[4].HeaderText = "Ghi chú";
            dgvMain.Columns[0].Width = 150;
            dgvMain.Columns[1].Width = 150;
            dgvMain.Columns[2].Width = 150;
            dgvMain.Columns[3].Width = 150;
            dgvMain.Columns[4].Width = 150;
        }
        private void frmQuanLyLoaiPhong_Load(object sender, EventArgs e)
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
            frmQuanLyLoaiPhong_ThongTin frm = new frmQuanLyLoaiPhong_ThongTin();
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
            frmQuanLyLoaiPhong_ThongTin frm = new frmQuanLyLoaiPhong_ThongTin();
            MaLoaiPhong = row.Cells[0].Value.ToString();
            TenLoaiPhong = row.Cells[1].Value.ToString();
            DienTichPhong = decimal.Parse(row.Cells[2].Value.ToString() + "");
            GiaPhong = decimal.Parse(row.Cells[3].Value.ToString() + "");
            GhiChu = row.Cells[4].Value.ToString();
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
