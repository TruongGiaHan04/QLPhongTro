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
    public partial class frmTraPhong : Form
    {
        DAL_TraPhong db = new DAL_TraPhong();
        public frmTraPhong()
        {
            InitializeComponent();
        }

        private void frmTraPhong_Load(object sender, EventArgs e)
        {
            DanhSachThuePhong();
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
        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            if (dgvMaster.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn trả phòng này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.CapNhatTrangThai(dtNgayTra.Value.ToString("yyyy-MM-dd"), dgvMaster.Rows[dgvMaster.CurrentCell.RowIndex].Cells[0].Value.ToString(), dgvMaster.Rows[dgvMaster.CurrentCell.RowIndex].Cells[1].Value.ToString());
                MessageBox.Show("Trả phòng thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                DanhSachThuePhong();
            }
            else
                return;
        }
    }
}
