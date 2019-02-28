using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;

namespace Attendance_Scanner
{
    class Request
    {
        string module;
        string time;
        string matric;
        string day;
        string week;
        string present;

        string request;

        public Request(string m, string t, string ma, string d, string w, string p)
        {
            module = m;
            time = t;
            matric = ma;
            day = d;
            week = w;
            present = p;

            request = "https://tracker.napier.ac.uk/bjaxss.pl?secret=teamnyt2019&module="+module+"&time="+time+"&matric="+matric+"&day="+day+"&week="+week+"&present="+present;
        }
    }

    public class HTTPRequest
    {
        public HTTPRequest()
        {
            Request request = new Request("CSI09101", "11:00", "40340711", "0", "7", "0");
        }

        public void POST()
        {
            string html = string.Empty;
            string url = @"https://tracker.napier.ac.uk/bjaxss.pl?secret=teamnyt2019&module=CSI09101&time=11:00&matric=40340711&day=0&week=7&present=1";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            Console.WriteLine(html);
        }
    }
}
