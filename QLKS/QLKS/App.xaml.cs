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
<<<<<<< HEAD

            DataSource = "REFICUL",
=======
            DataSource = "DESKTOP-VIIL54U\\HUYNHPHIPHUC",
            //DataSource = "REFICUL",
>>>>>>> f1bb51fdfda91a77e35299e53231cbe16922fc29

            InitialCatalog = "quanlykhachsan",
            IntegratedSecurity = true,
            //UserID = "sa",
            //Password = "sa"
        };
    }
}
