using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    class ThuePhongDTO
    {
        public int MaPhong;
        public int MaKhach;
        public DateTime NgayBatDauThue;
        public int SoNgayThue;

        public ThuePhongDTO()
        {
        }

        public ThuePhongDTO(int maPhong, int maKhach, DateTime ngayBatDauThue, int soNgayThue)
        {
            MaPhong = maPhong;
            MaKhach = maKhach;
            NgayBatDauThue = ngayBatDauThue;
            SoNgayThue = soNgayThue;
        }
    }
}
