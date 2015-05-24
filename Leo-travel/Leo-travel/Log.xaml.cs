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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Leo_travel
{
    /// <summary>
    /// Логика взаимодействия для Log.xaml
    /// </summary>
    public partial class Log : Window
    {
        public Log()
        {
            InitializeComponent();

        }
      
        private const String connectionString = "server=localhost;user id=root;password= 1101; database=leo;persistsecurityinfo=True;allowuservariables=True";
        MySqlCommand cmd = new MySqlCommand();
        private void Button_Click(object sender, RoutedEventArgs e)
        {               
                string myConnection = connectionString;
                MySqlConnection myConn = new MySqlConnection(myConnection);
                cmd.Connection = myConn;
                myConn.Open();
                try{
                    cmd.CommandText = "SELECT Count(*) From tbl_user where Username='" + textBox1.Text + "'and Password= '" + textBox2.Text + "'";
                
                    int valor = int.Parse(cmd.ExecuteScalar().ToString());
                    if (valor == 1)
                    {
                        WinForm1 form = new WinForm1();
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("not exit");

                    }
                    myConn.Close();
                }
                catch (Exception ex) { 
                    MessageBox.Show("error" + ex); 
                }
           
        }

        private void But_sign(object sender, RoutedEventArgs e)
        {
            Reg r1 = new Reg();
            r1.Show();
        }
    }

 }
