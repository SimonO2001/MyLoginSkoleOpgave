using Microsoft.Data.SqlClient;
using System.Data;

namespace MyLogin.Data
{
    public class LoginClass
    {
        private string username;
        private string password;
        public LoginClass(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public void SQL()
        {
            SqlConnection conn = new SqlConnection("Data Source=192.168.2.2;Initial Catalog=LoginDB;User ID=sa;Password=Passw0rd;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            conn.Open();

            //SqlCommand command = new SqlCommand(
            //    "Select LoginUser from [UserDataTable]", conn);
            ////    "Select LoginUser from [Table] where LoginUser=@userlogin", conn);
            //command.Parameters.AddWithValue("@userlogin", username);
            //// int result = command.ExecuteNonQuery();
            //using (SqlDataReader reader = command.ExecuteReader())
            //{
            //    while (reader.Read())
            //    {
            //        Console.WriteLine(String.Format("{0}", reader["LoginUser"]));
            //    }
            //}

            string cmd = "Select * FROM UserDataTable Where LoginUser = '" + username + "' AND LoginPassword = '" + password + "'";
            SqlDataAdapter sda = new SqlDataAdapter(cmd,conn);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);

            if (dataTable.Rows.Count <= 0)
            {
                Console.WriteLine("Username or Password does not exist");
            }

            else
            {
                Console.WriteLine($"Successfully logged in with {username}");
            }

            conn.Close();
        }

    }
}
