﻿using System;
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

namespace Leo_travel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
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
                string myConnection = "datasource=localhost;port=3306;username=root;password=1101;";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                myDataAdapter.SelectCommand = new MySqlCommand("select * database.edata", myConn);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
                myConn.Open();
                string Query = "Select * user ";
                MySqlCommand createCommand = new MySqlCommand(Query, myConn);
                createCommand.ExecuteNonQuery();

                myConn.Close();
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        
        
       
      
        
       
    }
  
    }
