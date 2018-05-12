using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLKS
{
    class NguoiDungDAO
    {
        static public string GetHoTenByUser(string user)
        {
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = "select HoTen from NguoiDung where TenDangNhap = '" + user + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            if (table.Rows.Count < 1)
                return null;

            return table.Rows[0].Field<string>(0);
        }

        static public string GetMatKhauByUser(string user)
        {
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = "select MatKhau from NguoiDung where TenDangNhap = '" + user + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            if (table.Rows.Count < 1)
                return null;

            return table.Rows[0].Field<string>(0);
        }

        static public int GetPhanQuyenByUser(string user)
        {
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = "select pq.MucDo from NguoiDung nd, PhanQuyen pq " +
                "where nd.LoaiNguoiDung = pq.LoaiNguoiDung and nd.TenDangNhap = '"+user+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            if (table.Rows.Count < 1)
                return 0;

            return table.Rows[0].Field<int>(0);
        }
    }
}
