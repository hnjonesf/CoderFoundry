//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalTemplate
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public Account()
        {
            this.Transactions = new HashSet<Transaction>();
        }
    
        public int Id { get; set; }
        public int HouseHoldId { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal ReconciledBalance { get; set; }
        public int UserId { get; set; }
    
        public virtual Household Household { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}