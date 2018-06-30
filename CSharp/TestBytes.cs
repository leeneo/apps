using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp {
    class TestBytes
    {
        public static Byte[] GetBytes (string text) {

            Byte[] outBytes = Encoding.ASCII.GetBytes(text);
            for (var i = 0; i < outBytes.Length; i++)
            {
                outBytes[i]++;
            }
            return outBytes;
        }

        public static string GetByteStr(string text)
        {
            var str = "";
            var by = GetBytes(text);
            foreach (var i in by)
            {
                str += i + "-";
            }
            return str;
        }

        public static string GetStr(Byte[] b)
        {
            for (var i = 0; i < b.Length; i++)
            {
                b[i]--;
                Console.WriteLine("ByteToStr:" + b[i]);
            }
            return Encoding.ASCII.GetString(b);
        }

        public static string GetStr(string str)
        {
            String[] chars=str.Split('-');
            List<string> array = new List<string>(chars);
            //Console.WriteLine("length:"+chars.Length);
            array.RemoveAt(chars.Length-1);
            chars = array.ToArray();
            //Console.WriteLine("newlength:" + chars.Length);

            List<byte> bytesArray = new List<byte>();
            foreach (var i in chars)
            {
                bytesArray.Add(Convert.ToByte(i));
            }
            Byte[] bytes = bytesArray.ToArray();
            return GetStr(bytes);
        }
    }
}