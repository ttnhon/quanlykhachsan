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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace QLKS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataTable table = LoaiPhongDAO.LoadAll();
            //dataGrid.ItemsSource = table.DefaultView;
            DataTable table = DichVuDAO.LoadAll();
            dataGrid.ItemsSource = table.DefaultView;

            DichVu dv = DichVuDAO.LoadOne(3);
            txtbox.Text = dv.DonGia.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //LoaiPhong lp = new LoaiPhong("c", "test", "abcd", 3, 4, 1);
            //txtbox.Text = LoaiPhongDAO.Undrop("c").ToString();
            DichVu dv = new DichVu(7, "test", 111, "abcd", 1);
            txtbox.Text = DichVuDAO.Undrop(7).ToString();

            //DataTable table = LoaiPhongDAO.LoadAll();
            //dataGrid.ItemsSource = table.DefaultView;
            DataTable table = DichVuDAO.LoadAll();
            dataGrid.ItemsSource = table.DefaultView;

            DangNhap dangnhap = new DangNhap();
            dangnhap.Show();
            //DataTable table = LoaiPhongDAO.LoadAll();
            //dataGrid.ItemsSource = table.DefaultView;
        }
    }
}
