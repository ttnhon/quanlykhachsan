using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DAO
{
    public class XL_DULIEU
    {
        static public SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
        {
            DataSource = "REFICUL",
            InitialCatalog = "quanlykhachsan",
            //IntegratedSecurity = true,
            UserID = "sa",
            Password = "sa"
        };

        public DataTable LoadData(string sql)
        {
            SqlConnection cnn = new SqlConnection(sConnB.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
        public int Execute(string sql)
        {
            SqlConnection cnn = new SqlConnection(sConnB.ConnectionString);
            SqlCommand comm = new SqlCommand(sql, cnn);
            cnn.Open();
            int affectCount = comm.ExecuteNonQuery();
            cnn.Close();
            return affectCount;
        }
    }
}
