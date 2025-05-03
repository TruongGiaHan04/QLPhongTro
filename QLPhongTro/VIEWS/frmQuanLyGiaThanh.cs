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
    public partial class frmQuanLyGiaThanh : Form
    {
        DAL_DongTien db = new DAL_DongTien();
        public frmQuanLyGiaThanh()
        {
            InitializeComponent();
        }

        private void frmQuanLyGiaThanh_Load(object sender, EventArgs e)
        {
            DataTable dt = db.DichVu();
            nmTienDien.Value = decimal.Parse(dt.Rows[0][0].ToString() + "");
            nmTienNuoc.Value = decimal.Parse(dt.Rows[0][1].ToString() + "");
            nmTienWifi.Value = decimal.Parse(dt.Rows[0][2].ToString() + "");
            nmTienRac.Value = decimal.Parse(dt.Rows[0][3].ToString() + "");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Có chắc chắn sửa thông tin giá thành không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.SuaDichVu(nmTienDien.Value, nmTienNuoc.Value, nmTienWifi.Value, nmTienRac.Value);
                MessageBox.Show("Sửa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
                return;
        }

        private void bttThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
