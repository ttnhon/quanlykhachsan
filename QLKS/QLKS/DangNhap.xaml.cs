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
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string username = inputUsername.Text;
            string get_password = inputPassword.Password.ToString();
            string password = App.hashPassword(get_password);
            SqlConnection cnn = new SqlConnection(App.sConnB.ConnectionString);

            string sql = "select * from NguoiDung where TenDangNhap = '" + username + "' and MatKhau = '" + password + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            if (table.Rows.Count < 1)
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!\nVui lòng nhập lại...");
            }
            else
            //MessageBox.Show("Đăng nhập thành công!");
            {
                string fullname = table.Rows[0][1].ToString();
                string useraccount = table.Rows[0][3].ToString();

                //MessageBox.Show("useraccount: " + useraccount + "\n fullname: " + fullname);
                Trangchu tc = new Trangchu(fullname, useraccount);
                tc.Show();
                this.Hide();
            }
        }
    }
}
