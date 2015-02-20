using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string CustomerCode { get; set; }
        public double Amount { get; set; }
    }
}