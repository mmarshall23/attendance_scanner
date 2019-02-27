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
using System.Data.SqlClient;

namespace Attendance_Scanner
{
    public partial class MainWindow : Window
    {
        bool isConnected = false;
        String[] ports;
        Arduino Arduino { get; set; }
        string output = "", sql, connection = "";
        
        
        SqlConnection cnn;

        public MainWindow()
        {
            InitializeComponent();
            Arduino = new Arduino(this, null);
            if (getAvailableComPorts()) RefreshPortList();
            ConnectDatabase();
        }

        void ConnectDatabase()
        {
            try
            {
                connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cdwor\Documents\SourceTree Repos\attendance_scanner\Attendance_Scanner\Attendance_Scanner\StudentDatabase.mdf;Integrated Security=True";

                cnn = new SqlConnection(connection);
                cnn.Open();
                Console.WriteLine("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        string TableQuery(string uid)
        {
            SqlDataReader dataReader;
            SqlCommand cmd;

            sql = string.Format("SELECT MatricNum FROM Students WHERE UID='{0}'", uid);

            cmd = new SqlCommand(sql, cnn);

            dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                output = output + dataReader.GetValue(0);
            }

            dataReader.Close();
            //cmd.Dispose();
            //cnn.Close();

            return output;
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
            isConnected = false;
            Arduino.Disconnect();
            btnConnect.Content = "Connect";
        }

        public void Add(string data)
        {
            data = data.Substring(0, 8);

            Application.Current.Dispatcher.Invoke(new Action(() => { lstUID.Items.Add(TableQuery(data)); }));
            output = "";

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
