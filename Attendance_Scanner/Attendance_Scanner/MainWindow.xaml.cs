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
        List<Student> Students { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            getAvailableComPorts();
            RefreshPorts();
            Students = new List<Student>();
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
                        if(Students.Count == 0)
                        {
                            Application.Current.Dispatcher.Invoke(new Action(() => { lstUID.Items.Add(data); }));
                            Students.Add(new Student(0, data));
                        }
                        else
                        {
                            bool sameID = false;



                            foreach (var student in Students)
                            {
                                Console.WriteLine("isdie loop");
                                if (student.UID == data)
                                {
                                    Console.WriteLine("same id");
                                    
                                    sameID = true;
                                    break;
                                }
                            }

                            if(!sameID)
                            {
                                Application.Current.Dispatcher.Invoke(new Action(() => { lstUID.Items.Add(data); }));
                                Students.Add(new Student(0, data));
                                Console.WriteLine("new id");
                            }
                            

                        }

                        

                        //for (int i = 0; i < Students.Count; i++)
                        //{
                        //    if(Students[i].UID == data)
                        //    {
                        //        break;
                        //    }
                        //    else
                        //    {
                        //        Application.Current.Dispatcher.Invoke(new Action(() => { lstUID.Items.Add(data); }));
                        //        Students.Add(new Student(0, data));
                        //    }
                        //}
                    }
                }
            }
            catch (Exception) { };
        }
    }
}
