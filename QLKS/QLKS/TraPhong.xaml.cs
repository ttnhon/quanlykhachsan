using QLKS.DAO;
using QLKS.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLKS
{
    /// <summary>
    /// Interaction logic for TraPhong.xaml
    /// </summary>
    public partial class TraPhong : Window
    {
        int MaPhong;
        float ThanhTien;
        public TraPhong(int maPhong)
        {
            InitializeComponent();

            

            MaPhong = maPhong;
            txtMaPhong.Text = maPhong.ToString();
            Phong p = PhongDAO.LoadOne(maPhong);
            LoaiPhong lp = LoaiPhongDAO.LoadOne(p.LoaiPhong);
            txtLoaiPhong.Text = lp.TenLoai;

            DataTable thuePhongDTO = ThuePhongDAO.LoadByMaPhong(maPhong);
            DateTime dNgayThue = thuePhongDTO.Rows[0].Field<DateTime>("NgayBatDauThue");
            DateTime dNgayTra = DateTime.Now;
            txtNgayThue.Text = dNgayThue.ToString("MM-dd-yyyy HH:mm");
            txtNgayTra.Text = dNgayTra.ToString("MM-dd-yyyy HH:mm");

            dataGridDsKhach.ItemsSource = ThuePhongDAO.LoadThongTinKhach(maPhong).DefaultView;

            DataTable dtGioHang = LoadDsDichVu();
            dgGioHang.ItemsSource = dtGioHang.DefaultView;

            float donGiaPhong = LoaiPhongDAO.GetDonGiaPhong(txtLoaiPhong.Text);
            float tienPhong = 0;
            float tienDichVu = TinhTongTien(dtGioHang);
            int dayDateDiff = (dNgayTra - dNgayThue).Days;
            if(dayDateDiff < 1)
            {
                int hourDiff = dNgayTra.Hour - dNgayThue.Hour;
                if (hourDiff < 10)
                    tienPhong = (hourDiff + 1) * (donGiaPhong / 10);
                else
                    tienPhong = donGiaPhong;
            }
            else
            {
                tienPhong = dayDateDiff * donGiaPhong;
            }
            txtTienPhong.Text = string.Format("{0:0,0}",tienPhong);
            txtDichVu.Text = string.Format("{0:0,0}", tienDichVu);

            ThanhTien = tienDichVu + tienPhong;
            txtThanhTien.Text = string.Format("{0:0,0}", ThanhTien);
        }

        DataTable LoadDsDichVu()
        {
            DataTable dtGioHang = new DataTable();
            dtGioHang.Columns.Add("MaDV", typeof(int));
            dtGioHang.Columns.Add("TenDV", typeof(string));
            dtGioHang.Columns.Add("DonGia", typeof(float));
            dtGioHang.Columns.Add("SoLuong", typeof(int));
            dtGioHang.Columns.Add("ThanhTien", typeof(float));

            DataTable table = ChiTietDichVuDAO.LoadByMaPhong(MaPhong);
            DataRow rowOfGioHang;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int maDv = table.Rows[i].Field<int>(0);
                DichVu dv = DichVuDAO.LoadOne(maDv);
                rowOfGioHang = dtGioHang.NewRow();
                rowOfGioHang["MaDV"] = maDv;
                rowOfGioHang["TenDV"] = dv.TenDV;
                rowOfGioHang["DonGia"] = dv.DonGia;
                rowOfGioHang["SoLuong"] = table.Rows[i].Field<int>(1);
                rowOfGioHang["ThanhTien"] = dv.DonGia * table.Rows[i].Field<int>(1);
                dtGioHang.Rows.Add(rowOfGioHang);
            }
            return dtGioHang;
        }
        float TinhTongTien(DataTable dtGioHang)
        {
            float tongTien = 0;
            foreach (DataRow dr in dtGioHang.Rows)
            {
                tongTien += dr.Field<float>("ThanhTien");
            }
            
            return tongTien;
        }

        private void BtnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Xác nhận trả phòng?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            TextBlock maKhach = dataGridDsKhach.Columns[0].GetCellContent(dataGridDsKhach.Items[0]) as TextBlock;

            DateTime dNgayLap = Convert.ToDateTime(txtNgayTra.Text);
            DateTime dNgayThue = Convert.ToDateTime(txtNgayThue.Text);
            HoaDon hd = new HoaDon(0, Int32.Parse(maKhach.Text), MaPhong, dNgayLap, dNgayThue, dNgayLap, ThanhTien);
            if(HoaDonDAO.Insert(hd)<1)
            {
                MessageBox.Show("Đã xảy ra lỗi\r\nXin mời thử lại", "Thông báo");
                return;
            }
            MessageBox.Show("Trả phòng thành công!\r\nHãy bấm Cập nhật để tải lại danh sách phòng", "Thông báo");
            ThuePhongDAO.Delete(MaPhong);
            ChiTietDichVuDAO.DeleteByMaPhong(MaPhong);
            PhongDAO.SetTinhTrangPhong(MaPhong, 1);
            PhongDAO.SetTrangThaiPhong(MaPhong, 5);
            this.Close();
        }

        private void BtnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
