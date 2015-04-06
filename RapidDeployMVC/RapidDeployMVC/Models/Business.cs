using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapidDeployMVC.Models
{
    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAddess { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}