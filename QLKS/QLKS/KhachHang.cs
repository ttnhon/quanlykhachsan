using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS
{
    public class KhachHang
    {
        public int MaKhach;
        public string TenKhach;
        public string SoCMND;
        public string DiaChi;
        public string DienThoai;
        public int LoaiKhach;

        public KhachHang()
        {
        }

        public KhachHang(int maKhach, string tenKhach, string soCMND, string diaChi, string dienThoai, int loaiKhach)
        {
            MaKhach = maKhach;
            TenKhach = tenKhach;
            SoCMND = soCMND;
            DiaChi = diaChi;
            DienThoai = dienThoai;
            LoaiKhach = loaiKhach;
        }
    }
}
