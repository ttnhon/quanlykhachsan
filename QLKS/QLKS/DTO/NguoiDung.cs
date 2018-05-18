using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    class NguoiDung
    {
        public int MaSo;
        public string HoTen;
        public string LoaiNguoiDung;
        public string TenDangNhap;
        public string MatKhau;

        public NguoiDung()
        {
        }

        public NguoiDung(int maSo, string hoTen, string loaiNguoiDung, string tenDangNhap, string matKhau)
        {
            MaSo = maSo;
            HoTen = hoTen;
            LoaiNguoiDung = loaiNguoiDung;
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
        }
    }
}
