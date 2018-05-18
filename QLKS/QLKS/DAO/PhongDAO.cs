using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLKS.DTO;

namespace QLKS.DAO
{
    public class PhongDAO
    {
        static public DataTable LoadAll()
        {
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = "select p.MaPhong,lp.TenLoai,tt.TinhTrang,tth.TrangThai " +
                "from Phong p join LoaiPhong lp on p.LoaiPhong = lp.MaLoai " +
                "join TinhTrangPhong tt on p.TinhTrang = tt.MaTT " +
                "join TrangThaiPhong tth on p.TrangThai = tth.MaTT";
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
                "Values({0}, '{1}', {2}, {3}, N'{4}')", p.MaPhong, p.LoaiPhong, p.TinhTrang, p.TrangThai
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

        static public int Delete(Phong p)
        {
            if (LoadOne(p.MaPhong) == null)
                return 0;
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = string.Format("Delete from Phong where MaPhong = '{0}'", p.MaPhong);
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
        static XL_DULIEU xldulieu = new XL_DULIEU();
        static public int GetSoLuongPhong()
        {
            string sql = "select count(*) from Phong";
            DataTable table = xldulieu.LoadData(sql);
            return table.Rows[0].Field<int>(0);
        }
        static public int GetSoLuongPhongSuDung()
        {
            string sql = "select count(*) from Phong where TinhTrang != 3";
            DataTable table = xldulieu.LoadData(sql);
            return table.Rows[0].Field<int>(0);
        }
        static public DataTable LoadPhongSuDung()
        {
            string sql = "select p.MaPhong,lp.TenLoai,tt.TinhTrang,tth.TrangThai " +
                "from Phong p join LoaiPhong lp on p.LoaiPhong = lp.MaLoai " +
                "join TinhTrangPhong tt on p.TinhTrang = tt.MaTT " +
                "join TrangThaiPhong tth on p.TrangThai = tth.MaTT where p.TinhTrang != 3";
            return xldulieu.LoadData(sql);
        }
        static public int GetTinhTrangPhong(int maPhong)
        {
            string sql = "select TinhTrang from Phong where MaPhong = " + maPhong;
            DataTable table = xldulieu.LoadData(sql);
            if (table.Rows.Count < 1)
                return 0;
            return table.Rows[0].Field<int>(0);
        }
        static public int GetTrangThaiPhong(int maPhong)
        {
            string sql = "select TrangThai from Phong where MaPhong = " + maPhong;
            DataTable table = xldulieu.LoadData(sql);
            if (table.Rows.Count < 1)
                return 0;
            return table.Rows[0].Field<int>(0);
        }
        static public int SetTinhTrangPhong(int maPhong, int tinhTrang)
        {
            string sql = "Update Phong set TinhTrang = " + tinhTrang + " where MaPhong = " + maPhong;
            return xldulieu.Execute(sql);
        }
        static public int SetTrangThaiPhong(int maPhong, int trangThai)
        {
            string sql = "Update Phong set TrangThai = " + trangThai + " where MaPhong = " + maPhong;
            return xldulieu.Execute(sql);
        }
    }
}
