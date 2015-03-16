using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalTemplate.Models.DataModels
{
    public class Budget
    {
        public int Id { get; set; }
        public string HouseHold { get; set; }
        public int CategoryId { get; set; }
        public string Amount { get; set; }
    }
}