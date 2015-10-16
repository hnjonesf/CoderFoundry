using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountsAtAGlance.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public double Cost { get; set; }
    }
}