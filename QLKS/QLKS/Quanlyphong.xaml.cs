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
    /// Interaction logic for Quanlyphong.xaml
    /// </summary>
    public partial class Quanlyphong : Window
    {
        string account;
        public Quanlyphong(string id)
        {
            InitializeComponent();
            account = id;
            grid_phong.ItemsSource = PhongDAO.LoadAll().DefaultView;
            cb_tinhtrang.ItemsSource = TinhTrangDAO.LoadAll().DefaultView;
            cb_trangthai.ItemsSource = TrangThaiDAO.LoadAll().DefaultView;
            cb_loaiphong.ItemsSource = LoaiPhongDAO.LoadAll().DefaultView;
        }

        public void EnableText()
        {
            cb_loaiphong.IsEnabled = true;
            cb_tinhtrang.IsEnabled = true;
            cb_trangthai.IsEnabled = true;
            txt_ghichu.IsEnabled = true;
        }

        public void UnenableText()
        {
            cb_loaiphong.IsEnabled = false;
            cb_tinhtrang.IsEnabled = false;
            cb_trangthai.IsEnabled = false;
            txt_ghichu.IsEnabled = false;
        }

        public void EmptyText()
        {
            txt_ghichu.Text = "";
        }

        private void btn_Them_Click(object sender, RoutedEventArgs e)
        {
            EmptyText();
            EnableText();
            txt_maphong.IsEnabled = true;
            btn_ThemConfirm.Visibility = Visibility.Visible;
            btn_Them.IsEnabled = false;
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            Trangchu tc = new Trangchu(NguoiDungDAO.GetHoTenByUser(account), account);
            tc.Show();
            this.Hide();
        }
    }
}
