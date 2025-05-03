using QLPhongTro.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongTro.DAL
{
    public class DAL_Tang
    {
        public DataTable HienThi()
        {
            string SQL = "select * from Tang";
            return SQL_KetNoi.Load(SQL);
        }
        public DataTable TimKiem(string TenTang)
        {
            string SQL = "select * from Tang WHERE TenTang LIKE N'%" + TenTang + "%'";
            return SQL_KetNoi.Load(SQL);
        }
        public void Xoa(string MaTang)
        {
            string SQL = string.Format(@"DELETE Tang WHERE MaTang = '" + MaTang + "'");
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void Them(string MaTang, string TenTang, string GhiChu)
        {
            string SQL = "INSERT INTO Tang(MaTang,TenTang,GhiChu)  VALUES ( '" + MaTang + "',N'" + TenTang + "',N'" + GhiChu + "')";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public void Sua(string MaTang, string MaTang2, string TenTang, string GhiChu)
        {
            string SQL = "UPDATE Tang SET MaTang = '" + MaTang + "',TenTang=N'" + TenTang + "',GhiChu = N'" + GhiChu + "' WHERE MaTang = '" + MaTang2 + "'";
            SQL_KetNoi.ExecuteNonQuery(SQL);
        }
        public int KiemTraDuLieuTonTai(string MaTang)
        {
            int i = 0;
            string SQL = "SELECT * FROM Tang WHERE MaTang = '" + MaTang + "'";
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
    }
}
