using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;

namespace Squadclock.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public int DepartmentId { get; set; }

        public int JobId { get; set; }

        public int ManagerId { get; set; }

        public string FirstName { get; set;}
        public string LastName { get; set; }
        public string EmployeeEmail { get; set; }
        public bool Active { get; set; }
        public string EmployeePassword { get; set; }
        public double EmployeeTimezone { get; set; }
        public bool AllowChangePassword { get; set; }
        
        //Navigation Properties
        public virtual ICollection<Shift> Shifts { get; set; }

        //Constructor
        public Employee()
        {
            this.Shifts = new HashSet<Shift>();
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}