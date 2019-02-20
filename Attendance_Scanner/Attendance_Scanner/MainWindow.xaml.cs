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
using System.IO.Ports;
using MySql.Data.MySqlClient;

namespace Attendance_Scanner
{
    public partial class MainWindow : Window
    {
        bool isConnected = false;
        String[] ports;
        Arduino Arduino { get; set; }
        DataGrid dSet;
        string[,] database = new string[6, 2] {{"UID","40340711"}, //chris
                                              {"0D055170","40284904 - Rodrigo"}, //rodrigo
                                              {"8D494D70","40340707 - Adam"}, //adam
                                              {"1D0C5270","40340713 - Dorren"}, //dorren
                                              {"DD344D70","40328672 - Angelo"}, //angelo
                                              {"36C09AC9","40168115 - Murray"}}; //murray


        public MainWindow()
        {
            
            InitializeComponent();
            Arduino = new Arduino(this, null);
            if (getAvailableComPorts()) RefreshPortList();
            //ConnectDatabase();
            
        }

        void ConnectDatabase()
        {
            try
            {
                var connstr = "SERVER=soc-web-liv-52.napier.ac.uk;port=3306;DATABASE=attendance_scanner;UID=40340711;PASSWORD=esh45NLm;";

                using (var conn = new MySqlConnection(connstr))
                {
                    conn.Open();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from Students";
                        //cmd.Parameters.AddWithValue("@ID", "100");
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var ii = reader.FieldCount;
                                for (int i = 0; i < ii; i++)
                                {
                                    if (reader[i] is DBNull)
                                        txtBox.Text += "null";
                                    else
                                        txtBox.Text += reader[i].ToString();
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void RefreshPortList()
        {
            comboPorts.Items.Clear();
            foreach (string port in ports)
            {
                comboPorts.Items.Add(port);
                comboPorts.SelectedItem = ports[0];
            }
        }

        bool getAvailableComPorts()
        {
            ports = Arduino.GetPorts();

            if (ports[0] != "") return true;
            else return false;
        }

        private void connectToArduino()
        {
            Arduino.Connect(comboPorts.SelectedItem.ToString());
            btnConnect.Content = "Disconnect";
        }

        private void disconnectFromArduino()
        {
            Arduino.Disconnect();
            isConnected = false;
            btnConnect.Content = "Connect";
        }

        public void Add(string data)
        {
            data = data.Substring(0, 8);

            for (int i = 0; i < 6; i++)
            {



                if (database[i, 0] == data)
                {
                    Application.Current.Dispatcher.Invoke(new Action(() => { lstUID.Items.Add(database[i, 1]); }));
                    break;
                }
                else if(i == 5)
                {
                    Application.Current.Dispatcher.Invoke(new Action(() => { lstUID.Items.Add("Could not find UID!"); }));
                }

                //Application.Current.Dispatcher.Invoke(new Action(() => { lstUID.Items.Add(data); }));
            }

            
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (!isConnected)
            {
                connectToArduino();
            }
            else
            {
                disconnectFromArduino();
            }
        }
    }
}
