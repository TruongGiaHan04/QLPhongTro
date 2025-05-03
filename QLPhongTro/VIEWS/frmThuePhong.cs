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
    public partial class frmThuePhong : Form
    {
        DAL_ThuePhong db = new DAL_ThuePhong();
        public frmThuePhong()
        {
            InitializeComponent();
        }

        private void frmThuePhong_Load(object sender, EventArgs e)
        {
            txtMaPhieuThue.Text = "PT_" + DateTime.Now.ToString("yyMMddhhmmss");
            DanhSachPhong();
            DanhSachPhieuThue();
            DanhSachKhachHang();
            DanhSachThuePhong();
            DanhSachChiTietThuePhong(cboMaPhong.Text.ToString());
        }
        private void DanhSachChiTietThuePhong(string MaPhieuThue)
        {
            DataTable dt = db.LoadDanhSachChiTietThuePhong(MaPhieuThue);
            dgvDetail.DataSource = dt;
            dgvDetail.Columns[0].HeaderText = "Mã phiếu thuê";
            dgvDetail.Columns[1].HeaderText = "Mã khách hàng";
            dgvDetail.Columns[2].HeaderText = "Tên khách hàng";
            dgvDetail.Columns[3].HeaderText = "Email";
            dgvDetail.Columns[0].Width = 120;
            dgvDetail.Columns[1].Width = 120;
            dgvDetail.Columns[2].Width = 120;
            dgvDetail.Columns[3].Width = 160;
        }
        private void DanhSachThuePhong()
        {
            DataTable dt = db.LoadDanhSachThuePhong();
            dgvMaster.DataSource = dt;
            dgvMaster.Columns[0].HeaderText = "Mã phiếu thuê";
            dgvMaster.Columns[1].HeaderText = "Mã phòng";
            dgvMaster.Columns[2].HeaderText = "Tên phòng";
            dgvMaster.Columns[3].HeaderText = "Tên loại phòng";
            dgvMaster.Columns[4].HeaderText = "Ngày thuê";
            dgvMaster.Columns[5].HeaderText = "Tiền cọc";
            dgvMaster.Columns[6].HeaderText = "Trạng thái";
            dgvMaster.Columns[0].Width = 120;
            dgvMaster.Columns[1].Width = 120;
            dgvMaster.Columns[2].Width = 120;
            dgvMaster.Columns[3].Width = 120;
            dgvMaster.Columns[4].Width = 120;
            dgvMaster.Columns[5].Width = 120;
            dgvMaster.Columns[6].Width = 120;
        }
        private void DanhSachPhong()
        {
            DataTable dt = db.LoadDanhSachPhong();
            cboMaPhong.DataSource = dt;
            cboMaPhong.DisplayMember = "TenPhong";
            cboMaPhong.ValueMember = "MaPhongTro";
        }
        private void DanhSachPhieuThue()
        {
            DataTable dt = db.LoadDanhSachPhieuThue();
            cboMaPhieuThue.DataSource = dt;
            cboMaPhieuThue.DisplayMember = "MaPhieuThue";
            cboMaPhieuThue.ValueMember = "MaPhieuThue";
        }
        private void DanhSachKhachHang()
        {
            DataTable dt = db.LoadDanhSachKhachHang();
            cboMaKhachHang.DataSource = dt;
            cboMaKhachHang.DisplayMember = "TenKhachHang";
            cboMaKhachHang.ValueMember = "MaKhachHang";
        }

        private void cboMaPhieuThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DanhSachChiTietThuePhong(cboMaPhieuThue.Text.ToString());
            }
            catch
            {

            }    

        }

        private void dgvMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvMaster.Rows[dgvMaster.CurrentCell.RowIndex];
            cboMaPhieuThue.Text = row.Cells[0].Value.ToString();
            DanhSachChiTietThuePhong(row.Cells[0].Value.ToString());
        }

        private void menuThem_Click(object sender, EventArgs e)
        {
            txtMaPhieuThue.Text = "PT_" + DateTime.Now.ToString("yyMMddhhmmss");
            if (txtMaPhieuThue.Text == "")
            {
                MessageBox.Show("Mã phiếu thuê không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaPhieuThue.Focus();
                return;
            }
            if (cboMaPhong.Text == "")
            {
                MessageBox.Show("Mã phòng thuê không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaPhieuThue.Focus();
                return;
            }
            if (db.KiemTraMaPhieuThueTonTai(txtMaPhieuThue.Text.Trim()) == 0)
            {
                MessageBox.Show("Thêm thất bại, Phòng này đã tồn tại, bấm Lấy mã để tạo mã mới", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (db.KiemTraPhongDaThue(cboMaPhong.SelectedValue.ToString()) == 0)
            {
                MessageBox.Show("Thêm thất bại, Phòng này đã có người thuê, hãy thêm chi tiết khách hàng", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            db.ThemPhieuThue(txtMaPhieuThue.Text.Trim(), cboMaPhong.SelectedValue.ToString(), dtNgayThue.Value.ToString("yyyy-MM-dd"), nmTienCoc.Value);
            MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            db.CapNhatTrangThai(cboMaPhong.SelectedValue.ToString());
            DanhSachPhong();
            DanhSachPhieuThue();
            DanhSachThuePhong();
            DanhSachChiTietThuePhong(cboMaPhieuThue.Text.ToString());
        }

        private void menuXoa_Click(object sender, EventArgs e)
        {
            if (dgvMaster.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn xóa dòng dữ liệu này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.XoaThuePhong(dgvMaster.Rows[dgvMaster.CurrentCell.RowIndex].Cells[0].Value.ToString(), dgvMaster.Rows[dgvMaster.CurrentCell.RowIndex].Cells[1].Value.ToString());
                MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                DanhSachPhieuThue();
                DanhSachPhong();
                DanhSachThuePhong();
                DanhSachChiTietThuePhong(cboMaPhieuThue.Text.ToString());
            }
            else
                return;
        }

        private void menuThemKH_Click(object sender, EventArgs e)
        {
            if (cboMaPhieuThue.Text == "")
            {
                MessageBox.Show("Mã phiếu thuê không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaPhieuThue.Focus();
                return;
            }
            if (cboMaKhachHang.Text == "")
            {
                MessageBox.Show("Mã khách hàng không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaPhieuThue.Focus();
                return;
            }
            if (db.KiemTraKhachHangDaThue(cboMaPhieuThue.SelectedValue.ToString(), cboMaKhachHang.SelectedValue.ToString()) == 0)
            {
                MessageBox.Show("Thêm thất bại, Người này đã thuê phòng này", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            db.ThemChiTietThuePhong(cboMaPhieuThue.SelectedValue.ToString(), cboMaKhachHang.SelectedValue.ToString());
            MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            DanhSachPhong();
            DanhSachPhieuThue();
            DanhSachThuePhong();
            DanhSachChiTietThuePhong(cboMaPhieuThue.Text.ToString());
        }

        private void menuXoaKH_Click(object sender, EventArgs e)
        {
            if (dgvDetail.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn xóa dòng dữ liệu này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.XoaChiTietThuePhong(dgvDetail.Rows[dgvDetail.CurrentCell.RowIndex].Cells[0].Value.ToString(), dgvDetail.Rows[dgvDetail.CurrentCell.RowIndex].Cells[1].Value.ToString());
                MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                DanhSachPhieuThue();
                DanhSachKhachHang();
                DanhSachThuePhong();
                DanhSachChiTietThuePhong(cboMaPhieuThue.Text.ToString());
            }
            else
                return;
        }
    }
}
