using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapidDeployMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeFullName { get; set; }
        public decimal HourlyPayRate { get; set; }
    }
}