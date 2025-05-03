using QLPhongTro.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongTro.VIEWS
{
    public partial class frmDongTien : Form
    {
        DAL_DongTien db = new DAL_DongTien();
        public static Boolean save;
        public static decimal Thang;
        public static decimal Nam;
        public static string MaPhong;
        public static decimal TienPhong;
        public static decimal TienDien;
        public static decimal TienDienGia;
        public static decimal TienDienTong;
        public static decimal TienNuoc;
        public static decimal TienNuocGia;
        public static decimal TienNuocTong;
        public static decimal TienWifi;
        public static decimal TienRac;
        public static decimal ChiPhiKhac;
        public static decimal TongTien;
        public frmDongTien()
        {
            InitializeComponent();
        }

        private void frmDongTien_Load(object sender, EventArgs e)
        {
            nmThang1.Value = DateTime.Now.Month;
            nmNam1.Value = DateTime.Now.Year;
            DanhSach();
        }
        private void DanhSach()
        {
            DataTable dt = db.HienThi();
            dgvMain.DataSource = dt;
            dgvMain.Columns[0].HeaderText = "Tháng";
            dgvMain.Columns[1].HeaderText = "Năm";
            dgvMain.Columns[2].HeaderText = "Mã phòng";
            dgvMain.Columns[3].HeaderText = "Tiền phòng";
            dgvMain.Columns[4].HeaderText = "Số điện";
            dgvMain.Columns[5].HeaderText = "Giá điện";
            dgvMain.Columns[6].HeaderText = "Tổng tiền điện";
            dgvMain.Columns[7].HeaderText = "Số nước";
            dgvMain.Columns[8].HeaderText = "Giá nước";
            dgvMain.Columns[9].HeaderText = "Tổng tiền nước";
            dgvMain.Columns[10].HeaderText = "Tiền Wifi";
            dgvMain.Columns[11].HeaderText = "Tiền rác";
            dgvMain.Columns[12].HeaderText = "Chi phí khác";
            dgvMain.Columns[13].HeaderText = "Tổng tiền";
            dgvMain.Columns[14].HeaderText = "Trạng thái thanh toán";
            dgvMain.Columns[0].Width = 120;
            dgvMain.Columns[1].Width = 200;
            dgvMain.Columns[2].Width = 120;
            dgvMain.Columns[3].Width = 120;
            dgvMain.Columns[4].Width = 120;
            dgvMain.Columns[5].Width = 120;
            dgvMain.Columns[6].Width = 120;
            dgvMain.Columns[7].Width = 120;
            dgvMain.Columns[8].Width = 120;
            dgvMain.Columns[9].Width = 120;
            dgvMain.Columns[10].Width = 120;
            dgvMain.Columns[11].Width = 120;
            dgvMain.Columns[12].Width = 120;
            dgvMain.Columns[13].Width = 120;
            dgvMain.Columns[14].Width = 120;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvMain.DataSource = db.TimKiem(txtTK.Text.Trim(),nmThang1.Value,nmNam1.Value);
        }

        private void menuThem_Click(object sender, EventArgs e)
        {
            save = true;
            frmDongTien_ThongTin frm = new frmDongTien_ThongTin();
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
            frmDongTien_ThongTin frm = new frmDongTien_ThongTin();
            Thang = decimal.Parse(row.Cells[0].Value.ToString() + "");
            Nam = decimal.Parse(row.Cells[1].Value.ToString() + "");
            MaPhong = row.Cells[2].Value.ToString();
            TienPhong = decimal.Parse(row.Cells[3].Value.ToString() + "");
            TienDien = decimal.Parse(row.Cells[4].Value.ToString() + "");
            TienDienGia = decimal.Parse(row.Cells[5].Value.ToString() + "");
            TienDienTong = decimal.Parse(row.Cells[6].Value.ToString() + "");
            TienNuoc = decimal.Parse(row.Cells[7].Value.ToString() + "");
            TienNuocGia = decimal.Parse(row.Cells[8].Value.ToString() + "");
            TienNuocTong = decimal.Parse(row.Cells[9].Value.ToString() + "");
            TienWifi = decimal.Parse(row.Cells[10].Value.ToString() + "");
            TienRac = decimal.Parse(row.Cells[11].Value.ToString() + "");
            ChiPhiKhac = decimal.Parse(row.Cells[12].Value.ToString() + "");
            TongTien = decimal.Parse(row.Cells[13].Value.ToString() + "");
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
                db.Xoa(int.Parse(dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells[0].Value.ToString() + ""), int.Parse(dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells[1].Value.ToString() + ""), dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells[2].Value.ToString());
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
        private void menuEmail_Click(object sender, EventArgs e)
        {
            frmGuiEmail frm = new frmGuiEmail();
            frm.ShowDialog();
        }

        private void menuThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn thanh toán hóa đơn không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.ThanhToan(int.Parse(dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells[0].Value.ToString() + ""), int.Parse(dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells[1].Value.ToString() + ""), dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells[2].Value.ToString());
                MessageBox.Show("Thanh toán thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                DanhSach();
            }
            else
                return;
        }
    }
}
