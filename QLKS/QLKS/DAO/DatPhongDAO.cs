using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLKS.DAO
{
    public class DatPhongDAO
    {
        XL_DULIEU xldulieu = new XL_DULIEU();
        public DataTable LoadAll()
        {
            string sql = "select * from DatPhong";
            return xldulieu.LoadData(sql);
        }
    }
}
