using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stadtplanverwaltung.Model
{
    // 
    public class DatabaseConnection
    {
        private static String connectionString;
        private static OleDbConnection myOleDbConnection;

        private string provider;
        private string dataSource;
        private string userId;
        private string userPwd;

        public DatabaseConnection(string provider, string dataSource, string userId, string userPwd)
        {
            SetProvider(provider);
            SetDataSource(dataSource);
            SetUserId(userId);
            SetUserPwd(userPwd);

            Connect();
        }

        public void SetProvider(string provider)
        {
            this.provider = provider;
        }

        public string GetProvider()
        {
            return provider;
        }

        public void SetDataSource(string dataSource)
        {
            this.dataSource = dataSource;
        }

        public string GetDataSource()
        {
            return dataSource;
        }

        public void SetUserId(string userId)
        {
            this.userId = userId;
        }

        public string GetUserId()
        {
            return userId;
        }

        public void SetUserPwd(string userPwd)
        {
            this.userPwd = userPwd;
        }

        public string GetUserPwd()
        {
            return userPwd;
        }

        public string GetConnectionString()
        {
            return connectionString;
        }

        public void Connect()
        {
            try
            {
                //Connection mit interner IP-Adresse
                connectionString = "Provider=" + provider + "; Data Source=" + dataSource + "; User Id=" + userId + "; Password=" + userPwd + ";OLEDB.NET=True;";
                //Connection mit externer IP-Adresse
                //connectionString = "Provider=OraOLEDB.Oracle; Data Source=212.152.179.117/ora11g; User Id=d5a04;Password=d5a;OLEDB.NET=True;";
                myOleDbConnection = new OleDbConnection(connectionString);
                myOleDbConnection.Open();
                Console.WriteLine("Sucessfully connected to Database!");
            }
            catch (Exception ex1)
            {
                Console.WriteLine("Connect-Error " + ex1.Message);
            }
        }
    }
}
