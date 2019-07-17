using System;

namespace CCAS.VModels
{
    public class Project
    {
        public string ProjectNo { get; set; }
        public string System { get; set; }
        public string Describe { get; set; }
        public string Status { get; set; }
        public string Resultion { get; set; }
        public string IsFinish { get; set; }
        public string Created_user { get; set; }
        public decimal Customerid { get; set; }
        public DateTime? Created_Date { get; set; }
    }
}
