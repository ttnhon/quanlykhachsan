using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    public class DatPhong
    {
        public int MaPhong;
        public int MaKhach;
        public DateTime NgayThue;

        public DatPhong()
        {
        }

        public DatPhong(int maPhong, int maKhach, DateTime ngayThue)
        {
            MaPhong = maPhong;
            MaKhach = maKhach;
            NgayThue = ngayThue;
        }
    }
}
