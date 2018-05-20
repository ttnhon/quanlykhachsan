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
    /// Interaction logic for DoiPhong.xaml
    /// </summary>
    public partial class DoiPhong : Window
    {
        int MaPhong;
        public DoiPhong(int maPhong)
        {
            InitializeComponent();

            MaPhong = maPhong;
            txtPhongHienTai.Text = maPhong.ToString();

            cbbPhongMoi.ItemsSource = PhongDAO.LoadPhongConTrong().DefaultView;
        }

        private void BtnDoiPhong_Click(object sender, RoutedEventArgs e)
        {
            if(cbbPhongMoi.Text.Equals(""))
            {
                MessageBox.Show("Hãy chọn Phòng mới", "Thông báo");
                return;
            }
            if (MessageBox.Show("Xác nhận đổi phòng?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            int phongCu = Int32.Parse(txtPhongHienTai.Text);
            int phongMoi = Int32.Parse(cbbPhongMoi.Text);
            PhongDAO.SetTinhTrangPhong(phongCu, 1);
            PhongDAO.SetTrangThaiPhong(phongCu, 5);
            PhongDAO.SetTinhTrangPhong(phongMoi, 2);
            PhongDAO.SetTrangThaiPhong(phongMoi, 1);
            ThuePhongDAO.SuaMaPhong(phongCu, phongMoi);
            MessageBox.Show("Đổi phòng thành công!\r\nHãy bấm Cập nhật để tải lại danh sách phòng!", "Thông báo");
            this.Close();
            //đặt phòng cũ về tình trạng còn trống, trạng thái khác
            //đặt phòng mới về tình trạng đang thuê, trạng thái khách trong phòng
            //đổi mã phòng trong bảng thuê phòng từ phòng cũ sang phòng mới
        }
    }
}
