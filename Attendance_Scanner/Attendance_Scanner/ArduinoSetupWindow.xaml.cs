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

namespace Attendance_Scanner
{
    public partial class ArduinoSetupWindow : Window
    {
        public Arduino Arduino { get; set; }
        bool isConnected = false;
        String[] ports;

        public ArduinoSetupWindow(LoginWindow lw)
        {
            InitializeComponent();
            Arduino = new Arduino(lw, null, this);
            if (GetAvailableComPorts()) RefreshPortList();
        }

        void RefreshPortList()
        {
            COMBOX_Ports.Items.Clear();
            foreach (string port in ports)
            {
                COMBOX_Ports.Items.Add(port);
                COMBOX_Ports.SelectedItem = ports[0];
            }
        }

        bool GetAvailableComPorts()
        {
            ports = Arduino.GetPorts();

            try
            {
                if (ports[0] != "") return true;
                else return false;
            }
            catch (IndexOutOfRangeException e)
            {
                MessageBoxResult result = MessageBox.Show("No Arduino detected!");
                return false;
            }
            
        }

        private void BTN_Refresh_Click(object sender, RoutedEventArgs e)
        {
            if (GetAvailableComPorts()) RefreshPortList();
        }

        private void ConnectToArduino()
        {
            isConnected = true;
            Arduino.Connect(COMBOX_Ports.SelectedItem.ToString());
            BTN_Connect.Content = "Disconnect";
        }

        private void DisconnectFromArduino()
        {
            isConnected = false;
            Arduino.Disconnect();
            BTN_Connect.Content = "Connect";
        }

        private void BTN_Connect_Click(object sender, RoutedEventArgs e)
        {
            if (!isConnected)
            {
                ConnectToArduino();
            }
            else
            {
                DisconnectFromArduino();
            }
        }
    }
}
