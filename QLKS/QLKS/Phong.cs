using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS
{
    class Phong
    {
        public int MaPhong;
        public string LoaiPhong;
        public int TinhTrang;
        public int TrangThai;
        public string GhiChu;

        public Phong()
        {
        }

        public Phong(int maPhong, string loaiPhong, int tinhTrang, int trangThai, string ghiChu)
        {
            MaPhong = maPhong;
            LoaiPhong = loaiPhong;
            TinhTrang = tinhTrang;
            TrangThai = trangThai;
            GhiChu = ghiChu;
        }
    }
}
