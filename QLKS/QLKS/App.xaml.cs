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
            DataSource = "NVPIT\\SQLEXPRESS",
            InitialCatalog = "quanlykhachsan",
            UserID = "sa",
            Password = "sa"
        };
        static public string hashPassword(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            string stringhash = hash.ToString();
            string output = "";

            // Lam mau (tang do kho cho may thim Hacker)
            for (int i = 0; i < stringhash.Length; i++)
            {
                if (i == 3)
                    output += stringhash[i + 8];
                else
                    output += stringhash[i];
            }
            return output;
        }
    }
}
