using System;
using System.Collections.Generic;

namespace CSharp {
    class StringFormat {

        public static void OutPut () {
            var date = DateTime.Now;
            Console.WriteLine ("string.Format(\"{0:N2}\",1246.9)    ==>    数字 " + string.Format ("{0:N2}", 1246.9));
            Console.WriteLine ("string.Format(\"{0:N2}\",124.69)    ==>    数字 " + string.Format ("{0:N2}", 124.69));
            Console.WriteLine ("string.Format(\"{0:N1}\",124.69)    ==>    数字 " + string.Format ("{0:N1}", 124.69));
            Console.WriteLine ("string.Format(\"{0:N0}\",124.69)    ==>    数字 " + string.Format ("{0:N0}", 124.69));
            Console.WriteLine ("string.Format(\"{0:F2}\",124.69)    ==>    数字 " + string.Format ("{0:F2}", 124.69));
            Console.WriteLine ("string.Format(\"{0:F1}\",124.69)    ==>    数字 " + string.Format ("{0:F1}", 124.69));
            Console.WriteLine ("string.Format(\"{0:F0}\",124.69)    ==>    数字 " + string.Format ("{0:F0}", 124.69) + "\n");

            Console.WriteLine ("string.Format(\"{0:C2}\",124.69)    ==>    货币 " + string.Format ("{0:C2}", 124.69));
            Console.WriteLine ("string.Format(\"{0:C4}\",124.69)    ==>    货币 " + string.Format ("{0:C4}", 124.69));
            Console.WriteLine ("string.Format(\"￥{0:N2}\",124.69)  ==>    货币 " + string.Format ("￥{0:N2}", 124.69));
            Console.WriteLine ("string.Format(\"${0:N2}\",124.69)   ==>    货币 " + string.Format ("${0:N2}", 124.69) + "\n");

            Console.WriteLine ("string.Format(\"{0:E3}\",124.69)    ==>    科学计数 " + string.Format ("{0:E3}", 124.69));
            Console.WriteLine ("string.Format(\"{0:X}\",124.69)     ==>    十六进制 " + string.Format ("{0:X}", 250));
            Console.WriteLine ("string.Format(\"{0:x}\",124.69)     ==>    十六进制 " + string.Format ("{0:x}", 250));
            Console.WriteLine ("string.Format(\"{0:X}\",0xffff)     ==>    十六进制 " + string.Format ("{0:X}", 0xffff));
            Console.WriteLine ("string.Format(\"{0:x}\",0xffff)     ==>    十六进制 " + string.Format ("{0:x}", 0xffff));
            Console.WriteLine ("string.Format(\"{0:P}\",0.12469)    ==>    百分数 " + string.Format ("{0:P}", 0.12469) + "\n");

            Console.WriteLine ("string.Format(\"{0:D}\",date)       ==>    日期 " + string.Format ("{0:D}", date));
            Console.WriteLine ("string.Format(\"{0:d}\",date)       ==>    日期 " + string.Format ("{0:d}", date));
            Console.WriteLine ("string.Format(\"{0:F}\",date)       ==>    日期 " + string.Format ("{0:F}", date));
            Console.WriteLine ("string.Format(\"{0:f}\",date)       ==>    日期 " + string.Format ("{0:f}", date));
            Console.WriteLine ("string.Format(\"{0:G}\",date)       ==>    日期 " + string.Format ("{0:G}", date));
            Console.WriteLine ("string.Format(\"{0:g}\",date)       ==>    日期 " + string.Format ("{0:g}", date));
            Console.WriteLine ("string.Format(\"{0:U}\",date)       ==>    日期 " + string.Format ("{0:U}", date));
            Console.WriteLine ("string.Format(\"{0:u}\",date)       ==>    日期 " + string.Format ("{0:u}", date));
            Console.WriteLine ("string.Format(\"{0}\",date)         ==>    日期 " + string.Format ("{0}", date));
            Console.WriteLine ("string.Format(\"{0:s}\",date)       ==>    日期 " + string.Format ("{0:s}", date));
            Console.WriteLine ("string.Format(\"{0:R}\",date)       ==>    日期 " + string.Format ("{0:R}", date)+"\n");

            Console.WriteLine ("string.Format(\"{0:Y}\",date)       ==>    年份 " + string.Format ("{0:Y}", date));
            Console.WriteLine ("string.Format(\"{0:y}\",date)       ==>    年份 " + string.Format ("{0:y}", date));
            Console.WriteLine ("string.Format(\"{0:M}\",date)       ==>    月份 " + string.Format ("{0:M}", date));
            Console.WriteLine ("string.Format(\"{0:t}\",date)       ==>    时间 " + string.Format ("{0:t}", date));
            Console.WriteLine ("string.Format(\"{0:T}\",date)       ==>    时间 " + string.Format ("{0:T}", date)+"\n");

            Console.WriteLine ("string.Format(\"{0:yyyyMMddHHmmssffff}\",date)      ==>    日期 " + string.Format ("{0:yyyyMMddHHmmssffff}", date));
            Console.WriteLine ("string.Format(\"{0:yy/MM/dd}\",date)                ==>    日期 " + string.Format ("{0:yy/MM/dd}", date));
            Console.WriteLine ("string.Format(\"{0:yyyy/MM/dd}\",date)              ==>    日期 " + string.Format ("{0:yyyy/MM/dd}", date));
            Console.WriteLine ("string.Format(\"{0:yyyy/MM/dd HH:mm:ss}\",date)     ==>    日期 " + string.Format ("{0:yyyy\\/MM\\/dd HH:mm:ss}", date));

            //DatTime? 类型的 date.ToString("yyyy年MM月dd日 HH:mm:ss")无效，当date为NULL时用：string.Format ("{0:G}", date)，不会报错
            Console.WriteLine ("string.Format(\"{0:G}\",\"\")     ==>    空或NULL " + string.Format ("{0:G}", ""));

        }
    }
}