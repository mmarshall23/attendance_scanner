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

namespace Attendance_Scanner
{
    public partial class LoginWindow : Window
    {
        //bool isConnected = false;
        //String[] ports;
        //Arduino Arduino { get; set; }

        public LoginWindow()
        {
            InitializeComponent();
            //Arduino = new Arduino(null, this);
            //if (getAvailableComPorts()) connectToArduino();
        }

        //bool getAvailableComPorts()
        //{
        //    ports = Arduino.GetPorts();

        //    if (ports[0] != "") return true;
        //    else return false;
        //}

        //private void connectToArduino()
        //{
        //    Arduino.Connect(ports[0]);
        //}

        //private void disconnectFromArduino()
        //{
        //    Arduino.Disconnect();
        //    isConnected = false;
        //}

        private void BTN_Login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            Close();
        }
    }
}
