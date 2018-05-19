using QLKS.DAO;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for Trangchu.xaml
    /// </summary>
    public partial class Trangchu : Window
    {
        string account;

        private void btnQuanLyPhong_Click(object sender, RoutedEventArgs e)
        {
            Quanlyphong qlphong = new Quanlyphong(account);
            qlphong.Show();
            this.Close();
        }

        private void btnQuanLyLoaiPhong_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Quản lý loại phòng");
        }

        private void BtnThuePhong_Click(object sender, RoutedEventArgs e)
        {
            ThuePhong thuePhong = new ThuePhong();
            thuePhong.Show();
            this.Close();
        }

        private void btnKhachHang_Click(object sender, RoutedEventArgs e)
        {
            Quanlykhachhang khachhang = new Quanlykhachhang(account);
            khachhang.Show();
            this.Hide();
        }

        private void btnDichVu_Click(object sender, RoutedEventArgs e)
        {
            Quanlydichvu dichvu = new Quanlydichvu(account);
            dichvu.Show();
            this.Hide();
        }

        private void btnDangXuat_Click(object sender, RoutedEventArgs e)
        {
            DangNhap dangnhap = new DangNhap();
            dangnhap.Show();
            this.Hide();
        }
        public Trangchu()
        {
            InitializeComponent();
        }

        public Trangchu(string account)
        {
            InitializeComponent();
            //this.name = name;
            this.account = account;
            string name = NguoiDungDAO.GetHoTenByUser(account);
            LabelName.Content = name;
        }
    }
}
