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
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Windows.Forms;

 



namespace Leo_travel
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        private int time = 20;
        load l = new load();

        private const String connectionString = "server=localhost;user id=root;password= 1101; database=leo;persistsecurityinfo=True;allowuservariables=True";

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            l.Show();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (time > 10)
            {
                time--;
                timer.Stop();
                l.Close();
            }
        }
 
        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void Button_log(object sender, RoutedEventArgs e)
        {

            Log w1 = new Log();
            w1.Show();
        }

        private void Load_table_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string myConnection = connectionString;
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                myDataAdapter.SelectCommand = new MySqlCommand("select * database.edata", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();
                string Query = "Select * FROM info ";
                using (MySqlCommand cmdSel = new MySqlCommand(Query, myConn))
                {
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                    da.Fill(dt);
                    dataGrid1.DataContext = dt;

                    List<MyDataObject> list = new List<MyDataObject>();
                    list.Add(new MyDataObject() { ImageFilePath = new Uri("file:///E:\\Projects\\Leo-travel\\Leo-travel\\Leo-travel\\pics\\lviv.jpg"), InfoFilePath = new Uri("file:///E:\\Projects\\Leo-travel\\Leo-travel\\Leo-travel\\pics\\lviv_hr.png") });
                    list.Add(new MyDataObject() { ImageFilePath = new Uri("file:///E:\\Projects\\Leo-travel\\Leo-travel\\Leo-travel\\pics\\lvivcenter.jpg"), InfoFilePath = new Uri("file:///E:\\Projects\\Leo-travel\\Leo-travel\\Leo-travel\\pics\\lviv_mol.png") });
                    list.Add(new MyDataObject() { ImageFilePath = new Uri("file:///E:\\Projects\\Leo-travel\\Leo-travel\\Leo-travel\\pics\\high_castle.jpg"), InfoFilePath = new Uri("file:///E:\\Projects\\Leo-travel\\Leo-travel\\Leo-travel\\pics\\lviv_high.png") });
                    dataGrid1.ItemsSource = list;
                    

                }
                
                myConn.Close();
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
        }

        public class MyDataObject
        {
            public Uri ImageFilePath { get; set; }
            public Uri InfoFilePath { get; set; }
        }

        private void DataGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                string myConnection = connectionString;
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAd = new MySqlDataAdapter("Select * FROM images", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAd);
                myConn.Open();
                
                string Query = "Select * FROM images ";
                
                DataTable dt = new DataTable("images");
                myDataAd.Fill(dt);
                DataGrid2.ItemsSource = dt.DefaultView;
                myDataAd.Update(dt);
                



                //foreach (DataRow dr in dt.Rows)
                //{
                //    byte[] bytes = (byte[])dr[4];
                //    MemoryStream stream = new MemoryStream(bytes);

                //    BitmapImage image = new BitmapImage();
                //    image.BeginInit();
                //    image.StreamSource = stream;
                //    image.EndInit();
                    
                //}
                MySqlCommand createCommand = new MySqlCommand(Query, myConn);
                createCommand.ExecuteNonQuery();

                myConn.Close();


            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           // byte[] Img;
           // System.Drawing.Bitmap picture;


            try
            {
                string myConnection = connectionString;
                MySqlConnection myConn = new MySqlConnection(myConnection);
                //MySqlDataAdapter sda = new MySqlDataAdapter("", myConn);
                //SqlCommandBuilder cb ;
                


               // using (MySqlCommand cmdData = new MySqlCommand("SELECT image FROM images", myConn))
                //{
                    //DataTable dbdataset_pic = new DataTable();
                    //MySqlDataAdapter sda = new MySqlDataAdapter(cmdData);
                    //sda.Fill(dbdataset_pic);

                    String query = "SELECT image, description FROM images";
                    MySqlCommand com = new MySqlCommand(query, myConn);
                    myConn.Open();
                    MySqlDataReader reader = com.ExecuteReader();
                    HashSet<OurImage> list = new HashSet<OurImage>();
                    OurImage image = new OurImage();
                    int i = 0;
                    while (reader.Read())
                    {
                        image.setFilePath2(reader["image"].ToString());
                        image.setDescription(reader["description"].ToString());
                        list.Add(image);
                        i++;
                    }
                    myConn.Close();

                    //dataGrid1.DataContext = dt;
                                        
                   // MySqlCommand cmdData = new MySqlCommand();

                    //DataTable dbdataset_pic;
                    //   BindingSource bSource = new BindingSource();

                    //  bSource.DataSource = dbdataset;
                    // dataGridView1.DataSource = bSource;
                    // sda.Update(dbdataset);

                   // cmdData.CommandText = "SELECT image FROM images";

                   // sda.SelectCommand = cmdData;

                    //cb = new MySqlCommandBuilder(sda);
                   // dbdataset_pic = new DataTable();

                   
                    //sda.Fill(dbdataset_pic);
                //    string old = @"\";
                  //  string new_c = @"\\";

                   // List<MyDataObject2> list = new List<MyDataObject2>();
                    
                   // foreach (DataRow rows in dbdataset_pic.Rows)
                   // {
                        //Img = (byte[])rows[0];
                    //    MessageBox.Show("OK!");
                      //  Picture2 = new System.Drawing.Bitmap(new MemoryStream(Img));
                        //MemoryStream mst = new MemoryStream(Img);                       
                        //picture = new Bitmap(mst);
                                                                       
                        //picture = new Bitmap(new MemoryStream(Img));
                       
                        
                        //list.Add(new Bitmap(mst));
                      //  list.Add(System.Drawing.Image.FromFile(Directory.GetCurrentDirectory()+"\\"+rows[0]));
                        
                        //DataGrid3.Columns[1].SetValue(list[0]);
                   // list.Add(new MyDataObject2() { ImageFilePath2 = new Uri("file:///" + Directory.GetCurrentDirectory() + "@pic/high_castle.jpg"), InfoFilePath2 = new Uri("file:///E:\\Projects\\Leo-travel\\Leo-travel\\Leo-travel\\pics\\lviv_mol.png") });
                    // list.Add(new MyDataObject2() { ImageFilePath2 = new Uri(""), InfoFilePath2 = new Uri("file:///E:\\Projects\\Leo-travel\\Leo-travel\\Leo-travel\\pics\\lviv_hr.png") });
                    //list.Add(new MyDataObject2() { ImageFilePath2 = new Uri("file:///E:\\Projects\\Leo-travel\\Leo-travel\\Leo-travel\\pics\\lvivcenter.jpg"), InfoFilePath2 = new Uri("file:///E:\\Projects\\Leo-travel\\Leo-travel\\Leo-travel\\pics\\lviv_mol.png") });

                    // } .Replace(old, new_c) + new_c + dbdataset_pic.Rows[0]
                    
                    List<MyDataObject2> data = new List<MyDataObject2>();

                foreach(OurImage value in list)
                {
                    data.Add(new MyDataObject2() { FilePath2 = new Uri(value.getFilePath2()), description = new Uri(value.getDescription()) });
                }
                    
                    dataGrid3.ItemsSource = data;

                }
                //}
             catch (Exception ex)
             {
                System.Windows.Forms.MessageBox.Show(ex.Message);
             } 

            }
        public class MyDataObject2
        {
            public Uri FilePath2 { get; set; }
            public Uri description { get; set; }
        }


        public class OurImage
        {
            private string filePath2;
            private string description;

            public OurImage()
            {

            }

            public OurImage(string filePath2, string description)
            {
                this.filePath2 = filePath2;
                this.description = description;
            }

            public string getFilePath2()
            {
                return filePath2;
            }

            public void setFilePath2(string filePath2)
            {
                this.filePath2 = filePath2;
            }

            public string getDescription()
            {
                return description;
            }

            public void setDescription(string description)
            {
                this.description = description;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Order w3 = new Order();
            w3.Show();
        }

        

        }


    } 
    
