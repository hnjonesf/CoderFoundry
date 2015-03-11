using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalTemplate.Models.DataModels
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Household {get; set;}
        public decimal Amount { get; set; }
        public bool Reconciled {get; set;}
        public DateTimeOffset Date { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Updated { get; set; }
        public int UpdatedByUserId { get; set; }
        public string Category { get; set; }
    }

}
