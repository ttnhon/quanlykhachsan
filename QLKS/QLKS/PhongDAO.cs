using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLKS
{
    class PhongDAO
    {
        static public DataTable LoadAll()
        {
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = "select * from Phong";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        static public Phong LoadOne(int maPhong)
        {
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = "select * from Phong where MaPhong = " + maPhong;
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            if (table.Rows.Count < 1)
                return null;

            Phong p = new Phong(table.Rows[0].Field<int>(0), table.Rows[0].Field<string>(1),
                table.Rows[0].Field<int>(2), table.Rows[0].Field<int>(3),
                table.Rows[0].Field<string>(4));
            return p;
        }

        static public int Insert(Phong p)
        {
            if (LoadOne(p.MaPhong) != null)
                return 0;
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = string.Format("Insert into Phong(MaPhong, LoaiPhong, TinhTrang, TrangThai, GhiChu) " +
                "Values({0}, '{1}', {2}, {3}, '{4}')", p.MaPhong, p.LoaiPhong, p.TinhTrang, p.TrangThai
                , p.GhiChu);
            SqlCommand comm = new SqlCommand(sql, cnn);

            cnn.Open();
            int affectCount = comm.ExecuteNonQuery();
            cnn.Close();
            return affectCount;
        }

        static public int Update(Phong p)
        {
            if (LoadOne(p.MaPhong) == null)
                return 0;
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = string.Format("Update Phong Set LoaiPhong = '{0}', TinhTrang = {1}, " +
                "TrangThai = {2}, GhiChu = '{3}' Where MaPhong = {4}", p.LoaiPhong, p.TinhTrang, p.TrangThai,
                p.GhiChu, p.MaPhong);
            SqlCommand comm = new SqlCommand(sql, cnn);

            cnn.Open();
            int affectCount = comm.ExecuteNonQuery();
            cnn.Close();
            return affectCount;
        }

        static public int Drop(int maPhong)
        {
            if (LoadOne(maPhong) == null)
                return 0;
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = string.Format("Update Phong Set TinhTrang = {0} Where MaPhong = {1}",
                3, maPhong);
            SqlCommand comm = new SqlCommand(sql, cnn);

            cnn.Open();
            int affectCount = comm.ExecuteNonQuery();
            cnn.Close();
            return affectCount;
        }
        static public int Undrop(int maPhong)
        {
            if (LoadOne(maPhong) == null)
                return 0;
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = string.Format("Update Phong Set TinhTrang = {0} Where MaPhong = {1}",
                1, maPhong);
            SqlCommand comm = new SqlCommand(sql, cnn);

            cnn.Open();
            int affectCount = comm.ExecuteNonQuery();
            cnn.Close();
            return affectCount;
        }
    }
}
