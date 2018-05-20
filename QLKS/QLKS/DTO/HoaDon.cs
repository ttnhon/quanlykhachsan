using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    public class HoaDon
    {
        public int MaHD;
        public int MaKhach;
        public int MaPhong;
        public DateTime NgayLap;
        public DateTime NgayBatDauThue;
        public DateTime NgayTraPhong;
        public float ThanhTien;

        public HoaDon()
        {
        }

        public HoaDon(int maHD, int maKhach, int maPhong, DateTime ngayLap, DateTime ngayBatDauThue, DateTime ngayTraPhong, float thanhTien)
        {
            MaHD = maHD;
            MaKhach = maKhach;
            MaPhong = maPhong;
            NgayLap = ngayLap;
            NgayBatDauThue = ngayBatDauThue;
            NgayTraPhong = ngayTraPhong;
            ThanhTien = thanhTien;
        }
    }
}
