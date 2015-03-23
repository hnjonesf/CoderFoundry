using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalTemplate.Models.DataModels
{
    public class Accout
    {
        public int Id { get; set; }
        public string HouseHold { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal ReconciledBalance { get; set; }
    }
}