﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLKS.DTO;

namespace QLKS.DAO
{
    public class DatPhongDAO
    {
        static XL_DULIEU xldulieu = new XL_DULIEU();
        static public DataTable LoadAll()
        {
            string sql = "select * from DatPhong";
            return xldulieu.LoadData(sql);
        }
        static public bool IsExist(DatPhong dp)
        {
            string sql = "select * from DatPhong where MaPhong = " + dp.MaPhong + " and MaKhach = " + dp.MaKhach +
                " and NgayThue = '" + dp.NgayThue.ToString("MM-dd-yyyy HH:mm:ss.fff") + "'";
            DataTable table = xldulieu.LoadData(sql);
            if (table.Rows.Count < 1)
                return false;
            return true;
        }
        static public DataTable LoadByMaPhong(int maPhong)
        {
            string sql = "select * from DatPhong where MaPhong = " + maPhong;
            return xldulieu.LoadData(sql);
        }
        static public DataTable LoadThongTinKhach(int maPhong)
        {
            string sql = "select kh.MaKhach, kh.TenKhach, kh.DiaChi " +
                "from DatPhong dp join KhachHang kh on dp.MaKhach = kh.MaKhach" +
                " where MaPhong = " + maPhong;
            return xldulieu.LoadData(sql);
        }
        static public int Insert(DatPhong dp)
        {
            if (IsExist(dp))
                return 0;
            string sql = string.Format("Insert into DatPhong(MaPhong, MaKhach, NgayThue) " +
                "Values({0}, {1}, '{2}')", dp.MaPhong,dp.MaKhach, dp.NgayThue.ToString("MM-dd-yyyy HH:mm:ss.fff"));
            return xldulieu.Execute(sql);
        }

        static public int Delete(int maPhong)
        {
            string sql = "delete from DatPhong where MaPhong = " +maPhong;
            return xldulieu.Execute(sql);
        }
        static public DatPhong LoadOne(int maPhong)
        {
            string sql = "select * from DatPhong where MaPhong = " + maPhong;
            DataTable table = xldulieu.LoadData(sql);
            if (table.Rows.Count < 1)
                return null;
            DatPhong dp = new DatPhong(table.Rows[0].Field<int>(0), table.Rows[0].Field<int>(1),
                table.Rows[0].Field<DateTime>(2));
            return dp;
        }
        static public int GetMaPhong(int makhach)
        {
            string sql = "select * from DatPhong where MaKhach = " + makhach;
            
            DataTable table = xldulieu.LoadData(sql);
 
            if (table.Rows.Count < 1)
            {
                return 0;
            }
            else
                return table.Rows[0].Field<int>(0);
        }

    }
}
