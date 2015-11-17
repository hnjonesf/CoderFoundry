using System;
using SquadClock.Models;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SquadClock.Models
{
    public class Company
    {
        //Constructor
        public Company()
        {
            Departments = new HashSet<Department>();
            Managers = new HashSet<Manager>();
            Jobs = new HashSet<Job>();
        }


        [Key]
        public int Id { get; set; }

        //Foreign Keys
        public int SettingId { get; set; }

        //Company Owner
        public string ApplicationUserId { get; set; }

        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        public string Email { get; set; }

        //Billing
        public string BillingName { get; set; }
        public string BillingAddress1 { get; set; }
        public string BillingAddress2 { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingZip { get; set; }
        public string BillingCountry { get; set; }
        public string BillingContactName { get; set; }
        public string BillingPhone { get; set; }
        public string BillingNotes { get; set; }
        public string BillingEmail { get; set; }

        //Navigation Properties
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}