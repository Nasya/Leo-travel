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


namespace Leo_travel
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        private int time = 20;
        load l = new load();
        

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Log w1 = new Log();
            w1.Show();
        }

        private void Load_table_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=1101;Database=leo;";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                myDataAdapter.SelectCommand = new MySqlCommand("select * database.edata", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();
                string Query = "Select * FROM text ";
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
                
                //MySqlCommand createCommand = new MySqlCommand(Query, myConn);
                //createCommand.ExecuteNonQuery();
                myConn.Close();


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

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
                
                string myConnection = "datasource=localhost;port=3306;username=root;password=1101;Database=leo;";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAd = new MySqlDataAdapter("Select * FROM images", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAd);
                myConn.Open();
                
                string Query = "Select * FROM images ";
                
                DataTable dt = new DataTable("images");
                myDataAd.Fill(dt);
                DataGrid2.ItemsSource = dt.DefaultView;
                myDataAd.Update(dt);
                MySqlCommand createCommand = new MySqlCommand(Query, myConn);
                createCommand.ExecuteNonQuery();

                myConn.Close();


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        

        //public class IntToImageConverter : IValueConverter
        //{

        //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //    {
        //        ImageSource result = null;
        //        var intValue = (int)value;
        //        switch (intValue)
        //        {
        //            case 0:
        //                {
        //                    result = new BitmapImage(new Uri(@"your_path_to_image_0"));
        //                    break;
        //                }

        //            case 1:
        //                {
        //                    result = new BitmapImage(new Uri(@"your_path_to_image_1"));
        //                    break;
        //                }
        //        }
        //        return result;
        //    }

        //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        




    } 
    }
