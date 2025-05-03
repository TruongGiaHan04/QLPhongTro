using QLPhongTro.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongTro.DAL
{
    public class DAL_ThueTheoGio
    {
        public DataTable HienThi()
        {
            string SQL = "select * from ThuePhongTheoGio";
            return SQL_KetNoi.Load(SQL);
        }
        public DataTable LayGiaPhongTheoGio(string MaPhongTro)
        {
            string SQL = "SELECT GiaPhong FROM PhongTro a LEFT JOIN LoaiPhongTro b ON a.MaLoaiPhong = b.MaLoaiPhong where b.MaLoaiPhong = 'THEOGIO' and a.MaPhongTro = '"+ MaPhongTro + "'";
            return SQL_KetNoi.Load(SQL);
        }
        public DataTable LoadDanhSachPhong()
        {
            return SQL_KetNoi.Load("SELECT * FROM PhongTro WHERE TrangThai = '1' AND MaLoaiPhong = 'THEOGIO'");
        }
        public void Xoa(string MaPT)
        {
            string SQL = string.Format(@"DELETE ThuePhongTheoGio WHERE MaPT = '" + MaPT + "'");
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void Them(string MaPT, string MaPhong, string NgayThue, string GioVao, string PhutVao,string GioRa,string PhutRa, string TongGioThue,string TongTien,string NguoiThue)
        {
            string SQL = "INSERT INTO ThuePhongTheoGio(MaPT,MaPhong,NgayThue,GioVao,PhutVao,GioRa,PhutRa,TongGioThue,TongTien,NguoiThue,TrangThai)  VALUES ( '" + MaPT + "','" + MaPhong + "','" + NgayThue + "'," + GioVao + "," + PhutVao + ","+ GioRa + ","+ PhutRa + ","+ TongGioThue + ","+ TongTien + ",N'"+ NguoiThue + "',N'Chưa thanh toán')";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void Sua(string MaPT, string MaPhong, string NgayThue, string GioVao, string PhutVao, string GioRa, string PhutRa, string TongGioThue, string TongTien, string NguoiThue)
        {
            string SQL = "UPDATE ThuePhongTheoGio SET MaPhong = '" + MaPhong + "',NgayThue='" + NgayThue + "',GioVao = " + GioVao + ",PhutVao = " + PhutVao + ",GioRa=" + GioRa + ",PhutRa="+ PhutRa + ",TongGioThue = "+ TongGioThue + ",TongTien = "+ TongTien + ",NguoiThue = N'"+ NguoiThue + "' WHERE MaPT = '" + MaPT + "'";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public int KiemTraDuLieuTonTai(string MaPT)
        {
            int i = 0;
            string SQL = "SELECT * FROM ThuePhongTheoGio WHERE MaPT = '" + MaPT + "'";
            DataTable dt = SQL_KetNoi.Load(SQL);
            if (dt.Rows.Count > 0)
            {
                i = 0;
            }
            else
            {
                i = 1;
            }
            return i;
        }
        public void CapNhatTrangThai(string MaPT, string MaPhong)
        {
            string SQL = "UPDATE ThuePhongTheoGio SET TrangThai = N'Đã thanh toán' WHERE MaPT = '" + MaPT + "'  UPDATE PhongTro SET TrangThai = '1' WHERE MaPhongTro = '" + MaPhong + "'";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
    }
}
