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
    public partial class frmQuanLyTang : Form
    {
        DAL_Tang db = new DAL_Tang();
        public static Boolean save;
        public static string MaTang;
        public frmQuanLyTang()
        {
            InitializeComponent();
        }
        private void DanhSach()
        {
            DataTable dt = db.HienThi();
            dgvMain.DataSource = dt;
            dgvMain.Columns[0].HeaderText = "Mã tầng";
            dgvMain.Columns[1].HeaderText = "Tên tầng";
            dgvMain.Columns[2].HeaderText = "Ghi chú";
            dgvMain.Columns[0].Width = 120;
            dgvMain.Columns[1].Width = 150;
            dgvMain.Columns[2].Width = 250;
        }
        
        private void frmQuanLyTang_Load(object sender, EventArgs e)
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
            frmQuanLyTang_ThongTin frm = new frmQuanLyTang_ThongTin();
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
            frmQuanLyTang_ThongTin frm = new frmQuanLyTang_ThongTin();
            frm.txtMaTang.Text = row.Cells[0].Value.ToString();
            MaTang = row.Cells[0].Value.ToString();
            frm.txtTenTang.Text = row.Cells[1].Value.ToString();
            frm.txtGhiChu.Text = row.Cells[2].Value.ToString();
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
