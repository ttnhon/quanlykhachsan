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
            //DataSource = "DESKTOP-VIIL54U\\HUYNHPHIPHUC",
=======
            //DataSource = "NVPIT\\SQLEXPRESS",

            

            //DataSource = "DESKTOP-VIIL54U\\HUYNHPHIPHUC",
            DataSource = "REFICUL",
<<<<<<< HEAD

=======
=======
            DataSource = "DESKTOP-VIIL54U\\HUYNHPHIPHUC",
>>>>>>> 8839c598ea3b59691c948ddd07b79b3c20a1853e
            //DataSource = "REFICUL",
>>>>>>> f1bb51fdfda91a77e35299e53231cbe16922fc29
>>>>>>> cb532517b5883f4afed387ef0f6ea585c74e3d04

            InitialCatalog = "quanlykhachsan",
            //IntegratedSecurity = true,
            UserID = "sa",
            Password = "sa"
        };
    }
}
