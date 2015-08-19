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
            Employees = new HashSet<Employee>();
            Departments = new HashSet<Department>();
            Managers = new HashSet<Manager>();
            Jobs = new HashSet<Job>();
        }


        [Key]
        public int Id { get; set; }

        //Foreign Keys (remove nullable after logic built into setup)
        public int? SettingId { get; set; }

        //Company Owner
        public string ApplicationUserId { get; set; }

        [Required]
        [Display(Name="Company Name")]
        [StringLength(80, ErrorMessage = "Company Name cannot be longer than 80 characters.")]
        public string Name { get; set; }

        [Display(Name = "Address First Line")]
        [StringLength(80, ErrorMessage = "Address must be between 4 and 80 characters.", MinimumLength = 4)]
        public string Address1 { get; set; }

        [Display(Name = "Address Second Line")]
        [StringLength(80, ErrorMessage = "Address cannot be longer than 80 characters.")]
        public string Address2 { get; set; }

        [Display(Name = "City")]
        [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters.")]
        public string City { get; set; }

        [Display(Name = "State")]
        [StringLength(80, ErrorMessage = "Company State must be 2 characters.", MinimumLength = 2)]
        public string State { get; set; }

        [Display(Name = "Zip")]
        [StringLength(80, ErrorMessage = "Company Zip cannot be longer than 9 characters.", MinimumLength = 5)]
        public string Zip { get; set; }

        [Display(Name = "Country")]
        [StringLength(50, ErrorMessage = "Country must be between 4 and 50 characters.", MinimumLength = 4)]
        public string Country { get; set; }

        [Display(Name = "Contact")]
        [StringLength(50, ErrorMessage = "Contact Name cannot be longer than 50 characters.")]
        public string ContactName { get; set; }

        [StringLength(25, ErrorMessage = "Phone must be between 10 and 25 characters.", MinimumLength = 10)]
        [Phone]
        public string Phone { get; set; }
        
        [Display(Name = "Company Description")]
        [StringLength(1000, ErrorMessage = "Company Description cannot be longer than 1000 characters.", MinimumLength = 0)]
        public string Notes { get; set; }

        [EmailAddress]
        [Display(Name = "Company Email")]
        public string Email { get; set; }


        //Billing
        [Display(Name = "Billing Name")]
        [StringLength(80, ErrorMessage = "Billing Name cannot be longer than 80 characters.")]
        public string BillingName { get; set; }

        [Display(Name = "Address First Line")]
        [StringLength(80, ErrorMessage = "Address must be between 4 and 80 characters.", MinimumLength = 4)]
        public string BillingAddress1 { get; set; }

        [Display(Name = "Address Second Line")]
        [StringLength(80, ErrorMessage = "Address cannot be longer than 80 characters.")]
        public string BillingAddress2 { get; set; }

        [Display(Name = "City")]
        [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters.")]
        public string BillingCity { get; set; }

        [Display(Name = "State")]
        [StringLength(80, ErrorMessage = "Billing State must be 2 characters.", MinimumLength = 2)]
        public string BillingState { get; set; }

        [Display(Name = "Zip")]
        [StringLength(80, ErrorMessage = "Billing Zip cannot be longer than 9 characters.", MinimumLength = 5)]
        public string BillingZip { get; set; }

        [Display(Name = "Country")]
        [StringLength(50, ErrorMessage = "Country must be between 4 and 50 characters.", MinimumLength = 4)]
        public string BillingCountry { get; set; }

        [Display(Name = "Contact")]
        [StringLength(50, ErrorMessage = "Contact Name cannot be longer than 50 characters.")]
        public string BillingContactName { get; set; }

        [StringLength(25, ErrorMessage = "Phone must be between 10 and 25 characters.", MinimumLength = 10)]
        [Phone]
        public string BillingPhone { get; set; }

        [Display(Name = "Special Instructions")]
        [StringLength(1000, ErrorMessage = "Billing Notes cannot be longer than 1000 characters.", MinimumLength = 0)]
        public string BillingNotes { get; set; }

        [EmailAddress]
        [Display(Name = "Billing Email")]
        public string BillingEmail { get; set; }

        //Navigation Properties
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}