using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;

namespace SquadClock.Models
{
    public class Shift
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmployeeId { get; set; }
        public DateTimeOffset ClockIn { get; set; }
        public DateTimeOffset ClockOut { get; set; }
        public double HoursWorked { get; set; }
        public string ShiftDepartment { get; set; }
        public string ShiftManager { get; set; }
        public string ShiftJob { get; set; }
        public bool ManualTimeEntry { get; set; }
        public string Notes { get; set; }
        public string Log { get; set; }

        //Navigation
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}