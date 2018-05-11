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
            DataTable table = LoaiPhongDAO.LoadAll();
            dataGrid.ItemsSource = table.DefaultView;

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoaiPhong lp = new LoaiPhong("c", "test", "test", 1, 2);
            txtbox.Text = LoaiPhongDAO.Insert(lp).ToString();

            DataTable table = LoaiPhongDAO.LoadAll();
            dataGrid.ItemsSource = table.DefaultView;
        }
    }
}
