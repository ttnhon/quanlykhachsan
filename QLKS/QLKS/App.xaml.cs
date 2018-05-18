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
<<<<<<< HEAD
            DataSource = "NVPIT\\SQLEXPRESS",
=======
            DataSource = "desktop-viil54u\\huynhphiphuc",
>>>>>>> 800f858c5a2870df89849eb974afcdae5526463b
            InitialCatalog = "quanlykhachsan",
            IntegratedSecurity = true,
            //UserID = "sa",
            //Password = "sa"
        };
    }
}
