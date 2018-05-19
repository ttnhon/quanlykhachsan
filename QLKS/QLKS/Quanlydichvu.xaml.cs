using QLKS.DAO;
using QLKS.DTO;
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
    /// Interaction logic for Quanlydichvu.xaml
    /// </summary>
    public partial class Quanlydichvu : Window
    {
        public Quanlydichvu()
        {
            InitializeComponent();
            LoadDanhSach();
        }
        private void LoadDanhSach()
        {
            dgDanhSach.ItemsSource = DichVuDAO.LoadAll().DefaultView;
            KhongChoPhepChinhSua();
        }
        //Mở cho phép chỉnh sửa (thêm, sửa)
        private void ChoPhepChinhSua()
        {
            txtMaDV.IsEnabled = true;
            txtTenDV.IsEnabled = true;
            txtGhiChu.IsEnabled = true;
            txtDonGia.IsEnabled = true;
            cbcKhaDung.IsEnabled = true;
            btnApplySua.IsEnabled = true;
            btnApplyThem.IsEnabled = true;
        }
        //Không cho phép chỉnh sửa (thêm, sửa)
        private void KhongChoPhepChinhSua()
        {
            txtMaDV.IsEnabled = false;
            txtTenDV.IsEnabled = false;
            txtGhiChu.IsEnabled = false;
            txtDonGia.IsEnabled = false;
            cbcKhaDung.IsEnabled = false;
            btnApplySua.IsEnabled = false;
            btnApplyThem.IsEnabled = false;
        }
        private void btn_TrangChu_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thực thi nút Trang chủ!");
        }
        private void btn_Them_Click(object sender, RoutedEventArgs e)
        {
            ChoPhepChinhSua();
            txtMaDV.Text = "";
            txtMaDV.IsEnabled = false;
            cbcKhaDung.IsEnabled = false;
            btnApplySua.IsEnabled = false;
        }
        private void btn_Sua_Click(object sender, RoutedEventArgs e)
        {
            if (txtMaDV.Text == "")
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để sửa!");
                return;
            }
            ChoPhepChinhSua();
            txtMaDV.IsEnabled = false;
            btnApplyThem.IsEnabled = false;
        }
        private void btn_CapNhat_Click(object sender, RoutedEventArgs e)
        {
            LoadDanhSach();
            MessageBox.Show("Cập nhật danh sách thành công!");
        }
        private void btn_TimKiem_Click(object sender, RoutedEventArgs e)
        {
            if (txtTimKiem.Text.Equals(""))
            {
                MessageBox.Show("Xin vui lòng nhập mã phòng muốn tìm!");
                return;
            }
            int MaDV;
            try
            {
                MaDV = int.Parse(txtTimKiem.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Mã dịch vụ phải là số");
                return;
            }

            DichVu kh = DichVuDAO.LoadOne(MaDV);

            if (kh != null)
            {
                txtMaDV.Text = kh.MaDV.ToString();
                txtTenDV.Text = kh.TenDV;
                txtGhiChu.Text = kh.GhiChu;
                txtDonGia.Text = kh.DonGia.ToString();
                int KhaDung = -1;
                KhaDung = kh.ConSuDung;
                if (KhaDung==1)
                {
                    cbcKhaDung.SelectedValue = "Có";
                }
                else
                {
                    cbcKhaDung.SelectedValue = "Không";
                }
            }
            else
                MessageBox.Show("Không tìm thấy dịch vụ với mã đã nhập!");
            KhongChoPhepChinhSua();
        }

        private void btnApplyThem_Click(object sender, RoutedEventArgs e)
        {
            string tendv = txtTenDV.Text;
            int dongia;
            try
            {
                dongia = int.Parse(txtDonGia.Text);
            }catch(Exception)
            {
                MessageBox.Show("Đơn giá phải là số!\nVui lòng nhập lại...");
                return;
            }
            string ghichu = txtGhiChu.Text;
            
            //int khadung = 0;
            //if (cbcKhaDung.SelectedValue.ToString() == "Có")
            //{
            //    khadung = 1;
            //}
            //else
            //{
            //    khadung = 0;
            //}

            if (tendv.Equals(""))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }
            DichVu dv = new DichVu(-100, tendv, dongia, ghichu, 1);
            int check = DichVuDAO.Insert(dv);
            if (check != -1)
            {
                MessageBox.Show("Thêm mới dịch vụ thành công!");
            }
            else
            {
                MessageBox.Show("Thêm mới dịch vụ không thành công!");
            }
            LoadDanhSach();
        }

        private void btnApplySua_Click(object sender, RoutedEventArgs e)
        {
            int madv = int.Parse(txtMaDV.Text);
            string tendv = txtTenDV.Text;
            int dongia;
            try
            {
                dongia = int.Parse(txtDonGia.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Đơn giá phải là số!\nVui lòng nhập lại...");
                return;
            }
            string ghichu = txtGhiChu.Text;

            int khadung = 0;
            if (cbcKhaDung.SelectedValue.ToString() == "Có")
            {
                khadung = 1;
            }
            else
            {
                khadung = 0;
            }

            if (tendv.Equals(""))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }
            DichVu dv = new DichVu(madv, tendv, dongia, ghichu, khadung);
            int check = DichVuDAO.Update(dv);
            if (check != -1)
            {
                MessageBox.Show("Sửa thông tin dịch vụ thành công!");
            }
            else
            {
                MessageBox.Show("Sửa thông tin dịch vụ không thành công!");
            }
            LoadDanhSach();
        }
    }
}
