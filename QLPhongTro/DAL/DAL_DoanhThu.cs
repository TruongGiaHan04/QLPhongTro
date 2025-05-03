using QLPhongTro.DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongTro.DAL
{
    public class DAL_DoanhThu
    {
        public DataTable DoanhThu(decimal ThangFrom, decimal NamFrom)
        {
            string SQL = "select * from DongTien WHERE Thang = "+ ThangFrom+ " AND Nam = " + NamFrom + "";
            return SQL_KetNoi.Load(SQL);
        }

        public DataTable DoanhThuTheoGio(string NgayThue, string NgayThue2)
        {
            string SQL = "select NgayThue,TongGioThue,TongTien from ThuePhongTheoGio WHERE NgayThue BETWEEN '" + NgayThue + "' AND '" + NgayThue2 + "'";
            return SQL_KetNoi.Load(SQL);
        }
    }
}
