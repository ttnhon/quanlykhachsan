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
    class LoaiKhachDAO
    {
        static public DataTable LoadAll()
        {
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = "select * from LoaiKhach";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        static public LoaiKhach LoadOne(int maLoai)
        {
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = "select * from LoaiKhach where MaLoai = " + maLoai;
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            if (table.Rows.Count < 1)
                return null;

            LoaiKhach lk = new LoaiKhach(table.Rows[0].Field<int>(0), table.Rows[0].Field<string>(1));
            return lk;
        }

        static public int Insert(LoaiKhach lk)
        {
            if (LoadOne(lk.MaLoai) != null)
                return 0;

            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = string.Format("Insert into LoaiKhach values (N'{0}')",lk.TenLoai);
            SqlCommand comm = new SqlCommand(sql, cnn);

            cnn.Open();
            int affectCount = comm.ExecuteNonQuery();
            cnn.Close();
            return affectCount;
        }

        static public int Update(LoaiKhach lk)
        {
            if (LoadOne(lk.MaLoai) == null)
                return 0;
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = string.Format("Update LoaiKhach Set LoaiKhach = '{0}'" +
                "Where MaLoai = {1}", lk.TenLoai, lk.MaLoai);
            SqlCommand comm = new SqlCommand(sql, cnn);

            cnn.Open();
            int affectCount = comm.ExecuteNonQuery();
            cnn.Close();
            return affectCount;
        }

        static public int GetMaLoaiByLoaiKhach(string loaiKhach)
        {
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = "select MaLoai from LoaiKhach where LoaiKhach = '" + loaiKhach + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            if (table.Rows.Count < 1)
                return 0;
            return table.Rows[0].Field<int>(0);
        }
    }
}
