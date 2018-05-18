using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLKS
{
    class KhachHangDAO
    {
        static public DataTable LoadAll()
        {
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = "select * from KhachHang";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
        
        static public KhachHang LoadOne(int maKhach)
        {
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = "select * from KhachHang where MaKhach = " + maKhach;
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            if (table.Rows.Count < 1)
                return null;

            KhachHang dv = new KhachHang(table.Rows[0].Field<int>(0), table.Rows[0].Field<string>(1),
                table.Rows[0].Field<string>(2), table.Rows[0].Field<string>(3),
                table.Rows[0].Field<string>(4), table.Rows[0].Field<int>(5));
            return dv;
        }

        static public int Insert(KhachHang kh)
        {
            if (LoadOne(kh.MaKhach) != null)
                return 0;
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = string.Format("Insert into KhachHang(TenKhach, SoCMND, DiaChi, DienThoai, LoaiKhach) " +
                "Values('{0}', '{1}', '{2}', '{3}', {4})", kh.TenKhach, kh.SoCMND, kh.DiaChi, kh.DienThoai,
                kh.LoaiKhach);
            SqlCommand comm = new SqlCommand(sql, cnn);

            cnn.Open();
            int affectCount = comm.ExecuteNonQuery();
            cnn.Close();
            return affectCount;
        }

        static public int Update(KhachHang kh)
        {
            if (LoadOne(kh.MaKhach) == null)
                return 0;
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = string.Format("Update KhachHang Set TenKhach = '{0}', SoCMND = '{1}', " +
                "DiaChi = '{2}', DienThoai = '{3}', LoaiKhach = {4}" +
                " Where MaKhach = {5}", kh.TenKhach, kh.SoCMND, kh.DiaChi, kh.DienThoai, kh.LoaiKhach,
                kh.MaKhach);
            SqlCommand comm = new SqlCommand(sql, cnn);

            cnn.Open();
            int affectCount = comm.ExecuteNonQuery();
            cnn.Close();
            return affectCount;
        }
    }
}
