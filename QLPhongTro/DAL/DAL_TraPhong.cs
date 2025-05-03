using QLPhongTro.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongTro.DAL
{
    public class DAL_TraPhong
    {
        public DataTable LoadDanhSachThuePhong()
        {
            return SQL_KetNoi.Load("SELECT MaPhieuThue,a.MaPhong,TenPhong,TenLoaiPhong,NgayThue,TienCoc,Ten FROM ThuePhong a INNER JOIN PhongTro b ON a.MaPhong = b.MaPhongTro INNER JOIN LoaiPhongTro c ON b.MaLoaiPhong = c.MaLoaiPhong INNER JOIN TrangThai d ON b.TrangThai = d.Ma WHERE Loai = 'TTPHONG' AND TrangThai = '2' AND NgayTra IS NULL");
        }
        public void CapNhatTrangThai(string NgayTra, string MaPhieuThue,string MaPhongTro)
        {
            string SQL = "UPDATE ThuePhong SET NgayTra = '"+NgayTra+ "' WHERE MaPhieuThue = '"+ MaPhieuThue +"'  UPDATE PhongTro SET TrangThai = '1' WHERE MaPhongTro = '" + MaPhongTro + "'";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
    }
}
