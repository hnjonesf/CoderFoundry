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
    
    public partial class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public decimal AbsAmount { get; set; }
        public decimal ReconciledAmount { get; set; }
        public decimal AbsReconciledAmount { get; set; }
        public System.DateTimeOffset Date { get; set; }
        public string Description { get; set; }
        public System.DateTimeOffset Updated { get; set; }
        public int UpdatedByUserId { get; set; }
        public int CategoryId { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
    }
}
