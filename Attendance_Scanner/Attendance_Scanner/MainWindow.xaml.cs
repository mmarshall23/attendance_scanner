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
        public bool SheetDataReady { get; set; }
        public string Module { get; set; }
        public string Time { get; set; }
        public string Day { get; set; }
        public string Week { get; set; }
        public ArduinoSetupWindow ArduinoSetupWindow { get; set; }

        public MainWindow(ArduinoSetupWindow arduino)
        {
            InitializeComponent();

            ArduinoSetupWindow = arduino;
            SheetDataReady = false;
            Module = "";
            Time = "";
            Day = "";
            Week = "";
        }

        public void AddMatricToListBox(string data)
        {
            data = data.Substring(0, 8);

            Application.Current.Dispatcher.Invoke(new Action(() => { lstUID.Items.Add(data); }));
        }

        private void BTN_HTTP_Click(object sender, RoutedEventArgs e)
        {
            if(SheetDataReady)
            {
                foreach (var student in ArduinoSetupWindow.Arduino.Students)
                {
                    HTTPRequest httpRequest = new HTTPRequest(Module, Time, student.MatricNum, Day, Week, "1");
                }
            }
        }

        private void BTN_Set_Click(object sender, RoutedEventArgs e)
        {
            Module = TXTBOX_Module.Text;
            Time = COMBOX_Time.Text;
            Day = COMBOX_Time.Text;
            Week = COMBOX_Week.Text;
            SheetDataReady = true;
        }
    }
}
