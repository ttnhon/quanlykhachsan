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
    /// Interaction logic for Quanlyloaiphong.xaml
    /// </summary>
    public partial class Quanlyloaiphong : Window
    {
        string account;
        public Quanlyloaiphong(string account)
        {
            InitializeComponent();
            this.account = account;
            LoadDanhSach();
        }
        private void LoadDanhSach()
        {
            dgDanhSach.ItemsSource = LoaiPhongDAO.LoadAll().DefaultView;
            KhongChoPhepChinhSua();
        }
        private void LoadChiTiet1Phong(string maphong)
        {
            LoaiPhong lp = LoaiPhongDAO.LoadOne(maphong);
            if(lp != null)
            {
                txtMa.Text = lp.MaLoai;
                txtTen.Text = lp.TenLoai;
                txtMoTa.Text = lp.MoTa;
                txtDonGia.Text = lp.DonGia.ToString();
                txtSNTD.Text = lp.SoNguoiToiDa.ToString();
                if(lp.ConSuDung==1)
                {
                    cbcKhaDung.SelectedValue = "Có";
                }
                else
                {
                    cbcKhaDung.SelectedValue = "Không";
                }
                KhongChoPhepChinhSua();
            }
            else
            {
                MessageBox.Show("Không tìm thấy phòng!");
            }
        }
        private void ChoPhepChinhSua()
        {
            txtMa.IsEnabled = true;
            txtTen.IsEnabled = true;
            txtMoTa.IsEnabled = true;
            txtDonGia.IsEnabled = true;
            txtSNTD.IsEnabled = true;
            cbcKhaDung.IsEnabled = true;
            btnApplySua.IsEnabled = true;
            btnApplyThem.IsEnabled = true;
        }

        private void KhongChoPhepChinhSua()
        {
            txtMa.IsEnabled = false;
            txtTen.IsEnabled = false;
            txtMoTa.IsEnabled = false;
            txtDonGia.IsEnabled = false;
            txtSNTD.IsEnabled = false;
            cbcKhaDung.IsEnabled = false;
            btnApplySua.IsEnabled = false;
            btnApplyThem.IsEnabled = false;
        }

        private void btnTrangChu_Click(object sender, RoutedEventArgs e)
        {
            Trangchu tc = new Trangchu(account);
            tc.Show();
            this.Hide();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            ChoPhepChinhSua();
            btnApplySua.IsEnabled = false;
            txtMa.Text = "";
            txtTen.Text = "";
            txtMoTa.Text = "";
            txtDonGia.Text = "";
            txtSNTD.Text = "";
            cbcKhaDung.SelectedValue = "Có";
            cbcKhaDung.IsEnabled = false;
        }

        
        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            LoadDanhSach();
            MessageBox.Show("Cập nhật danh sách thành công!");
        }

        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            if (txtTimKiem.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập mã loại phòng muốn tìm!");
                return;
            }
            else
            {
                LoadChiTiet1Phong(txtTimKiem.Text);
            }
        }
        private void dgDanhSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView rowview = dgDanhSach.SelectedItem as DataRowView;
                if (rowview != null)
                {
                    string maloai = rowview.Row["MaLoai"].ToString();
                    LoadChiTiet1Phong(maloai);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (txtMa.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng chọn loại phòng muốn sửa!");
                return;
            }

            ChoPhepChinhSua();
            btnApplyThem.IsEnabled = false;
            txtMa.IsEnabled = false;
        }

        private void btnApplySua_Click(object sender, RoutedEventArgs e)
        {
            string maloai = txtMa.Text;
            string tenloai = txtTen.Text;
            string mota = txtMoTa.Text;
            float dongia = -100;
            try
            {
                dongia = float.Parse(txtDonGia.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Đơn giá phải là số!\nVui lòng nhập lại...");
                return;
            }

            int songuoitoida = -100;
            try
            {
                songuoitoida = int.Parse(txtSNTD.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Số người tối đa phải là số!\nVui lòng nhập lại...");
                return;
            }
            
            int khadung = 0;
            if (cbcKhaDung.SelectedValue.ToString() == "Có")
            {
                khadung = 1;
            }
            else
            {
                khadung = 0;
            }

            //Kiểm tra để trống thông tin
            if (tenloai.Equals("")|| mota.Equals(""))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            //Kiểm tra đơn giá =<0
            if(dongia<=0)
            {
                MessageBox.Show("Đơn giá phải dương");
                return;
            }
            //Kiểm tra số người tối đa =<0
            if (songuoitoida <= 0)
            {
                MessageBox.Show("Số người tối đa phải dương");
                return;
            }
            LoaiPhong lp = new LoaiPhong(maloai, tenloai, mota, dongia, songuoitoida, khadung);
            int check = LoaiPhongDAO.Update(lp);
            if(check ==0)
            {
                MessageBox.Show("Loại phòng không tồn tại");
                return;
            }
            if (check != -1)
            {
                MessageBox.Show("Sửa thông tin loại phòng thành công!");
            }
            else
            {
                MessageBox.Show("Sửa thông tin loại phòng không thành công!");
            }
            LoadDanhSach();
        }

        private void btnApplyThem_Click(object sender, RoutedEventArgs e)
        {
            string maloai = txtMa.Text;
            string tenloai = txtTen.Text;
            string mota = txtMoTa.Text;
            float dongia = -100;
            try
            {
                dongia = float.Parse(txtDonGia.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Đơn giá phải là số!\nVui lòng nhập lại...");
                return;
            }

            int songuoitoida = -100;
            try
            {
                songuoitoida = int.Parse(txtSNTD.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Số người tối đa phải là số!\nVui lòng nhập lại...");
                return;
            }

            int khadung = 0;
            if (cbcKhaDung.SelectedValue.ToString() == "Có")
            {
                khadung = 1;
            }
            else
            {
                khadung = 0;
            }

            //Kiểm tra để trống thông tin
            if (maloai.Equals("") || tenloai.Equals("") || mota.Equals(""))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            //Kiểm tra đơn giá =<0
            if (dongia <= 0)
            {
                MessageBox.Show("Đơn giá phải dương");
                return;
            }
            //Kiểm tra số người tối đa =<0
            if (songuoitoida <= 0)
            {
                MessageBox.Show("Số người tối đa phải dương");
                return;
            }
            LoaiPhong lp = new LoaiPhong(maloai, tenloai, mota, dongia, songuoitoida, khadung);
            int check = LoaiPhongDAO.Insert(lp);
            if (check == 0)
            {
                MessageBox.Show("Loại phòng đã có trong danh sách!");
                return;
            }
            if (check != -1)
            {
                MessageBox.Show("Thêm thông tin loại phòng thành công!");
            }
            else
            {
                MessageBox.Show("Thêm thông tin loại phòng không thành công!");
            }
            LoadDanhSach();
        }
    }
}
