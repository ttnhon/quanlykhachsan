using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DTO
{
    class LoaiKhach
    {
        public int MaLoai;
        public string TenLoai;

        public LoaiKhach()
        {
        }

        public LoaiKhach(int maLoai, string tenLoai)
        {
            MaLoai = maLoai;
            TenLoai = tenLoai;
        }
    }
}
