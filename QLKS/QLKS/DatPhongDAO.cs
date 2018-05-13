using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLKS
{
    class DatPhongDAO
    {
        static public DataTable LoadAll()
        {
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);
            string sql = "select * from DatPhong";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
    }
}
