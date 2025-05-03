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
    public partial class frmDongTien_ThongTin : Form
    {
        DAL_DongTien db = new DAL_DongTien();
        DAL_LoaiPhongTro dbLP = new DAL_LoaiPhongTro();
        public frmDongTien_ThongTin()
        {
            InitializeComponent();
        }

        private void nmGiaPhong_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmDongTien_ThongTin_Load(object sender, EventArgs e)
        {
            DataTable dtP = db.LoadDanhSachPhong();
            if (dtP.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có phòng nào thuê");
                this.Close();
                return;
            }
            if (frmDongTien.save == true)
            {
                try
                {
                    DanhSachPhong();
                    DataTable dt = db.DichVu();
                    DataTable dtgp = dbLP.GiaPhong(cboMaPhong.SelectedValue.ToString());
                    nmTienPhong.Value = decimal.Parse(dtgp.Rows[0][0].ToString() + "");
                    nmTienDienGia.Value = decimal.Parse(dt.Rows[0][0].ToString() + "");
                    nmTienNuocGia.Value = decimal.Parse(dt.Rows[0][1].ToString() + "");
                    nmTienWifi.Value = decimal.Parse(dt.Rows[0][2].ToString() + "");
                    nmTienRac.Value = decimal.Parse(dt.Rows[0][3].ToString() + "");
                    nmTienDienTong.Value = nmTienDien.Value * nmTienDienGia.Value;
                    nmTienNuocTong.Value = nmTienNuoc.Value * nmTienNuocGia.Value;
                }
                catch (Exception)
                {
                    MessageBox.Show("Chưa có phòng nào được thuê");
                    return;
                }
            }
            else
            {
                nmThang.Enabled = false;
                nmNam.Enabled = false;
                cboMaPhong.Enabled = false;
                DanhSachPhong();
                nmThang.Value = frmDongTien.Thang;
                nmNam.Value = frmDongTien.Nam;
                cboMaPhong.SelectedValue = frmDongTien.MaPhong;
                nmTienPhong.Value = frmDongTien.TienPhong;
                nmTienDien.Value = frmDongTien.TienDien;
                nmTienDienGia.Value = frmDongTien.TienDienGia;
                nmTienDienTong.Value = frmDongTien.TienDienTong;
                nmTienNuoc.Value = frmDongTien.TienNuoc;
                nmTienNuocGia.Value = frmDongTien.TienNuocGia;
                nmTienNuocTong.Value = frmDongTien.TienNuocTong;
                nmTienWifi.Value = frmDongTien.TienWifi;
                nmTienRac.Value = frmDongTien.TienRac;
                nmChiPhiKhac.Value = frmDongTien.ChiPhiKhac;
                nmTongTien.Value = frmDongTien.TongTien;
            }
        }
        private void DanhSachPhong()
        {
            DataTable dt = db.LoadDanhSachPhong();
            cboMaPhong.DataSource = dt;
            cboMaPhong.DisplayMember = "TenPhong";
            cboMaPhong.ValueMember = "MaPhongTro"; 
        }
        private void btnTotal_Click(object sender, EventArgs e)
        {
            nmTienDienTong.Value = nmTienDienGia.Value * nmTienDien.Value;
            nmTienNuocTong.Value = nmTienNuocGia.Value * nmTienNuoc.Value;
            nmTongTien.Value = nmTienPhong.Value + nmTienDienTong.Value + nmTienNuocTong.Value + nmTienWifi.Value + nmTienRac.Value + nmChiPhiKhac.Value;
        }

        private void cboMaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtgp = dbLP.GiaPhong(cboMaPhong.SelectedValue.ToString());
                nmTienPhong.Value = decimal.Parse(dtgp.Rows[0][0].ToString() + "");
            }
            catch
            {

            }
           
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            if (nmThang.Text == "")
            {
                MessageBox.Show("Tháng không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                nmThang.Focus();
                return;
            }
            if (nmNam.Text == "")
            {
                MessageBox.Show("Năm không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                nmNam.Focus();
                return;
            }
            if (cboMaPhong.Text == "")
            {
                MessageBox.Show("Mã phòng không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboMaPhong.Focus();
                return;
            }
            if (frmDongTien.save == true)
            {
                if (db.KiemTraDuLieuTonTai(nmThang.Value, nmNam.Value, cboMaPhong.SelectedValue.ToString()) == 0)
                {
                    MessageBox.Show("Thêm thất bại, Phòng này đã được đóng tiền tháng này, hãy chỉnh sửa", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.Them(nmThang.Value, nmNam.Value, cboMaPhong.SelectedValue.ToString(), nmTienPhong.Value, nmTienDien.Value, nmTienNuoc.Value, nmTienWifi.Value, nmTienRac.Value, nmChiPhiKhac.Value, nmTongTien.Value, nmTienDienGia.Value, nmTienDienTong.Value, nmTienNuocGia.Value, nmTienNuocTong.Value);
                MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            if (frmDongTien.save == false)
            {
                db.Sua(nmThang.Value, nmNam.Value, cboMaPhong.SelectedValue.ToString(), nmTienPhong.Value, nmTienDien.Value, nmTienNuoc.Value, nmTienWifi.Value, nmTienRac.Value, nmChiPhiKhac.Value, nmTongTien.Value, nmTienDienGia.Value, nmTienDienTong.Value, nmTienNuocGia.Value, nmTienNuocTong.Value);
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
