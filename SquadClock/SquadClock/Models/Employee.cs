using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;

namespace SquadClock.Models
{
    public class Employee
    {
        //Eliminate Employee, and move to ApplicationUser using roles: Administrator, Owner, Manager, Employee
        [Key]
        public int Id { get; set; }

        //Foreign Keys
        public int? CompanyId { get; set; }
        public int? DepartmentId { get; set; }
        public int? ManagerId { get; set; }
        public int? JobId { get; set; }

        //Constructor
        public Employee()
        {
            this.Shifts = new HashSet<Shift>();
        }

        public string FirstName { get; set;}
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }
        public double Timezone { get; set; }
        public bool AllowChangePassword { get; set; }
        
        //Navigation Properties
        public virtual Company Company { get; set; }
        public virtual Department Department { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Job Job { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
        //FUTUREpublic virtual ICollection<Schedule> Schedules { get; set; }

        //Methods
        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}