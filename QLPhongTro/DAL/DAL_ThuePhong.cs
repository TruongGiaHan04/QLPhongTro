using QLPhongTro.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongTro.DAL
{
    public class DAL_ThuePhong
    {
        public DataTable LoadDanhSachPhong()
        {
            return SQL_KetNoi.Load("SELECT * FROM PhongTro WHERE TrangThai = '1' AND MaLoaiPhong <> 'THEOGIO'");
        }
        public DataTable LoadDanhSachThuePhong()
        {
            return SQL_KetNoi.Load("SELECT MaPhieuThue,a.MaPhong,TenPhong,TenLoaiPhong,NgayThue,TienCoc,Ten FROM ThuePhong a INNER JOIN PhongTro b ON a.MaPhong = b.MaPhongTro INNER JOIN LoaiPhongTro c ON b.MaLoaiPhong = c.MaLoaiPhong INNER JOIN TrangThai d ON b.TrangThai = d.Ma WHERE Loai = 'TTPHONG' AND TrangThai = '2' AND NgayTra IS NULL");
        }
        public DataTable LoadDanhSachChiTietThuePhong(string MaPhieuThue)
        {
            return SQL_KetNoi.Load("SELECT MaPhieuThue,a.MaKhachHang,TenKhachHang,Email FROM ChiTietThuePhong a INNER JOIN KhachHang b ON a.MaKhachHang = b.MaKhachHang WHERE MaPhieuThue = '"+ MaPhieuThue+"'");
        }
        public DataTable LoadDanhSachPhieuThue()
        {
            return SQL_KetNoi.Load("SELECT * FROM ThuePhong a INNER JOIN PhongTro b ON a.MaPhong = b.MaPhongTro WHERE TrangThai = '2' AND NgayTra IS NULL");
        }
        public DataTable LoadDanhSachKhachHang()
        {
            return SQL_KetNoi.Load("SELECT * FROM KhachHang");
        }
     
        public int KiemTraMaPhieuThueTonTai(string MaPhieuThue)
        {
            int i = 0;
            string SQL = "SELECT * FROM ThuePhong WHERE MaPhieuThue = '" + MaPhieuThue + "'";
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
        public int KiemTraPhongDaThue(string MaPhong)
        {
            int i = 0;
            string SQL = "SELECT * FROM ThuePhong a INNER JOIN PhongTro b ON a.MaPhong = b.MaPhongTro WHERE MaPhong = '" + MaPhong + "' AND TrangThai = '2'";
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
        public void ThemPhieuThue(string MaPhieuThue, string MaPhong, string NgayThue, decimal TienCoc)
        {
            string SQL = "INSERT INTO ThuePhong(MaPhieuThue,MaPhong,NgayThue,TienCoc)  VALUES ( '" + MaPhieuThue + "','" + MaPhong + "','" + NgayThue + "','" + TienCoc + "')";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void CapNhatTrangThai(string MaPhongTro)
        {
            string SQL = "UPDATE PhongTro SET TrangThai = '2' WHERE MaPhongTro = '" + MaPhongTro + "'";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void ThemChiTietThuePhong(string MaPhieuThue, string MaKhachHang)
        {
            string SQL = "INSERT INTO ChiTietThuePhong(MaPhieuThue,MaKhachHang)  VALUES ( '" + MaPhieuThue + "','" + MaKhachHang + "')";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public int KiemTraKhachHangDaThue(string MaPhieuThue, string MaKhachHang)
        {
            int i = 0;
            string SQL = "SELECT * FROM ChiTietThuePhong WHERE MaPhieuThue = '" + MaPhieuThue + "' AND MaKhachHang = '" + MaKhachHang + "'";
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
        public void XoaThuePhong(string MaPhieuThue, string MaPhongTro)
        {
            string SQL = string.Format(@"DELETE ChiTietThuePhong WHERE MaPhieuThue = '" + MaPhieuThue + "'  DELETE ThuePhong WHERE MaPhieuThue = '" + MaPhieuThue + "' UPDATE PhongTro SET TrangThai = '1' WHERE MaPhongTro = '" + MaPhongTro + "'");
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void XoaChiTietThuePhong(string MaPhieuThue, string MaKhachHang)
        {
            string SQL = string.Format(@"DELETE ChiTietThuePhong WHERE MaPhieuThue = '" + MaPhieuThue + "' AND MaKhachHang = '"+ MaKhachHang + "'");
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
    }
}
