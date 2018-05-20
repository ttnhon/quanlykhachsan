using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    class ChiTietDichVu
    {
        public ChiTietDichVu()
        {
        }

        public int MaDV { get; set; }
        public string TenDV { get; set; }
        public float DonGia { get; set; }
        public int SoLuong { get; set; }
        public float ThanhTien { get; set; }

        public ChiTietDichVu(int maDV, string tenDV, float donGia, int soLuong, float thanhTien)
        {
            MaDV = maDV;
            TenDV = tenDV;
            DonGia = donGia;
            SoLuong = soLuong;
            ThanhTien = thanhTien;
        }
    }
}
