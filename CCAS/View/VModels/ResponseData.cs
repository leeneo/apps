using System;

namespace CCAS.VModels
{
    public class ResponseData<T>
    {
        public bool success { get; set; }
        public string msg { get; set; }
        public T data { get; set; }
    }
}
