using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_Scanner
{
    public class Student
    {
        public string MatricNum { get; set; }
        public string UID { get; set; }
        public DateTime Date { get; set; }

        public Student(string num, string uid)
        {
            MatricNum = num;
            UID = uid;
        }
    }
}
