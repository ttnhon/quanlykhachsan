﻿using System;
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
    /// Interaction logic for Trangchu.xaml
    /// </summary>
    public partial class Trangchu : Window
    {
        string name, account;
        public Trangchu(string name, string account)
        {
            InitializeComponent();
            this.name = name;
            this.account = account;
            LabelName.Content = name;
        }
    }
}
