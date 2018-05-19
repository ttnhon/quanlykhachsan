using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    public class KhachHang
    {
        public int MaKhach { get; set; }
        public string TenKhach { get; set; }
        public string SoCMND { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public int LoaiKhach { get; set; }

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
