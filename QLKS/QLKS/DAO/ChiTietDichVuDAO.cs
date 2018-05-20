using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DAO
{
    public class ChiTietDichVuDAO
    {
        static XL_DULIEU xldulieu = new XL_DULIEU();
        static public DataTable LoadByMaPhong(int maPhong)
        {
            string sql = "select MaDV, SoLuong, MaPhong from ChiTietDichVu where MaPhong = " + maPhong;
            return xldulieu.LoadData(sql);
        }
        static public int DeleteByMaPhong(int maPhong)
        {
            string sql = "delete from ChiTietDichVu where MaPhong = " + maPhong;
            return xldulieu.Execute(sql);
        }
        static public int Insert(int maDV, int maKhach, int soLuong, int maPhong)
        {
            string sql = string.Format("insert into ChiTietDichVu(MaDV, MaKhach, NgaySuDung, SoLuong, MaPhong) " +
                "values ({0},{1},'{2}',{3},{4})", maDV, maKhach, DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss.fff"), soLuong, maPhong);
            return xldulieu.Execute(sql);
        }
    }
}
