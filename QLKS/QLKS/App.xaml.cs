using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QLKS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static public SqlConnectionStringBuilder sConnB = new SqlConnectionStringBuilder()
        {

            //DataSource = "NVPIT\\SQLEXPRESS",

            

            //DataSource = "DESKTOP-VIIL54U\\HUYNHPHIPHUC",
            DataSource = "REFICUL",


            InitialCatalog = "quanlykhachsan",
            //IntegratedSecurity = true,
            UserID = "sa",
            Password = "sa"
        };
    }
}
