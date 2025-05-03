using QLPhongTro.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongTro.VIEWS
{
    public partial class frmQuanLyPhong : Form
    {
        DAL_PhongTro db = new DAL_PhongTro();
        public static Boolean save;
        public static string MaPhongTro;
        public static string MaLoaiPhong;
        public static string TrangThai;
        public static string MaTang;
        public frmQuanLyPhong()
        {
            InitializeComponent();
        }

        private void frmQuanLyPhong_Load(object sender, EventArgs e)
        {
            DanhSach();
            if(dgvMain.Rows.Count > 0)
            {
                DanhSachHinh(dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells[0].Value.ToString());
            }
            else
            {
                picHinhAnh.Image = null;
            }    
        }
        private void DanhSach()
        {
            DataTable dt = db.HienThi();
            dgvMain.DataSource = dt;
            dgvMain.Columns[0].HeaderText = "Mã phòng trọ";
            dgvMain.Columns[1].HeaderText = "Tên phòng trọ";
            dgvMain.Columns[2].HeaderText = "Mã loại phòng";
            dgvMain.Columns[3].HeaderText = "Trạng thái";
            dgvMain.Columns[4].HeaderText = "Tên trạng thái";
            dgvMain.Columns[5].HeaderText = "Ghi chú";
            dgvMain.Columns[6].HeaderText = "Mã tầng";
            dgvMain.Columns[0].Width = 120;
            dgvMain.Columns[1].Width = 200;
            dgvMain.Columns[2].Width = 120;
            dgvMain.Columns[3].Width = 120;
            dgvMain.Columns[4].Width = 120;
            dgvMain.Columns[5].Width = 120;
            dgvMain.Columns[6].Width = 120;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvMain.DataSource = db.TimKiem(txtTK.Text.Trim());
        }

        private void menuThem_Click(object sender, EventArgs e)
        {
            save = true;
            frmQuanLyPhong_ThongTin frm = new frmQuanLyPhong_ThongTin();
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
            frmQuanLyPhong_ThongTin frm = new frmQuanLyPhong_ThongTin();
            frm.txtMaPhongTro.Text = row.Cells[0].Value.ToString();
            MaPhongTro = row.Cells[0].Value.ToString();
            frm.txtTenPhong.Text = row.Cells[1].Value.ToString();
            MaLoaiPhong = row.Cells[2].Value.ToString();
            TrangThai = row.Cells[3].Value.ToString();
            frm.txtGhiChu.Text = row.Cells[5].Value.ToString();
            MaTang = row.Cells[6].Value.ToString();
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

        private void menuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuLamMoi_Click(object sender, EventArgs e)
        {
            DanhSach();
        }
        private void DanhSachHinh(string MaPhongTro)
        {
            flpHinhAnh.Controls.Clear();
            DataTable dt = new DataTable();
            dt = db.DanhSachHinhAnh(MaPhongTro);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PictureBox pc = new PictureBox();
                    pc.Size = new Size(198, 157);
                    pc.SizeMode = PictureBoxSizeMode.StretchImage;
                    pc.Name = dr["DuongDan"].ToString();
                    pc.Tag = AppDomain.CurrentDomain.BaseDirectory + "\\Content\\Upload\\" + dr["DuongDan"].ToString();
                    pc.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Content\\Upload\\" + dr["DuongDan"].ToString());
                    pc.Click += (sender, e) => PicHinhAnh_Click(pc);
                    flpHinhAnh.Controls.Add(pc);
                }
            }    
            else
            {
                picHinhAnh.Image = null;
            }    
        }
        private void PicHinhAnh_Click(PictureBox pc)
        {
            picHinhAnh.Image = Image.FromFile(pc.Tag.ToString());
            picHinhAnh.Name = pc.Name.ToString();
        }

        private void btnThemHinh_Click(object sender, EventArgs e)
        {
            if(dgvMain.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có phòng");
                return;
            }    
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string nameFile = Guid.NewGuid().ToString() + "_" + Path.GetFileName(openFileDialog.FileName);
                picHinhAnh.ImageLocation = openFileDialog.FileName;

                if (!string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    string destinationDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\Content\\Upload";
                    if (!Directory.Exists(destinationDirectory))
                    {
                        Directory.CreateDirectory(destinationDirectory);
                    }
                    string destinationPath = Path.Combine(destinationDirectory, openFileDialog.FileName);
                    try
                    {
                        File.Copy(openFileDialog.FileName, destinationDirectory + "\\" + nameFile, true);
                        db.ThemHinhAnh(dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells[0].Value.ToString(), nameFile);
                        MessageBox.Show("Thêm thành công");
                        DanhSachHinh(dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi sao chép hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvMain.Rows[e.RowIndex];
                DanhSachHinh(row.Cells[0].Value.ToString());
            }
        }

        private void bttXoaHinh_Click(object sender, EventArgs e)
        {
            if(picHinhAnh.Image == null)
            {
                MessageBox.Show("Chưa chọn hình để xóa");
                return;
            }    
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa hình ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    db.XoaHinhAnh(dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells[0].Value.ToString(),picHinhAnh.Name);
                    MessageBox.Show("Xóa thành công");
                    DanhSachHinh(dgvMain.Rows[dgvMain.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    picHinhAnh.Image = null;
                }
                else
                    return;
            }    
        }
    }
}
