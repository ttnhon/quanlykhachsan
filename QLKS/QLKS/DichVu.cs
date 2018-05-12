using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS
{
    class DichVu
    {
        public int MaDV;
        public string TenDV;
        public float DonGia;
        public string GhiChu;
        public int ConSuDung;

        public DichVu()
        {
        }

        public DichVu(int maDV, string tenDV, float donGia, string ghiChu, int conSuDung)
        {
            MaDV = maDV;
            TenDV = tenDV;
            DonGia = donGia;
            GhiChu = ghiChu;
            ConSuDung = conSuDung;
        }
    }
}
