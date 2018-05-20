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
    /// Interaction logic for ThongTinKhachHang.xaml
    /// </summary>
    public partial class ThongTinKhachHang : Window
    {
        int MaPhong;
        public ThongTinKhachHang(int maPhong)
        {
            InitializeComponent();
            MaPhong = maPhong;
            txtMaPhong.Text = maPhong.ToString();
            Phong p = PhongDAO.LoadOne(maPhong);
            LoaiPhong lp = LoaiPhongDAO.LoadOne(p.LoaiPhong);
            cbbLoaiKhach.ItemsSource = LoaiKhachDAO.LoadAll().DefaultView;
            txtLoaiPhong.Text = lp.TenLoai;

            DataTable table = ThuePhongDAO.LoadByMaPhong(maPhong);
            dpNgayThue.Text = table.Rows[0].Field<DateTime>(2).ToString("MM/dd/yyyy");

            dataGridDsKhach.ItemsSource = ThuePhongDAO.LoadThongTinKhach(maPhong).DefaultView;
            cbbLoaiKhach.SelectedIndex = 0;
        }

        private void txtTimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            string tenKhach = txtTimKiem.Text;
            if (tenKhach.Equals(""))
                dataGridDsKhach.ItemsSource = ThuePhongDAO.LoadThongTinKhach(Int32.Parse(txtMaPhong.Text)).DefaultView;
            else
            {
                dataGridDsKhach.ItemsSource = KhachHangDAO.TimTheoTen(tenKhach).DefaultView;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Xác nhận thay đổi thông tin khách?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            KhachHang kh = new KhachHang(Int32.Parse(txtMaKhach.Text), txtHoTen.Text, txtCMND.Text, txtDiaChi.Text,
                txtDienThoai.Text, cbbLoaiKhach.SelectedIndex + 1);
            if (KhachHangDAO.Update(kh) > 0)
            {
                MessageBox.Show("Lưu thông tin thành công", "Thông báo");
                dataGridDsKhach.ItemsSource = ThuePhongDAO.LoadThongTinKhach(Int32.Parse(txtMaPhong.Text)).DefaultView;
            }
            else
                MessageBox.Show("Có lỗi xảy ra\r\nXin vui lòng thử lại", "Thông báo");
        }

        private void dataGridDsKhach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = dataGridDsKhach.SelectedItem as DataRowView;
            if (rowView != null)
            {
                int maKhach = Int32.Parse(rowView.Row["MaKhach"].ToString());
                KhachHang kh = KhachHangDAO.LoadOne(maKhach);
                txtMaKhach.Text = kh.MaKhach.ToString();
                txtHoTen.Text = kh.TenKhach;
                txtCMND.Text = kh.SoCMND;
                txtDiaChi.Text = kh.DiaChi;
                txtDienThoai.Text = kh.DienThoai;
                cbbLoaiKhach.SelectedIndex = kh.LoaiKhach - 1;
            }
        }
    }
}
