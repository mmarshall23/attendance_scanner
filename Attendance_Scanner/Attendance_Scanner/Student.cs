using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_Scanner
{
    //private 

    class Student
    {
        private int MetricNum { get; set; }
        public string UID { get; set; }
        private DateTime Date { get; set; }

        public Student(int num, string id)
        {
            MetricNum = num;
            UID = id;
            Date = DateTime.Now;
        }
    }
}
