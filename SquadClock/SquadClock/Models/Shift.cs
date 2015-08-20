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

        [Display(Name="Punch In")]
        [DataType(DataType.DateTime)]
        public DateTimeOffset ClockIn { get; set; }

        [Display(Name = "Punch Out")]
        [DataType(DataType.DateTime)]
        public DateTimeOffset ClockOut { get; set; }

        public string ShiftDepartment { get; set; }
        public string ShiftManager { get; set; }
        public string ShiftJob { get; set; }

        [Display(Name = "Time Worked")]
        public double HoursWorked { get; set; }
        public bool ManualTimeEntry { get; set; }

        [Display(Name = "Shift Notes")]
        public string Notes { get; set; }
        public double OvertimeHours1 { get; set; }
        public double OvertimeHours2 { get; set; }
        public double HolidayHours { get; set; }
        public double PTOHours { get; set; }
        public double VacationHours { get; set; }
        public string Log { get; set; }

        //Navigation
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }

    }
}