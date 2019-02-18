using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Attendance_Scanner
{
    public class Arduino
    {
        SerialPort port;
        List<Student> Students { get; set; }
        MainWindow MainWindow { get; set; }

        public Arduino(MainWindow mainWindow)
        {
            Students = new List<Student>();
            MainWindow = mainWindow;
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
            Students.Add(new Student(0, data));
            MainWindow.lstUID.Items.Add(data);
        }

        public List<Student> GetStudents()
        {
            return Students;
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
                        if (Students.Count == 0)
                        {
                            LogStudent(data);
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
            }
            catch (Exception) { };
        }
    }
}
