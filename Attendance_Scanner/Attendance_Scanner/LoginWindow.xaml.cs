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
using System.Data.SqlClient;

namespace Attendance_Scanner
{
    public partial class LoginWindow : Window
    {
        public bool  ArduinoSetUp { get; set; }
        

        public LoginWindow()
        {
            InitializeComponent();
            ArduinoSetUp = false;
        }

        public void RunArduino()
        {
            while(true)
            {

            }
        }

        private void BTN_Login_Click(object sender, RoutedEventArgs e)
        {
            Login(TXTBOX_User.Text, TXTBOX_Pass.Text);
        }

        public void Login(string user, string pass)
        {
            if (pass == "1234" && user == "user")
            {
                if(!ArduinoSetUp)
                {
                    MessageBoxResult reuslt = MessageBox.Show("Please set up Arduino first.");
                }
                else
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    Close();
                }
            }
            else
            {
                MessageBoxResult reuslt = MessageBox.Show("Incorrect login details!");
            }
        }

        private void BTN_StartArduino_Click(object sender, RoutedEventArgs e)
        {
            ArduinoSetupWindow arduinoSetupWindow = new ArduinoSetupWindow(this);
            arduinoSetupWindow.Show();
        }

        
    }
}
