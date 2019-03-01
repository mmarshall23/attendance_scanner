using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Windows;

namespace Attendance_Scanner
{
    public class Request
    {
        string result;

        public Request(string m, string t, string ma, string d, string w, string p)
        {
            result = "https://tracker.napier.ac.uk/bjaxss.pl?secret=teamnyt2019&module="+m+"&time="+t+"&matric="+m+"&day="+d+"&week="+w+"&present="+p;
        }

        public string GetResult()
        {
            return result;
        }
    }

    public class HTTPRequest
    {
        Request request;

        public HTTPRequest(string modules, string time, string matric, string day, string week, string present)
        {
            request = new Request(modules, time, matric, day, week, present);

            POST(request);
        }

        public void POST(Request r)
        {
            string html = string.Empty;
            string url = r.GetResult();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            MessageBox.Show(html);
            //Console.WriteLine(html);
        }
    }
}
