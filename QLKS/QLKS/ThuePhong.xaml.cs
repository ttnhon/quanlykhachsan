using QLKS.DAO;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLKS
{
    /// <summary>
    /// Interaction logic for ThuePhong.xaml
    /// </summary>
    public partial class ThuePhong : Window
    {
        
        class ButtonContent
        {
            public int MaPhong;
            public string LoaiPhong;
            public string TinhTrang;
            public string TrangThai;
        }
        DataTable tablePhong;
        public ThuePhong()
        {
            InitializeComponent();
            LoadPhong();
        }

        private void LoadPhong()
        {
            int soLuongPhong = PhongDAO.GetSoLuongPhongSuDung();
            tablePhong = PhongDAO.LoadPhongSuDung();
            for(int i=0;i<soLuongPhong;i++)
            {
                ButtonContent btnContent = new ButtonContent()
                {
                    MaPhong = tablePhong.Rows[i].Field<int>(0),
                    LoaiPhong = tablePhong.Rows[i].Field<string>(1),
                    TinhTrang = tablePhong.Rows[i].Field<string>(2),
                    TrangThai = tablePhong.Rows[i].Field<string>(3)
                };
                Button myBtn = new Button()
                {
                    Name = "_"+btnContent.MaPhong.ToString(),
                    Content = BuildButtonContent(btnContent),
                    Background = new SolidColorBrush(GetButtonColor(btnContent.TinhTrang, btnContent.TrangThai)),
                    Foreground = new SolidColorBrush(Colors.White),
                    Height = 100,
                    Width = 120,
                };
                RoutedEventHandler a = new RoutedEventHandler(Button_Click);
                myBtn.Click += a;
                wrapPanel.Children.Add(myBtn);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            ContextMenu cm = this.FindResource("cmButton") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.IsOpen = true;
            MenuItem thuephong = LogicalTreeHelper.FindLogicalNode(cm, "thuephong") as MenuItem;
            MenuItem thongtinkhach = LogicalTreeHelper.FindLogicalNode(cm, "thongtinkhach") as MenuItem;
            MenuItem capnhatdichvu = LogicalTreeHelper.FindLogicalNode(cm, "capnhatdichvu") as MenuItem;
            MenuItem doiphong = LogicalTreeHelper.FindLogicalNode(cm, "doiphong") as MenuItem;
            MenuItem khachrangoai = LogicalTreeHelper.FindLogicalNode(cm, "khachrangoai") as MenuItem;
            MenuItem datphong = LogicalTreeHelper.FindLogicalNode(cm, "datphong") as MenuItem;
            MenuItem donphong = LogicalTreeHelper.FindLogicalNode(cm, "donphong") as MenuItem;
            MenuItem suaphong = LogicalTreeHelper.FindLogicalNode(cm, "suaphong") as MenuItem;

            int maPhong = Int32.Parse(button.Name.Substring(1));

            int tinhTrang = PhongDAO.GetTinhTrangPhong(maPhong);
            int trangThai = PhongDAO.GetTrangThaiPhong(maPhong);

            if(trangThai == 3 || trangThai == 4)
            {
                thuephong.IsEnabled = false;
                thongtinkhach.IsEnabled = false;
                capnhatdichvu.IsEnabled = false;
                doiphong.IsEnabled = false;
                khachrangoai.IsEnabled = false;
                datphong.IsEnabled = false;
                if(trangThai==3)
                {
                    suaphong.IsEnabled = false;
                    donphong.Header = "Kết thúc dọn phòng";
                    suaphong.Header = "Sửa phòng";
                    donphong.IsEnabled = true;
                }
                else
                {
                    donphong.IsEnabled = false;
                    suaphong.IsEnabled = true;
                    donphong.Header = "Dọn phòng";
                    suaphong.Header = "Kết thúc sửa phòng";
                }
                return;
            }
            if(tinhTrang == 1)
            {
                thuephong.IsEnabled = true;
                thongtinkhach.IsEnabled = false;
                capnhatdichvu.IsEnabled = false;
                doiphong.IsEnabled = false;
                khachrangoai.IsEnabled = false;
                datphong.IsEnabled = true;
                donphong.IsEnabled = true;
                suaphong.IsEnabled = true;
                donphong.Header = "Dọn phòng";
                suaphong.Header = "Sửa phòng";
                return;
            }
        }
        //Con trong: green
        //Dang thue/khach trong phong: red
        //Khach ra ngoai: purple
        //Dang don dep: gray
        //Dang sua chua: darkblue
        Color GetButtonColor(string tinhTrang, string trangThai)
        {
            if (tinhTrang.Equals("Còn trống") && !trangThai.Equals("Đang dọn dẹp") && !trangThai.Equals("Đang sửa chữa"))
                return Colors.Green;
            if (trangThai.Equals("Đang dọn dẹp"))
                return Colors.Gray;
            if (trangThai.Equals("Đang sửa chữa"))
                return Colors.DarkBlue;
            if (tinhTrang.Equals("Đặt trước"))
                return Colors.Yellow;
            if (tinhTrang.Equals("Đang thuê") && trangThai.Equals("Khách trong phòng"))
                return Colors.Red;
            if (trangThai.Equals("Khách ra ngoài"))
                return Colors.Purple;
            return Colors.White;
        }
        string BuildButtonContent(ButtonContent btnContent)
        {
            return "Phòng " + btnContent.MaPhong + "\n" + btnContent.LoaiPhong +
                "\n" + btnContent.TinhTrang + "\n" + btnContent.TrangThai;
        }

        private void MenuDonPhong_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mnu = sender as MenuItem;
            ContextMenu menu = (ContextMenu)mnu.Parent;
            Button button = menu.PlacementTarget as Button;
            int maPhong = Int32.Parse(button.Name.Substring(1));
            int tinhtrang = PhongDAO.GetTinhTrangPhong(maPhong);
            int trangthai = PhongDAO.GetTrangThaiPhong(maPhong);

            if(trangthai==3)
            {
                if (tinhtrang == 1 || tinhtrang == 4)
                    PhongDAO.SetTrangThaiPhong(maPhong, 5);
                if(tinhtrang == 2)
                    PhongDAO.SetTrangThaiPhong(maPhong, 2);
            }
            else
            {
                PhongDAO.SetTrangThaiPhong(maPhong, 3);
            }
            wrapPanel.Children.Clear();
            LoadPhong();
        }

        private void MenuSuaPhong_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mnu = sender as MenuItem;
            ContextMenu menu = (ContextMenu)mnu.Parent;
            Button button = menu.PlacementTarget as Button;
            int maPhong = Int32.Parse(button.Name.Substring(1));
            int tinhtrang = PhongDAO.GetTinhTrangPhong(maPhong);
            int trangthai = PhongDAO.GetTrangThaiPhong(maPhong);

            if (trangthai == 4)
            {
                if (tinhtrang == 1 || tinhtrang == 4)
                    PhongDAO.SetTrangThaiPhong(maPhong, 5);
                if (tinhtrang == 2)
                    PhongDAO.SetTrangThaiPhong(maPhong, 2);
            }
            else
            {
                PhongDAO.SetTrangThaiPhong(maPhong, 4);
            }
            wrapPanel.Children.Clear();
            LoadPhong();
        }
    }
}
