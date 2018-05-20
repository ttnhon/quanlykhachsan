using QLKS.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DAO
{
    class ThuePhongDAO
    {
        static XL_DULIEU xldulieu = new XL_DULIEU();
        static public DataTable LoadAll()
        {
            string sql = "select * from ThuePhong";
            return xldulieu.LoadData(sql);
        }
        static public bool IsExist(ThuePhongDTO tp)
        {
            string sql = "select * from ThuePhong where MaPhong = " + tp.MaPhong + " and MaKhach = " + tp.MaKhach +
                " and NgayBatDauThue = '" + tp.NgayBatDauThue.ToString("MM-dd-yyyy HH:mm:ss.fff") + "'";
            DataTable table = xldulieu.LoadData(sql);
            if (table.Rows.Count < 1)
                return false;
            return true;
        }
        static public DataTable LoadByMaPhong(int maPhong)
        {
            string sql = "select * from ThuePhong where MaPhong = " + maPhong;
            return xldulieu.LoadData(sql);
        }
        static public DataTable LoadThongTinKhach(int maPhong)
        {
            string sql = "select kh.MaKhach, kh.TenKhach, kh.DiaChi " +
                "from ThuePhong tp join KhachHang kh on tp.MaKhach = kh.MaKhach" +
                " where MaPhong = " + maPhong;
            return xldulieu.LoadData(sql);
        }
        static public int Insert(ThuePhongDTO tp)
        {
            if (IsExist(tp))
                return 0;
            string sql = string.Format("Insert into ThuePhong(MaPhong, MaKhach, NgayBatDauThue, SoNgayThue) " +
                "Values({0}, {1}, '{2}', {3})", tp.MaPhong, tp.MaKhach, 
                tp.NgayBatDauThue.ToString("MM-dd-yyyy HH:mm:ss.fff"),tp.SoNgayThue);
            return xldulieu.Execute(sql);
        }

        static public int Delete(int maPhong)
        {
            string sql = "delete from ThuePhong where MaPhong = " + maPhong;
            return xldulieu.Execute(sql);
        }
        static public ThuePhongDTO LoadOne(int maPhong)
        {
            string sql = "select * from ThuePhong where MaPhong = " + maPhong;
            DataTable table = xldulieu.LoadData(sql);
            if (table.Rows.Count < 1)
                return null;
            ThuePhongDTO tp = new ThuePhongDTO(table.Rows[0].Field<int>(0), table.Rows[0].Field<int>(1),
                table.Rows[0].Field<DateTime>(2),table.Rows[0].Field<int>(3));
            return tp;
        }
        static public int GetMaPhong(int makhach)
        {
            string sql = "select * from ThuePhong where MaKhach = " + makhach;

            DataTable table = xldulieu.LoadData(sql);

            if (table.Rows.Count < 1)
            {
                return 0;
            }
            else
                return table.Rows[0].Field<int>(0);
        }
        static public int SuaMaPhong(int phongCu, int phongMoi)
        {
            string sql = string.Format("update ThuePhong set MaPhong = {0} where MaPhong = {1}", 
                phongMoi, phongCu);
            return xldulieu.Execute(sql);
        }
    }
}
