using QLPhongTro.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongTro.DAL
{
    public class DAL_KhachHang
    {
        public DataTable HienThi()
        {
            string SQL = "select * from KhachHang";
            return SQL_KetNoi.Load(SQL);
        }
        public DataTable TimKiem(string TenKhachHang)
        {
            string SQL = "select * from KhachHang WHERE TenKhachHang LIKE N'%" + TenKhachHang + "%'";
            return SQL_KetNoi.Load(SQL);
        }
        public void Xoa(string MaKhachHang)
        {
            string SQL = string.Format(@"DELETE KhachHang WHERE MaKhachHang = '" + MaKhachHang + "'");
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void Them(string MaKhachHang, string TenKhachHang, string DienThoai, string DiaChi, string CMND,string Email)
        {
            string SQL = "INSERT INTO KhachHang(MaKhachHang,TenKhachHang,DienThoai,DiaChi,CMND,Email)  VALUES ( '" + MaKhachHang + "',N'" + TenKhachHang + "','" + DienThoai + "',N'" + DiaChi + "','" + CMND + "','"+ Email + "')";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void Sua(string MaKhachHang, string MaKhachHang2, string TenKhachHang, string DienThoai, string DiaChi, string CMND, string Email)
        {
            string SQL = "UPDATE KhachHang SET MaKhachHang = '" + MaKhachHang + "',TenKhachHang=N'" + TenKhachHang + "',DienThoai = N'" + DienThoai + "',DiaChi = N'" + DiaChi + "',CMND='" + CMND + "',Email = '"+Email+"' WHERE MaKhachHang = '" + MaKhachHang2 + "'";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public int KiemTraDuLieuTonTai(string MaKhachHang)
        {
            int i = 0;
            string SQL = "SELECT * FROM KhachHang WHERE MaKhachHang = '" + MaKhachHang + "'";
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
