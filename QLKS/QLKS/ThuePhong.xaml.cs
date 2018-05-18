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
            if(button != null)
               MessageBox.Show(button.Name);
        }
        //Con trong: green
        //Dang thue/khach trong phong: red
        //Khach ra ngoai: purple
        //Dang don dep: gray
        //Dang sua chua: darkblue
        Color GetButtonColor(string tinhTrang, string trangThai)
        {
            if (tinhTrang.Equals("Còn trống"))
                return Colors.Green;
            if (trangThai.Equals("Đang dọn dẹp"))
                return Colors.Gray;
            if (trangThai.Equals("Đang sửa chữa"))
                return Colors.DarkBlue;
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
    }
}
