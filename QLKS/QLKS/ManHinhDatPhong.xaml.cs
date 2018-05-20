﻿using QLKS.DAO;
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
    /// Interaction logic for ManHinhDatPhong.xaml
    /// </summary>
    public partial class ManHinhDatPhong : Window
    {
        int soLuongKhach;
        int MaPhong;

        public ManHinhDatPhong(int maPhong)
        {
            InitializeComponent();
            cbbLoaiKhach.ItemsSource = LoaiKhachDAO.LoadAll().DefaultView;
            dataGridDsKhach.ItemsSource = KhachHangDAO.LoadAll().DefaultView;
            soLuongKhach = KhachHangDAO.GetSoLuongKhach();
            MaPhong = maPhong;
            txtMaPhong.Text = maPhong.ToString();
            Phong p = PhongDAO.LoadOne(maPhong);
            LoaiPhong lp = LoaiPhongDAO.LoadOne(p.LoaiPhong);
            txtLoaiPhong.Text = lp.TenLoai;
            txtMaKhach.Text = (soLuongKhach+1).ToString();
            cbbLoaiKhach.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Xác nhận thêm?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            KhachHang kh = new KhachHang(Int32.Parse(txtMaKhach.Text), txtHoTen.Text, txtCMND.Text, txtDiaChi.Text,
                txtDienThoai.Text, cbbLoaiKhach.SelectedIndex + 1);
          
            if (KhachHangDAO.Insert(kh) != 0)
            {
                soLuongKhach = KhachHangDAO.GetSoLuongKhach()+1;
                txtMaKhach.Text = soLuongKhach.ToString();
                dataGridDsKhach.ItemsSource = KhachHangDAO.LoadAll().DefaultView;
            }
            dgDanhSach.Items.Add(kh);

        }

        private void txtTimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            string tenKhach = txtTimKiem.Text;
            if (tenKhach.Equals(""))
                dataGridDsKhach.ItemsSource = KhachHangDAO.LoadAll().DefaultView;
            else
            {
                dataGridDsKhach.ItemsSource = KhachHangDAO.TimTheoTen(tenKhach).DefaultView;
            }
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
            else
                txtMaKhach.Text = (soLuongKhach + 1).ToString();
        }

        private void BtnDatPhong_Click(object sender, RoutedEventArgs e)
        {
            string ngayThue = dpNgayThue.Text;
            
            int maPhong = Int32.Parse(txtMaPhong.Text);
            if(ngayThue.Equals(""))
            {
                MessageBox.Show("Hãy chọn Ngày nhận phòng", "Thông báo");
                return;
            }
            DateTime dateTime = Convert.ToDateTime(ngayThue);
            if (dgDanhSach.Items.Count < 1)
            {
                MessageBox.Show("Hãy thêm khách hàng", "Thông báo");
                return;
            }
            if (MessageBox.Show("Xác nhận đặt phòng?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            for (int i = 0; i < dgDanhSach.Items.Count; i++)
            {
                TextBlock a = dgDanhSach.Columns[0].GetCellContent(dgDanhSach.Items[i]) as TextBlock;
                DatPhong dp = new DatPhong(maPhong, Int32.Parse(a.Text), dateTime);
                DatPhongDAO.Insert(dp);
            }
            if(DatPhongDAO.LoadByMaPhong(maPhong).Rows.Count<1)
            {
                MessageBox.Show("Đã có lỗi xảy ra\r\nXin mời thử lại", "Thông báo");
                this.Close();
                return;
            }
            PhongDAO.SetTinhTrangPhong(maPhong, 4);
            MessageBox.Show("Đặt phòng thành công!\r\nHãy bấm Cập nhật để tải lại danh sách phòng!", "Thông báo");
            this.Close();
        }

        private void BtnHuy_Click(object sender, RoutedEventArgs e)
        {
            soLuongKhach = KhachHangDAO.GetSoLuongKhach()+1;
            txtMaKhach.Text = soLuongKhach.ToString();
            txtHoTen.Text = "";
            txtCMND.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
            cbbLoaiKhach.SelectedIndex = 0;
        }
    }
}
