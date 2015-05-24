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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Leo_travel
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public Reg()
        {
            InitializeComponent();
        }
        private void reg_but(object sender, RoutedEventArgs e)
        {
            string input_lname = textBox1.Text;
            string input_fname = textBox2.Text;
            string input_username = textBox3.Text;
            string input_password = textBox4.Text;
            //connection to database
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "1101";
            builder.Database = "leo";
            MySqlConnection connection = new MySqlConnection(builder.ToString());
            connection.Open();
            // insert data to data base

            string newuser_sql = "INSERT INTO tbl_user (LName,FName,Username,Password) VALUES (@lname,@fname,@username,@password)";
            MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
            newuser.CommandText = newuser_sql;
            newuser.Parameters.AddWithValue("@lname", input_lname);
            newuser.Parameters.AddWithValue("@fname", input_fname);
            newuser.Parameters.AddWithValue("@username", input_username);
            newuser.Parameters.AddWithValue("@password", input_password);

            newuser.ExecuteNonQuery();

            MessageBox.Show("new user create!");


        }
    }

}
