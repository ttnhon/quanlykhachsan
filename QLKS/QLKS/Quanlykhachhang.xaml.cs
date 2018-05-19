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
    /// Interaction logic for Quanlykhachhang.xaml
    /// </summary>
    public partial class Quanlykhachhang : Window
    {
        string account;
        public Quanlykhachhang(string account)
        {
            InitializeComponent();
            this.account = account;
            LoadDanhSach();
        }
        //Mở cho phép chỉnh sửa (thêm, sửa)
        private void ChoPhepChinhSua()
        {
            //txtMa.IsEnabled = true;
            txtHoTen.IsEnabled = true;
            txtCMND.IsEnabled = true;
            txtDiaChi.IsEnabled = true;
            txtSDT.IsEnabled = true;
            txtMaPhong.IsEnabled = true;
            cbcLoai.IsEnabled = true;
            //cbcLoai.SelectedValue = "Thường";
        }
        //Không cho phép chỉnh sửa (thêm, sửa)
        private void KhongChoPhepChinhSua()
        {
            txtMa.IsEnabled = false;
            txtHoTen.IsEnabled = false;
            txtCMND.IsEnabled = false;
            txtDiaChi.IsEnabled = false;
            txtSDT.IsEnabled = false;
            txtMaPhong.IsEnabled = false;
            cbcLoai.IsEnabled = false;
            btnApplySua.IsEnabled = false;
            btnApplyThem.IsEnabled = false;
        }
        //Trở về trang chủ (xong)
        private void Button_TrangChu(object sender, RoutedEventArgs e)
        {
            Trangchu tc = new Trangchu(account);
            tc.Show();
            this.Hide();
            //MessageBox.Show("Button Trangchu");
        }

        //Cho phép thêm khách hàng mới
        private void Button_Them(object sender, RoutedEventArgs e)
        {

            ChoPhepChinhSua();
            
            txtMa.Text = "";
            txtHoTen.Text = "";
            txtCMND.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            cbcLoai.SelectedValue = "Nội địa";
            txtMaPhong.IsEnabled = false;
            btnApplySua.IsEnabled = false;
            btnApplyThem.IsEnabled = true;
        }
        //Cho phép sửa thông tin khách hàng
        private void Button_Sua(object sender, RoutedEventArgs e)
        {
            if(txtMa.Text =="")
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa!");
                return;
            }
            ChoPhepChinhSua();
            txtMa.IsEnabled = false;
            btnApplyThem.IsEnabled = false;
            btnApplySua.IsEnabled = true;
        }

        private void Button_Xoa(object sender, RoutedEventArgs e)
        {

        }
        //Cập nhật lại danh sách khách hàng
        private void Button_CapNhat(object sender, RoutedEventArgs e)
        {
            LoadDanhSach();
            MessageBox.Show("Cập nhật danh sách thành công.");
        }

        //Tìm kiếm theo mã khách hàng
        private void Button_TimKiem(object sender, RoutedEventArgs e)
        {
            if (txtTimKiem.Text.Equals(""))
            {
                MessageBox.Show("Xin vui lòng nhập mã!");
                return;
            }
            int MaKH;
            try
            {
                MaKH = int.Parse(txtTimKiem.Text);
            }catch(Exception)
            {
                MessageBox.Show("Mã khách hàng phải là số");
                return;
            }
            KhachHang kh = KhachHangDAO.LoadOne(MaKH);

            if (kh != null)
            {
                txtMa.Text = kh.MaKhach.ToString();
                txtHoTen.Text = kh.TenKhach;
                txtCMND.Text = kh.SoCMND;
                txtDiaChi.Text = kh.DiaChi;
                txtSDT.Text = kh.DienThoai;
                int MaPhong = DatPhongDAO.GetMaPhong(kh.MaKhach);
                if(MaPhong==0)
                {
                    txtMaPhong.Text = "Chưa đặt phòng";
                }
                else
                {
                    txtMaPhong.Text = MaPhong.ToString();
                }
                if (kh.LoaiKhach == 1)
                {
                    cbcLoai.SelectedValue = "Nội địa";
                }
                else
                {
                    cbcLoai.SelectedValue = "Nước ngoài";
                }
            }
            else
                MessageBox.Show("Không tìm thấy khách hàng với mã đã nhập!");
            KhongChoPhepChinhSua();
        }
        //Load danh sách cho GridView (Xong)
        private void LoadDanhSach()
        {
            dgDanhSach.ItemsSource = KhachHangDAO.LoadAll().DefaultView;
        }
        //Click xác nhận thêm khách hàng mới
        private void btnApplyThem_Click(object sender, RoutedEventArgs e)
        {
            //string makhach = "1";
            string hoten = txtHoTen.Text;
            string cmnd = txtCMND.Text;
            string diachi = txtDiaChi.Text;
            string dienthoai = txtSDT.Text;
            int loaikhach = 0;
            if(cbcLoai.SelectedValue.ToString() == "Nội địa")
            {
                loaikhach = 1;
            }
            else
            {
                loaikhach = 2;
            }

            if(hoten.Equals("") || cmnd.Equals("")||diachi.Equals("")||dienthoai.Equals(""))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }
            KhachHang kh = new KhachHang(-100, hoten, cmnd, diachi, dienthoai, loaikhach);
            int check = KhachHangDAO.Insert(kh);
            if(check != -1)
            {
                MessageBox.Show("Thêm mới khách hàng thành công!");
            }
            else
            {
                MessageBox.Show("Thêm mới khách hàng không thành công!");
            }
            LoadDanhSach();
        }
        //xong
        private void btnApplySua_Click(object sender, RoutedEventArgs e)
        {
            int makhach = int.Parse(txtMa.Text);
            string hoten = txtHoTen.Text;
            string cmnd = txtCMND.Text;
            string diachi = txtDiaChi.Text;
            string dienthoai = txtSDT.Text;
            int loaikhach = 0;
            if (cbcLoai.SelectedValue.ToString() == "Nội địa")
            {
                loaikhach = 1;
            }
            else
            {
                loaikhach = 2;
            }

            if (hoten.Equals("") || cmnd.Equals("") || diachi.Equals("") || dienthoai.Equals(""))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }
            KhachHang kh = new KhachHang(makhach, hoten, cmnd, diachi, dienthoai, loaikhach);
            int check = KhachHangDAO.Update(kh);
            if (check != -1)
            {
                MessageBox.Show("Sửa thông tin khách hàng thành công!");
            }
            else
            {
                MessageBox.Show("Sửa thông tin khách hàng không thành công!");
            }
            LoadDanhSach();
        }

        
    }
}
