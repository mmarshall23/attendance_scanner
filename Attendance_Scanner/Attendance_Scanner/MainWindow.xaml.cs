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

namespace Attendance_Scanner
{
    public partial class MainWindow : Window
    {
        bool isConnected = false;
        String[] ports;
        Arduino Arduino { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            if(getAvailableComPorts()) RefreshPortList();
            Arduino = new Arduino(this);
        }

        //What's this???????
        //void CheckForData()
        //{
        //    while (port.IsOpen)
        //    {
        //        string data = port.ReadLine();
        //        lstUID.Items.Add(data);
        //    }
        //}

        //void RefreshStudentList

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

            if (ports[0] != "") return false;
            else return true;
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
