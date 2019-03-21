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
        public int scannedcounter { get; set; }
        public bool edit = false;
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
            scannedcounter = 0;
            LBL_Status.Content = "Not Ready";
            lblstudendscanned.Content = scannedcounter.ToString();
            
        }

        public void AddMatricToListBox(string data)
        {
            data = data.Substring(0, 8);

            Application.Current.Dispatcher.Invoke(new Action(() => { lstUID.Items.Add(data); }));
            scannedcounter++;

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
            if (edit == false)
            {
                Module = TXTBOX_Module.Text;
                Time = COMBOX_Time.Text;
                Day = (COMBOX_Day.SelectedIndex).ToString();
                Week = COMBOX_Week.Text;
                SheetDataReady = true;
                LBL_Status.Content = "Ready";
                LBL_Status.Foreground = new SolidColorBrush(Colors.Green);
                BTN_Set.Content = "Edit";
                LBL_Reader.Content = "Reader On";
                COMBOX_Time.Visibility = Visibility.Collapsed;
                COMBOX_Week.Visibility = Visibility.Collapsed;
                COMBOX_Day.Visibility = Visibility.Collapsed;
                TXTBOX_Module.Visibility = Visibility.Collapsed;
                lblmodule.Content = "Module: " + Module;
                lblweek.Content = "Week: " + Week;
                lblday.Content = "Day: " + Day;
                lbltime.Content = "Time: " + Time;
                edit = true;
            }
            else if (edit)
            {
                COMBOX_Time.Visibility = Visibility.Visible;
                COMBOX_Week.Visibility = Visibility.Visible;
                COMBOX_Day.Visibility = Visibility.Visible;
                TXTBOX_Module.Visibility = Visibility.Visible;
                LBL_Status.Content = "Not Ready";
                LBL_Status.Foreground = new SolidColorBrush(Colors.Red);
                BTN_Set.Content = "Set";
                lblmodule.Content = "Module: " ;
                lblweek.Content = "Week: ";
                lblday.Content = "Day: ";
                lbltime.Content = "Time: ";
                LBL_Reader.Content = "Reader Off";
                SheetDataReady = false;
                edit = false;

            }
        }

        public void ValidateSheet(string module, string time, string day, string week)
        {
            //validate each input field independently 
        }
    }
}
