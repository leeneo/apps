using System;
using System.Collections.Generic;

namespace CSharp
{
    class TestDate
    {
        public static DateTime Datevalue { get; set; }

        public static string ShortDate()
        {
            return Datevalue.ToShortDateString();
        }
        public static string ShortTime()
        {
            return Datevalue.ToShortTimeString();
        }

        public static string LongDate()
        {
            return Datevalue.ToLongDateString();
        }
        public static string LongTime()
        {
            return Datevalue.ToLongTimeString();
        }

        public static DateTime LocalTime()
        {
            return Datevalue.ToLocalTime();
        }
        public static DateTime UniversalTime()
        {
            return Datevalue.ToUniversalTime();
        }

        public static  string ToString()
        {
            return Datevalue.ToString();
        }

        public static DateTime Date()
        {
            return Datevalue.Date;
        }

    }
}