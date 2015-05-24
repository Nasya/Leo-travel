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
    /// Логика взаимодействия для WinForm1.xaml
    /// </summary>
    public partial class WinForm1 : Window
    {
        public WinForm1()
        {
            InitializeComponent();
        }

        private void Add_but(object sender, RoutedEventArgs e)
        {
            string input_exname = textBox1.Text;
            string input_exprice = textBox2.Text;
            string input_extime = textBox3.Text;
            //connection to database
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "1101";
            builder.Database = "leo";
            MySqlConnection connection = new MySqlConnection(builder.ToString());
            connection.Open();
            // insert data to data base

            string newuser_sql = "INSERT INTO info (name,price,time) VALUES (@name,@price,@time)";
            MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
            newuser.CommandText = newuser_sql;
            newuser.Parameters.AddWithValue("@name", input_exname);
            newuser.Parameters.AddWithValue("@price", input_exprice);
            newuser.Parameters.AddWithValue("@time", input_extime);
            newuser.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Excursion added!");
        }
    }
}
