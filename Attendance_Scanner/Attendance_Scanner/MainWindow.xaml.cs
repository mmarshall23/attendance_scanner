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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isConnected = false;
        String[] ports;
        SerialPort port;

        public MainWindow()
        {
            InitializeComponent();
            getAvailableComPorts();
            RefreshPorts();
        }

        void CheckForData()
        {
            while (port.IsOpen)
            {
                string data = port.ReadLine();
                lstUID.Items.Add(data);
            }
        }

        void RefreshPorts()
        {
            comboPorts.Items.Clear();
            foreach (string port in ports)
            {
                comboPorts.Items.Add(port);
                Console.WriteLine(port);
                if (ports[0] != null)
                {
                    comboPorts.SelectedItem = ports[0];
                }
            }
        }

        void getAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
        }

        private void connectToArduino()
        {
            isConnected = true;
            string selectedPort = comboPorts.Text;
            port = new SerialPort();
            port.BaudRate = 9600;
            port.PortName = selectedPort;
            port.Open();
            btnConnect.Content = "Disconnect";
            StartReceive();
        }

        private void disconnectFromArduino()
        {
            isConnected = false;
            port.Close();
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

        private async void StartReceive()
        {
            while (port.IsOpen)
            {
                await Task.Run(() => Recieve());
            }
        }

        void Recieve()
        {
            try
            {
                if (port.IsOpen)
                {
                    string data = port.ReadLine();
                    if (data != "")
                    {
                        Application.Current.Dispatcher.Invoke(new Action(() => { lstUID.Items.Add(data); }));
                    }
                }
            }
            catch (Exception) { };
        }
    }
}
