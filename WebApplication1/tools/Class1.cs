using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public interface Iaaa
    {
        int a { get; set; }
        string hello(string str);
    }

    public class aaa : Iaaa
    {
        public aaa()
        {
            a = DateTime.Now.Millisecond;
        }
        public int a { get; set; }

        public string hello(string str)
        {
            return "hello " + str + " timestamp: " + a;
        }
    }

    public interface Ibbb
    {
        string curtime { get; }
    }

    public class bbb : Ibbb
    {
        public string curtime
        {
            get
            {
                return "current time is: " + DateTime.Now.ToString("s");
            }
        }
    }

}