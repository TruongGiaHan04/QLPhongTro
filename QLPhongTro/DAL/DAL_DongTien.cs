using QLPhongTro.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongTro.DAL
{
    public class DAL_DongTien
    {
        public DataTable HienThi()
        {
            string SQL = "select * from DongTien";
            return SQL_KetNoi.Load(SQL);
        }
        public DataTable DichVu()
        {
            string SQL = "select * from DichVu";
            return SQL_KetNoi.Load(SQL);
        }
        public void SuaDichVu(decimal TienDien, decimal TienNuoc, decimal TienWifi, decimal TienRac)
        {
            string SQL = "UPDATE DichVu set TienDien = " + TienDien + ",TienNuoc = " + TienNuoc + ",TienWifi = " + TienWifi + ",TienRac = " + TienRac + "";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public DataTable LoadDanhSachPhong()
        {
            return SQL_KetNoi.Load("SELECT * FROM PhongTro WHERE TrangThai = '2'");
        }
        public DataTable TimKiem(string MaPhong,decimal Thang,decimal Nam)
        {
            string SQL = "select * from DongTien WHERE MaPhong LIKE N'%" + MaPhong + "%' AND Thang = "+ Thang + " and Nam = "+Nam+"";
            return SQL_KetNoi.Load(SQL);
        }
        public DataTable DanhSachGuiEmail(string MaPhong, decimal Thang, decimal Nam)
        {
            string SQL = "select Thang,Nam,a.MaPhong,d.Email from DongTien a INNER JOIN ThuePhong b ON a.MaPhong = b.MaPhong \r\nINNER JOIN ChiTietThuePhong c ON b.MaPhieuThue = c.MaPhieuThue INNER JOIN KhachHang d ON c.MaKhachHang = d.MaKhachHang WHERE a.MaPhong LIKE N'%" + MaPhong + "%' AND Thang = " + Thang + " and Nam = " + Nam + " AND Email <> '' AND Email IS NOT NULL";
            return SQL_KetNoi.Load(SQL);
        }
        public void Xoa(decimal Thang, decimal Nam,string MaPhong)
        {
            string SQL = string.Format(@"DELETE DongTien WHERE Thang = " + Thang + " AND Nam = " + Nam + " AND  MaPhong = '"+MaPhong+"'");
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void ThanhToan(decimal Thang, decimal Nam, string MaPhong)
        {
            string SQL = string.Format(@"update DongTien set trangthai = '1' WHERE Thang = " + Thang + " AND Nam = " + Nam + " AND  MaPhong = '" + MaPhong + "'");
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void Them(decimal Thang, decimal Nam, string MaPhong,decimal TienPhong, decimal TienDien, decimal TienNuoc, decimal TienWifi, decimal TienRac, decimal ChiPhiKhac, decimal TongTien, decimal TienDienGia, decimal TienDienTong, decimal TienNuocGia, decimal TienNuocTong)
        {
            string SQL = "INSERT INTO DongTien(Thang,Nam,MaPhong,TienPhong,TienDien,TienNuoc,TienWifi,TienRac,ChiPhiKhac,TongTien,TienDienGia,TienDienTong,TienNuocGia,TienNuocTong)  VALUES ( " + Thang + "," + Nam + ",'" + MaPhong + "'," + TienPhong + "," + TienDien + "," + TienNuoc + "," + TienWifi + "," + TienRac + "," + ChiPhiKhac + "," + TongTien + "," + TienDienGia + "," + TienDienTong + "," + TienNuocGia + "," + TienNuocTong + ")";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void Sua(decimal Thang, decimal Nam, string MaPhong, decimal TienPhong, decimal TienDien, decimal TienNuoc, decimal TienWifi, decimal TienRac, decimal ChiPhiKhac, decimal TongTien, decimal TienDienGia, decimal TienDienTong, decimal TienNuocGia, decimal TienNuocTong)
        {
            string SQL = "UPDATE DongTien SET TienPhong = " + TienPhong + ",TienDien = " + TienDien + ",TienNuoc = " + TienNuoc + ",TienWifi = " + TienWifi + ",TienRac = " + TienRac + ",ChiPhiKhac = " + ChiPhiKhac + ",TongTien = " + TongTien + ",TienDienGia = " + TienDienGia + ",TienDienTong = " + TienDienTong + ",TienNuocGia = " + TienNuocGia + ",TienNuocTong = " + TienNuocTong + "  WHERE Thang = " + Thang + " AND Nam = " + Nam + " AND MaPhong = '" + MaPhong + "'";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public int KiemTraDuLieuTonTai(decimal Thang, decimal Nam, string MaPhong)
        {
            int i = 0;
            string SQL = "SELECT * FROM DongTien WHERE Thang = " + Thang + " AND Nam = " + Nam + " AND MaPhong = '" + MaPhong + "'";
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
