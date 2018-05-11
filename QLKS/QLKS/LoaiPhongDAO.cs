using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLKS
{
    class LoaiPhongDAO
    {
        static public DataTable LoadAll()
        {
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = "select * from LoaiPhong";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        static public LoaiPhong LoadOne(string maloai)
        {
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = "select * from LoaiPhong where MaLoai = '"+maloai+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable table = new DataTable();
            da.Fill(table);

            if (table.Rows.Count < 1)
                return null;

            LoaiPhong lp = new LoaiPhong(table.Rows[0].Field<string>(0), table.Rows[0].Field<string>(1),
                table.Rows[0].Field<string>(2), Convert.ToSingle(table.Rows[0][3]),
                table.Rows[0].Field<int>(4));
            return lp;
        }

        static public int Insert(LoaiPhong lp)
        {
            if (LoadOne(lp.MaLoai) != null)
                return 0;
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = string.Format("Insert into LoaiPhong(MaLoai, TenLoai, MoTa, DonGia, SoNguoiToiDa) " +
                "Values('{0}', '{1}', '{2}', {3}, {4})", lp.MaLoai, lp.TenLoai, lp.MoTa
                , lp.DonGia, lp.SoNguoiToiDa);
            SqlCommand comm = new SqlCommand(sql, cnn);

            cnn.Open();
            int affectCount = comm.ExecuteNonQuery();
            cnn.Close();
            return affectCount;
        }


    }
}
