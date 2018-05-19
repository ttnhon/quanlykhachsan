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
            txt_maphong.IsEnabled = false;
            cb_loaiphong.IsEnabled = false;
            cb_tinhtrang.IsEnabled = false;
            cb_trangthai.IsEnabled = false;
            txt_ghichu.IsEnabled = false;
        }

        public void EmptyText()
        {
            txt_maphong.Text = "";
            txt_ghichu.Text = "";
        }

        private void btn_Them_Click(object sender, RoutedEventArgs e)
        {
            EmptyText();
            EnableText();
            txt_maphong.IsEnabled = true;
            btn_ThemConfirm.Visibility = Visibility.Visible;
            btn_Huy.Visibility = Visibility.Visible;
            btn_Them.IsEnabled = false;
            if(btn_Capnhat.IsEnabled == false)
            {
                btn_Capnhat.IsEnabled = true;
                btn_CapnhatConfirm.Visibility = Visibility.Hidden;
            }
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            Trangchu tc = new Trangchu(account);
            tc.Show();
            this.Close();
        }

        private void btn_ThemConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Phong p = new Phong();
                DataRowView rowview_lp = cb_loaiphong.SelectedItem as DataRowView;
                DataRowView rowview_tt = cb_tinhtrang.SelectedItem as DataRowView;
                DataRowView rowview_tth = cb_trangthai.SelectedItem as DataRowView;
                p.MaPhong = Int32.Parse(txt_maphong.Text);
                p.LoaiPhong = rowview_lp["MaLoai"].ToString();
                p.TinhTrang = Int32.Parse(rowview_tt["MaTT"].ToString());
                p.TrangThai = Int32.Parse(rowview_tth["MaTT"].ToString());
                p.GhiChu = txt_ghichu.Text;
                MessageBoxResult kq = MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButton.YesNo);
                if(kq == MessageBoxResult.Yes)
                {
                    PhongDAO.Insert(p);
                    MessageBox.Show("Thêm thành công", "Thành công");
                    EmptyText();
                    UnenableText();
                    btn_Them.IsEnabled = true;
                    btn_ThemConfirm.Visibility = Visibility.Hidden;
                    btn_Huy.Visibility = Visibility.Hidden;
                    grid_phong.ItemsSource = PhongDAO.LoadAll().DefaultView;
                }
                else
                {
                    EmptyText();
                    UnenableText();
                    btn_Them.IsEnabled = true;
                    btn_ThemConfirm.Visibility = Visibility.Hidden;
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btn_Xoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Phong p = new Phong();
                DataRowView rowview = grid_phong.SelectedItem as DataRowView;
                p.MaPhong = Int32.Parse(rowview.Row["MaPhong"].ToString());
                MessageBoxResult kq = MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButton.YesNo);
                grid_phong.UnselectAll();
                if (kq == MessageBoxResult.Yes)
                {
                    PhongDAO.Delete(p);
                    MessageBox.Show("Xóa thành công", "Thành công");
                    grid_phong.ItemsSource = PhongDAO.LoadAll().DefaultView;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void grid_phong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (btn_Them.IsEnabled == false)
                {
                    btn_Them.IsEnabled = true;
                    btn_ThemConfirm.Visibility = Visibility.Hidden;
                    UnenableText();
                }
                Phong p = new Phong();
                DataRowView rowview = grid_phong.SelectedItem as DataRowView;
                if (rowview != null)
                {
                    int maphong = Int32.Parse(rowview.Row["MaPhong"].ToString());
                    p = PhongDAO.LoadOne(maphong);
                    txt_maphong.Text = p.MaPhong.ToString();
                    for (int i = 0; i < cb_loaiphong.Items.Count; i++)
                    {
                        DataRowView rowcbview = cb_loaiphong.Items[i] as DataRowView;
                        if (rowcbview["MaLoai"].ToString().Equals(p.LoaiPhong))
                        {
                            cb_loaiphong.SelectedIndex = i;
                        }
                    }
                    cb_tinhtrang.SelectedIndex = p.TinhTrang - 1;
                    cb_trangthai.SelectedIndex = p.TrangThai - 1;
                    txt_ghichu.Text = p.GhiChu;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void btn_Capnhat_Click(object sender, RoutedEventArgs e)
        {
            if (txt_maphong.Text == "")
                return;
            EnableText();
            btn_Capnhat.IsEnabled = false;
            btn_CapnhatConfirm.Visibility = Visibility.Visible;
            btn_Huy.Visibility = Visibility.Visible;
            if (btn_Them.IsEnabled == false)
            {
                btn_Them.IsEnabled = true;
                btn_ThemConfirm.Visibility = Visibility.Hidden;
            }
        }

        private void btn_CapnhatConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Phong p = new Phong();
                DataRowView rowview_lp = cb_loaiphong.SelectedItem as DataRowView;
                DataRowView rowview_tt = cb_tinhtrang.SelectedItem as DataRowView;
                DataRowView rowview_tth = cb_trangthai.SelectedItem as DataRowView;
                p.MaPhong = Int32.Parse(txt_maphong.Text);
                p.LoaiPhong = rowview_lp["MaLoai"].ToString();
                p.TinhTrang = Int32.Parse(rowview_tt["MaTT"].ToString());
                p.TrangThai = Int32.Parse(rowview_tth["MaTT"].ToString());
                p.GhiChu = txt_ghichu.Text;
                MessageBoxResult kq = MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButton.YesNo);
                if (kq == MessageBoxResult.Yes)
                {
                    PhongDAO.Update(p);
                    MessageBox.Show("Cập nhật thành công", "Thành công");
                    EmptyText();
                    UnenableText();
                    btn_Capnhat.IsEnabled = true;
                    btn_CapnhatConfirm.Visibility = Visibility.Hidden;
                    btn_Huy.Visibility = Visibility.Hidden;
                    grid_phong.ItemsSource = PhongDAO.LoadAll().DefaultView;
                }
                else
                {
                    EmptyText();
                    UnenableText();
                    btn_Capnhat.IsEnabled = true;
                    btn_CapnhatConfirm.Visibility = Visibility.Hidden;
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btn_Huy_Click(object sender, RoutedEventArgs e)
        {
            if(btn_Them.IsEnabled==false)
            {
                btn_Them.IsEnabled = true;
                btn_ThemConfirm.Visibility = Visibility.Hidden;
            }
            if (btn_Capnhat.IsEnabled == false)
            {
                btn_Capnhat.IsEnabled = true;
                btn_CapnhatConfirm.Visibility = Visibility.Hidden;
            }
            EmptyText();
            UnenableText();
            btn_Huy.Visibility = Visibility.Hidden;
        }
    }
}
