using System;
using System.Collections.Generic;

namespace CSharp {
    class MethodTest {

       //方法重载测试，控制台应用程序里这样写是可以的，但在weby应用的控制器里这样写就不行了,需要将同名方法中的一个修改为internal
        internal string Usp_get_next_no()
        {
            //return ApiClient.Invoke("Repository", "Usp_get_next_no", null, false);
            return "1";
        }
        public string Usp_get_next_no(string DbType)
        {
            if (string.IsNullOrEmpty(DbType))
                //return ApiClient.Invoke("Repository", "Usp_get_next_no", "", false);
                return "2";
            else
                //return ApiClient.Invoke("Repository", "Usp_get_next_no", DbType, false);
                return "3";
        }
    }
}
