using QLPhongTro.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongTro.DAL
{
    public class DAL_TaiKhoan
    {
        public DataTable DangNhap(string MaDangNhap, string MatKhau)
        {
            string SQL = "SELECT * FROM DangNhap WHERE MaDangNhap='" + MaDangNhap + "' and MatKhau='" + MatKhau + "'";
            return SQL_KetNoi.Load(SQL);
        }
        public DataTable HienThi()
        {
            string SQL = "select MaDangNhap,TenNguoiDung from DangNhap";
            return SQL_KetNoi.Load(SQL);
        }
        public DataTable ThongTinCaNhan(string MaDangNhap)
        {
            string SQL = "select * from DangNhap where MaDangNhap='" + MaDangNhap + "'";
            return SQL_KetNoi.Load(SQL);
        }
        public void DoiMatKhau(string MatKhau, string MaDangNhap)
        {
            string SQL = string.Format(@"UPDATE DangNhap set MatKhau = '" + MatKhau + "' where MaDangNhap = '" + MaDangNhap + "'");
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public DataTable TimKiem(string TenNguoiDung)
        {
            string SQL = "select MaDangNhap,TenNguoiDung from DangNhap WHERE TenNguoiDung LIKE N'%" + TenNguoiDung + "%'";
            return SQL_KetNoi.Load(SQL);
        }
        public void Xoa(string MaDangNhap)
        {
            string SQL = string.Format(@"DELETE DangNhap WHERE MaDangNhap = '" + MaDangNhap + "'");
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void Them(string MaDangNhap, string TenNguoiDung, string MatKhau)
        {
            string SQL = "INSERT INTO DangNhap(MaDangNhap,TenNguoiDung,MatKhau)  VALUES ( '" + MaDangNhap + "',N'" + TenNguoiDung + "','" + MatKhau + "')";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void Sua(string MaDangNhap, string MaDangNhap2, string TenNguoiDung, string MatKhau)
        {
            string SQL = "UPDATE DangNhap SET MaDangNhap = '" + MaDangNhap + "',TenNguoiDung=N'" + TenNguoiDung + "',MatKhau = '" + MatKhau + "' WHERE MaDangNhap = '" + MaDangNhap2 + "'";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public int KiemTraDuLieuTonTai(string MaDangNhap)
        {
            int i = 0;
            string SQL = "SELECT * FROM DangNhap WHERE MaDangNhap = '" + MaDangNhap + "'";
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
