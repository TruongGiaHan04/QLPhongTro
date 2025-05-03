using QLPhongTro.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongTro.DAL
{
    public class DAL_PhongTro
    {
        public DataTable LoadDanhSachLoaiPhong()
        {
            return SQL_KetNoi.Load("SELECT * FROM LoaiPhongTro");
        }
        public DataTable LoadDanhSachTinhTrangPhong()
        {
            return SQL_KetNoi.Load("SELECT * FROM TrangThai WHERE Loai = 'TTPHONG'");
        }
        public DataTable LoadDanhSachTang()
        {
            return SQL_KetNoi.Load("SELECT * FROM Tang ");
        }
        public DataTable HienThi()
        {
            string SQL = "select MaPhongTro,TenPhong,MaLoaiPhong,TrangThai,Ten,GhiChu,MaTang from PhongTro a INNER JOIN TrangThai b ON a.TrangThai = b.Ma";
            return SQL_KetNoi.Load(SQL);
        }
        public DataTable DanhSachHinhAnh(string MaPhongTro)
        {
            string SQL = $@"select * FROM HinhAnhPhong WHERE MaPhongTro = '{MaPhongTro}'";
            return SQL_KetNoi.Load(SQL);
        }
        public DataTable TimKiem(string TenPhong)
        {
            string SQL = "select * from PhongTro WHERE TenPhong LIKE N'%" + TenPhong + "%'";
            return SQL_KetNoi.Load(SQL);
        }
        public void Xoa(string MaPhongTro)
        {
            string SQL = string.Format(@"DELETE PhongTro WHERE MaPhongTro = '" + MaPhongTro + "'");
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void Them(string MaPhongTro, string TenPhong, string MaLoaiPhong, string TrangThai,String GhiChu,string MaTang)
        {
            string SQL = "INSERT INTO PhongTro(MaPhongTro,TenPhong,MaLoaiPhong,TrangThai,GhiChu,MaTang)  VALUES ( '" + MaPhongTro + "',N'" + TenPhong + "','" + MaLoaiPhong + "',N'" + TrangThai + "',N'" + GhiChu + "','"+ MaTang + "')";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void ThemHinhAnh(string MaPhongTro, string DuongDan)
        {
            string SQL = "INSERT INTO HinhAnhPhong(MaPhongTro,DuongDan)  VALUES ( '" + MaPhongTro + "',N'" + DuongDan + "')";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void XoaHinhAnh(string MaPhongTro, string DuongDan)
        {
            string SQL = "DELETE HinhAnhPhong where  MaPhongTro = '" + MaPhongTro + "' AND DuongDan = N'" + DuongDan + "'";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void Sua(string MaPhongTro, string MaPhongTro2, string TenPhong, string MaLoaiPhong, string TrangThai, string GhiChu,string MaTang)
        {
            string SQL = "UPDATE PhongTro SET MaPhongTro = '" + MaPhongTro + "',TenPhong=N'" + TenPhong + "',MaLoaiPhong = '" + MaLoaiPhong + "',TrangThai=N'" + TrangThai + "',GhiChu=N'" + GhiChu + "', MaTang = '"+ MaTang + "' WHERE MaPhongTro = '" + MaPhongTro2 + "'";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public int KiemTraDuLieuTonTai(string MaPhongTro)
        {
            int i = 0;
            string SQL = "SELECT * FROM PhongTro WHERE MaPhongTro = '" + MaPhongTro + "'";
            DataTable dt = SQL_KetNoi.Load(SQL);
            if ( dt.Rows.Count > 0)
            {
                i = 0;
            }
            else
            {
                i = 1;
            }
            return i;
        }
    }
}
