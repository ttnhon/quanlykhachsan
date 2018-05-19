using QLKS.DAO;
using QLKS.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        public DangNhap()
        {
            InitializeComponent();
            ThuePhong a = new ThuePhong();
            a.Show();
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string UserName = inputUsername.Text;
            string Password = inputPassword.Password.ToString();
            //Password = HashPassword.hash(Password);
            //bool check = NguoiDungDAO.CheckTaiKhoan(UserName, Password);
            string GetPassword = NguoiDungDAO.GetMatKhauByUser(UserName);

            if (!Password.Equals(GetPassword))
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!\nVui lòng nhập lại...");
            }
            else
            //MessageBox.Show("Đăng nhập thành công!");
            {
                //string HoTen = NguoiDungDAO.GetHoTenByUser(UserName);

                Trangchu tc = new Trangchu(UserName);
                //Trangchu tc = new Trangchu();
                tc.Show();
                this.Close();
            }
        }
    }
}
