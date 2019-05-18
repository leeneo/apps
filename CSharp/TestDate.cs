using System;
using System.Collections.Generic;

namespace CSharp {
    static class TestDate{
        public static DateTime Datevalue { get; set; }

        public static void NowDate () {
            Console.WriteLine ("DateTime.Now:" + DateTime.Now);
            return;
        }
        public static void UtcNowDate () {
            Console.WriteLine ("DateTime.UtcNow:" + DateTime.UtcNow);
            return;
        }
        public static void Today () {
            Console.WriteLine ("DateTime.Today:" + DateTime.Today);
            return;
        }
        public static void GetDate () {
            Console.WriteLine ("Datevalue.Date:" + Datevalue.Date);
        }
        public static void GetDay () {
            Console.WriteLine ("Datevalue.Day:" + Datevalue.Day);
        }
        public static void GetDayOfWeek () {
            Console.WriteLine ("Datevalue.DayOfWeek:" + Datevalue.DayOfWeek);
        }
        public static void GetDayOfYear () {
            Console.WriteLine ("Datevalue.DayOfYear:" + Datevalue.DayOfYear);
        }
        public static void GetTimeOfDay () {
            Console.WriteLine ("Datevalue.TimeOfDay:" + Datevalue.TimeOfDay);
        }
        public static void GetMonth () {
            Console.WriteLine ("Datevalue.Month:" + Datevalue.Month);
        }
        public static void ShortDate () {
            Console.WriteLine ("ToShortDateString():" + Datevalue.ToShortDateString ());
            return;
        }
        public static void ShortTime () {
            Console.WriteLine ("ToShortTimeString():" + Datevalue.ToShortTimeString ());
        }
        public static void LongDate () {
            Console.WriteLine ("ToLongDateString():" + Datevalue.ToLongDateString ());
        }
        public static void LongTime () {
            Console.WriteLine ("ToLongTimeString():" + Datevalue.ToLongTimeString ());
        }
        public static void LocalTime () {
            Console.WriteLine ("ToLocalTime():" + Datevalue.ToLocalTime ());
        }
        public static void UniversalTime () {
            Console.WriteLine ("ToUniversalTime():" + Datevalue.ToUniversalTime ());
        }
        public new static void ToString () {
            Console.WriteLine ("ToString():" + Datevalue.ToString ());
        }
        public static void ToString (string str) {
            Console.WriteLine ("ToString():" + Datevalue.ToString (str));
        }

        public static void OutPut () {
            Datevalue = DateTime.Now;
            NowDate ();
            UtcNowDate ();
            Today ();
            GetDate ();
            GetDay ();
            GetDayOfWeek ();
            GetDayOfYear ();
            GetTimeOfDay ();
            GetMonth ();
            ShortDate ();
            ShortTime ();
            LongDate ();
            LongTime ();
            LocalTime ();
            UniversalTime ();
            ToString ();
            ToString ("yyyyMMddHHmmss");
        }
    }
}