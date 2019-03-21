﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Data.SqlClient;
using System.Windows;

namespace Attendance_Scanner
{
    public class Arduino
    {
        SqlConnection sqlConnection;

        SerialPort port;
        public List<Student> Students { get; set; }

        public LoginWindow loginWindow;
        public MainWindow mainWindow;
        public ArduinoSetupWindow arduinoSetup;

        public bool LoginPhase { get; set; }
        public string LecturerUID { get; set; }

        public Arduino(LoginWindow login, MainWindow main, ArduinoSetupWindow setup)
        {
            ConnectDatabase();

            //initalising variables
            LoginPhase = false;
            Students = new List<Student>();
            loginWindow = login;
            mainWindow = main;
            arduinoSetup = setup;
            LecturerUID = "";

            if (mainWindow == null) LoginPhase = true;
        }

        public string[] GetPorts()
        {
            return SerialPort.GetPortNames();
        }

        public void Connect(string portName)
        {
            port = new SerialPort();
            port.BaudRate = 9600;
            port.PortName = portName;
            port.Open();

            loginWindow.ArduinoSetup = true;

            StartReceive();
        }

        public void Disconnect()
        {
            port.Close();
        }


        private async void StartReceive()
        {
            while (port.IsOpen)
            {
                await Task.Run(() => Recieve());
            }
        }

        void LogStudent(string data)
        {
            string UID = data;
            string matric;

            matric = TableQuery(data);

            mainWindow.AddMatricToListBox(matric);

            Students.Add(new Student(matric, UID));
            
        }

        void Recieve()
        {
            try
            {
                string data = port.ReadLine();
                data = data.Substring(0, 8);

                if (LoginPhase)
                {
                    string result = TableQuery(data);
                    if (result == "99999999")
                    {
                        Application.Current.Dispatcher.Invoke(new Action(() => { loginWindow.Login("user", "1234"); }));
                        LecturerUID = data;
                    }

                    LoginPhase = false;
                }

                if (data != "" && !LoginPhase && data != LecturerUID)
                {
                    Application.Current.Dispatcher.Invoke(new Action(() => { arduinoSetup.LBL_LastRead.Content = data; }));

                    if (Students.Count == 0)
                    {
                        LogStudent(data);
                        Console.WriteLine(data);
                    }
                    else
                    {
                        bool sameID = false;

                        foreach (var student in Students)
                        {
                            if (student.UID == data)
                            {
                               
                                sameID = true;
                                break;
                            }
                        }

                        if (!sameID)
                        {
                            LogStudent(data);
                        }
                    }
                }
            }
            catch (Exception) { };
        }

        void ConnectDatabase()
        {
            string connectionSource = "";

            try
            {
                connectionSource = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cdwor\Documents\SourceTree Repos\attendance_scanner\Attendance_Scanner\Attendance_Scanner\StudentDatabase.mdf;Integrated Security=True";
                sqlConnection = new SqlConnection(connectionSource);
                sqlConnection.Open();
                Console.WriteLine("Connected to Database!");
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
            string sql, output = "";

            sql = string.Format("SELECT MatricNum FROM Students WHERE UID='{0}'", uid);

            cmd = new SqlCommand(sql, sqlConnection);

            dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                output = output + dataReader.GetValue(0);
            }

            dataReader.Close();
            cmd.Dispose();

            if (output == "") return "Could not find UID!?";
            else return output;
        }
    }
}
