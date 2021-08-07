using Retail.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Retail.Models
{
    public class empdetaillist
    {
        public string EmployeeName { get; set; }
        public string Date { get; set; }
        public string Shift { get; set; }
        public string Hrs_Worked { get; set; }
        public int Revenue { get; set; }
    }
}