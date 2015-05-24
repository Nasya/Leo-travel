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
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Leo_travel
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public Order()
        {
            InitializeComponent();
            fill_combo();
        }
        private const String connectionString = "server=localhost;user id=root;password= 1101; database=leo;persistsecurityinfo=True;allowuservariables=True";

        void fill_combo()
        {
            MySqlConnection myConn = new MySqlConnection(connectionString);
            try
            {
                myConn.Open();
                String query = " select * from info";
                MySqlCommand createCommand = new MySqlCommand(query, myConn);
                MySqlDataReader dr = createCommand.ExecuteReader();
                while (dr.Read())
                {
                    String name = dr.GetString(1);
                    ComboBox1.Items.Add(name);
                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void ComboBox1_DropDownClosed(object sender, EventArgs e)
        {
            MySqlConnection myConn = new MySqlConnection(connectionString);
            try
            {
                myConn.Open();
                String query = " select * from info where name ='" + ComboBox1.Text + "'";
                MySqlCommand createCommand = new MySqlCommand(query, myConn);
                MySqlDataReader dr = createCommand.ExecuteReader();
                while (dr.Read())
                {
                    String price = dr.GetInt32(2).ToString();
                    String time = dr.GetDateTime(3).ToString();
                    textBox1.Text = price;
                    textBox2.Text = time;

                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Order_button(object sender, RoutedEventArgs e)
        {

            string input_name = textBox3.Text;
            string input_sname = textBox4.Text;
            string input_phone = textBox5.Text;
            string input_exname = ComboBox1.SelectedItem.ToString();
            string input_exprice = textBox1.Text;
            string input_extime = textBox2.Text;
            //connection to database
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "1101";
            builder.Database = "leo";
            MySqlConnection connection = new MySqlConnection(builder.ToString());
            connection.Open();
            // insert data to data base

            string newuser_sql = "INSERT INTO tbl_order (tbl_name,tbl_surname,tbl_phone, tbl_exname, tbl_exprice, tbl_extime) VALUES (@name,@sname,@phone,@exname,@exprice,@extime)";
            MySqlCommand newuser = new MySqlCommand(newuser_sql, connection);
            newuser.CommandText = newuser_sql;
            newuser.Parameters.AddWithValue("@name", input_name);
            newuser.Parameters.AddWithValue("@sname", input_sname);
            newuser.Parameters.AddWithValue("@phone", input_phone);
            newuser.Parameters.AddWithValue("@exname", input_exname);
            newuser.Parameters.AddWithValue("@exprice", input_exprice);
            newuser.Parameters.AddWithValue("@extime", input_extime);
            newuser.ExecuteNonQuery();
            
            System.Windows.MessageBox.Show("Order complite!");
            SaveFileDialog sfd1 = new SaveFileDialog();
            if (sfd1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (Stream s = File.Open(sfd1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write("Name: " + input_name + "   ");
                    sw.Write("Surname:   " + input_sname+ "    ");
                    sw.Write("Phone:   " + input_phone + "    ");
                    sw.Write("Name of excursion:   " + input_exname + "    ");
                    sw.Write("Price:    "+ input_exprice + "   ");
                    sw.Write("Time:   " + input_extime + "    ");
                }

            }
        }

        private void Print_but_Click(object sender, RoutedEventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Test.pdf", FileMode.Create));
            doc.Open();
            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph();
            doc.Add(paragraph);
        }
    }
}
