using QLPhongTro.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongTro.DAL
{
    public class DAL_LoaiPhongTro
    {
        public DataTable HienThi()
        {
            string SQL = "select * from LoaiPhongTro";
            return SQL_KetNoi.Load(SQL);
        }
        public DataTable GiaPhong(string MaPhongTro)
        {
            string SQL = "select GiaPhong from LoaiPhongTro a INNER JOIN PhongTro b ON a.MaLoaiPhong = b.MaLoaiPhong WHERE MaPhongTro = '"+ MaPhongTro+"'";
            return SQL_KetNoi.Load(SQL);
        }
        public DataTable TimKiem(string TenLoaiPhong)
        {
            string SQL = "select * from LoaiPhongTro WHERE TenLoaiPhong  LIKE N'%" + TenLoaiPhong + "%'";
            return SQL_KetNoi.Load(SQL);
        }
        public void Xoa(string MaLoaiPhong)
        {
            string SQL = string.Format(@"DELETE LoaiPhongTro WHERE MaLoaiPhong = '" + MaLoaiPhong + "'");
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void Them(string MaLoaiPhong, string TenLoaiPhong, decimal DienTichPhong, decimal GiaPhong,string GhiChu)
        {
            string SQL = "INSERT INTO LoaiPhongTro(MaLoaiPhong,TenLoaiPhong,DienTichPhong,GiaPhong,GhiChu)  VALUES ( '" + MaLoaiPhong + "',N'" + TenLoaiPhong + "'," + DienTichPhong + "," + GiaPhong + ",N'" + GhiChu + "')";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void Sua(string MaLoaiPhong, string MaLoaiPhong2, string TenLoaiPhong, decimal DienTichPhong, decimal GiaPhong, string GhiChu)
        {
            string SQL = "UPDATE LoaiPhongTro SET MaLoaiPhong = '" + MaLoaiPhong + "',TenLoaiPhong= N'" + TenLoaiPhong + "',DienTichPhong = " + DienTichPhong + ",GiaPhong = " + GiaPhong + ",GhiChu= N'" + GhiChu + "' WHERE MaLoaiPhong = '" + MaLoaiPhong2 + "'";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public int KiemTraDuLieuTonTai(string MaLoaiPhong)
        {
            int i = 0;
            string SQL = "SELECT * FROM LoaiPhongTro WHERE MaLoaiPhong = '" + MaLoaiPhong + "'";
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
