using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SquadClock.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [Display(Name="Start Scheduled")]
        [DataType(DataType.DateTime)]
        public DateTimeOffset ScheduleIn { get; set; }

        [Display(Name = "Finish Scheduled")]
        [DataType(DataType.DateTime)]
        public DateTimeOffset ScheduleOut { get; set; }

        [Display(Name = "Time Scheduled")]
        public double HoursScheduled { get; set; }

        [Display(Name = "Schedule Notes")]
        public string Notes { get; set; }
        public string Log { get; set; }
        public int ShiftId { get; set; }

    }
}