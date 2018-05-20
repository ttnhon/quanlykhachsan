using QLKS.DAO;
using QLKS.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for CapNhatDichVu.xaml
    /// </summary>
    public partial class CapNhatDichVu : Window
    {
        int MaPhong;
        DataTable dtGioHang = new DataTable();
        public CapNhatDichVu(int maPhong)
        {
            InitializeComponent();

            MaPhong = maPhong;
            txtPhong.Text = maPhong.ToString();
            dgDanhSach.ItemsSource = DichVuDAO.LoadConSuDung().DefaultView;


            dtGioHang.Columns.Add("MaDV", typeof(int));
            dtGioHang.Columns.Add("TenDV", typeof(string));
            dtGioHang.Columns.Add("DonGia", typeof(float));
            dtGioHang.Columns.Add("SoLuong", typeof(int));
            dtGioHang.Columns.Add("ThanhTien", typeof(float));

            DataTable table = ChiTietDichVuDAO.LoadByMaPhong(maPhong);
            DataRow rowOfGioHang;
            for(int i=0;i<table.Rows.Count;i++)
            {
                int maDv = table.Rows[i].Field<int>(0);
                DichVu dv = DichVuDAO.LoadOne(maDv);
                rowOfGioHang = dtGioHang.NewRow();
                rowOfGioHang["MaDV"] = maDv;
                rowOfGioHang["TenDV"] = dv.TenDV;
                rowOfGioHang["DonGia"] = dv.DonGia;
                rowOfGioHang["SoLuong"] = table.Rows[i].Field<int>(1);
                rowOfGioHang["ThanhTien"] = dv.DonGia * table.Rows[i].Field<int>(1);
                dtGioHang.Rows.Add(rowOfGioHang);
            }
            dgGioHang.ItemsSource = dtGioHang.DefaultView;
            txtTongTien.Text = TinhTongTien();
        }

        private void BtnThoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtTimKiem_TextChanged(object sender, TextChangedEventArgs e)
        {
            string tenDv = txtTimKiem.Text;
            if (tenDv.Equals(""))
            {
                dgDanhSach.ItemsSource = DichVuDAO.LoadConSuDung().DefaultView;
            }
            else
                dgDanhSach.ItemsSource = DichVuDAO.TimTheoTen(tenDv).DefaultView;
        }

        private void BtnThemGioHang_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowView = dgDanhSach.SelectedItem as DataRowView;
            if (rowView == null)
                return;
            int maDv = Int32.Parse(rowView.Row["MaDV"].ToString());
            string strSoLuong = txtSoLuong.Text;
            if (strSoLuong.Equals("") || strSoLuong.Equals("0"))
                return;
            int soLuong = Int32.Parse(strSoLuong);
            DichVu dv = DichVuDAO.LoadOne(maDv);
            
            foreach(DataRow dr in dtGioHang.Rows)
            {
                if(dr.Field<int>("MaDV") == maDv)
                {
                    int soLuongMoi = dr.Field<int>("SoLuong")+soLuong;
                    float thanhTienMoi = soLuongMoi * dr.Field<float>("DonGia");
                    dr.SetField<int>("SoLuong", soLuongMoi);
                    dr.SetField<float>("ThanhTien", thanhTienMoi);
                    txtTongTien.Text = TinhTongTien();
                    return;
                }
            }

            DataRow row = dtGioHang.NewRow();
            row["MaDV"] = maDv;
            row["TenDV"] = dv.TenDV;
            row["DonGia"] = dv.DonGia;
            row["SoLuong"] = soLuong;
            row["ThanhTien"] = dv.DonGia*soLuong;
            dtGioHang.Rows.Add(row);
            txtSoLuong.Text = "1";

            txtTongTien.Text = TinhTongTien();
        }

        private void NumericOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }
        public static bool IsTextNumeric(string str)
        {
            Regex reg = new Regex("[^0-9]");
            return reg.IsMatch(str);
        }

        private void BtnXoaDichVu_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowView = dgGioHang.SelectedItem as DataRowView;
            if (rowView == null)
                return;
            int maDv = rowView.Row.Field<int>("MaDV");
            for(int i=0;i<dtGioHang.Rows.Count;i++)
            {
                if(dtGioHang.Rows[i].Field<int>("MaDV") == maDv)
                {
                    dtGioHang.Rows.RemoveAt(i);
                    txtTongTien.Text = TinhTongTien();
                    return;
                }
            }
            
        }
        string TinhTongTien()
        {
            float tongTien = 0;
            foreach(DataRow dr in dtGioHang.Rows)
            {
                tongTien += dr.Field<float>("ThanhTien");
            }
            string res = string.Format("{0:0,0}", tongTien);
            return res;
        }

        private void BtnLuu_Click(object sender, RoutedEventArgs e)
        {
            int maPhong = Int32.Parse(txtPhong.Text);
            ThuePhongDTO thuePhongDTO = ThuePhongDAO.LoadOne(maPhong);
            int maKhach = thuePhongDTO.MaKhach;
            if (MessageBox.Show("Xác nhận lưu?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            ChiTietDichVuDAO.DeleteByMaPhong(maPhong);
            foreach(DataRow dr in dtGioHang.Rows)
            {
                int maDV = dr.Field<int>("MaDV");
                int soLuong = dr.Field<int>("SoLuong");
                ChiTietDichVuDAO.Insert(maDV, maKhach, soLuong, maPhong);
            }
            MessageBox.Show("Lưu thành công!", "Thông báo");
        }
    }
}
