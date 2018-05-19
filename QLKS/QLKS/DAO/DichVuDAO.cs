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
    class DichVuDAO
    {
        static public DataTable LoadAll()
        {
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = "select * from DichVu";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        static public DichVu LoadOne(int maDV)
        {
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = "select * from DichVu where MaDV = " + maDV;
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            if (table.Rows.Count < 1)
                return null;

            DichVu dv = new DichVu(table.Rows[0].Field<int>(0), table.Rows[0].Field<string>(1),
                Convert.ToSingle(table.Rows[0][2]), table.Rows[0].Field<string>(3), 
                Convert.ToInt32((bool)table.Rows[0][4]));
            return dv;
        }

        static public int Insert(DichVu dv)
        {
            if (LoadOne(dv.MaDV) != null)
                return 0;
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = string.Format("Insert into DichVu(TenDV, DonGia, GhiChu, ConSuDung) " +
                "Values(N'{0}', {1}, N'{2}', {3})", dv.TenDV, dv.DonGia, dv.GhiChu,
                dv.ConSuDung);
            SqlCommand comm = new SqlCommand(sql, cnn);

            cnn.Open();
            int affectCount = comm.ExecuteNonQuery();
            cnn.Close();
            return affectCount;
        }

        static public int Update(DichVu dv)
        {
            if (LoadOne(dv.MaDV) == null)
                return 0;
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = string.Format("Update DichVu Set TenDV = N'{0}', DonGia = {1}, " +
                "GhiChu = N'{2}', ConSuDung = {3} Where MaDV = {4}", dv.TenDV, dv.DonGia, dv.GhiChu,
                dv.ConSuDung, dv.MaDV);
            SqlCommand comm = new SqlCommand(sql, cnn);

            cnn.Open();
            int affectCount = comm.ExecuteNonQuery();
            cnn.Close();
            return affectCount;
        }

        static public int Drop(int maDV)
        {
            if (LoadOne(maDV) == null)
                return 0;
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = string.Format("Update DichVu Set ConSuDung = {0} Where MaDV = {1}",
                0, maDV);
            SqlCommand comm = new SqlCommand(sql, cnn);

            cnn.Open();
            int affectCount = comm.ExecuteNonQuery();
            cnn.Close();
            return affectCount;
        }
        static public int Undrop(int maDV)
        {
            if (LoadOne(maDV) == null)
                return 0;
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = string.Format("Update DichVu Set ConSuDung = {0} Where MaDV = {1}",
                1, maDV);
            SqlCommand comm = new SqlCommand(sql, cnn);

            cnn.Open();
            int affectCount = comm.ExecuteNonQuery();
            cnn.Close();
            return affectCount;
        }
    }
}
