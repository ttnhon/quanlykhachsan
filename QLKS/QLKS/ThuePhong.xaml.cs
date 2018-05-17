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
        public ThuePhong()
        {
            InitializeComponent();

            System.Windows.Controls.Button myBtn = new Button();
            myBtn.Content = "Test button 7";
            myBtn.Name = "btn7";
            RoutedEventHandler a = new RoutedEventHandler(Button_Click);
            myBtn.Click += a;
            wrapPanel.Children.Add(myBtn);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if(button != null)
               MessageBox.Show(button.Name);
        }
    }
}
