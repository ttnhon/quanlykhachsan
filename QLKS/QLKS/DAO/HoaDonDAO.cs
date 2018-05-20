using QLKS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DAO
{
    public class HoaDonDAO
    {
        static XL_DULIEU xldulieu = new XL_DULIEU();
        static public int Insert(HoaDon hd)
        {
            string sql = string.Format("insert into HoaDon(MaKhach, MaPhong, NgayLap, NgayBatDauThue," +
                " NgayTraPhong, ThanhTien) values ({0},{1},'{2}','{3}','{4}',{5})",
                hd.MaKhach, hd.MaPhong, hd.NgayLap.ToString("MM-dd-yyyy HH:mm:ss.fff"),
                hd.NgayBatDauThue.ToString("MM-dd-yyyy HH:mm:ss.fff"), 
                hd.NgayTraPhong.ToString("MM-dd-yyyy HH:mm:ss.fff"), hd.ThanhTien);
            return xldulieu.Execute(sql);
        }
    }
}
