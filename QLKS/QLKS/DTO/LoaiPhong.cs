using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    class LoaiPhong
    {
        public string MaLoai;
        public string TenLoai;
        public string MoTa;
        public float DonGia;
        public int SoNguoiToiDa;
        public int ConSuDung;

        public LoaiPhong()
        {
        }

        public LoaiPhong(string maLoai, string tenLoai, string moTa, float donGia, int soNguoiToiDa, int conSuDung)
        {
            MaLoai = maLoai;
            TenLoai = tenLoai;
            MoTa = moTa;
            DonGia = donGia;
            SoNguoiToiDa = soNguoiToiDa;
            ConSuDung = conSuDung;
        }
    }
}
