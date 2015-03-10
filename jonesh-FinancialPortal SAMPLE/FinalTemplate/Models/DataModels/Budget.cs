using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalTemplate.Models.DataModels
{
    public class Budget
    {
        public int Id { get; set; }
        public string HouseHold { get; set; }
        public decimal Apparel { get; set; }
        public decimal Food { get; set; }
        public decimal HealthCare { get; set; }
        public decimal Housing { get; set; }
        public decimal Income { get; set; }
        public decimal Investments { get; set; }
        public decimal Other { get; set; }
        public decimal Transportation { get; set; }
        public decimal Utilities { get; set; }

        public decimal ApparelT { get; set; }
        public decimal FoodT { get; set; }
        public decimal HealthCareT { get; set; }
        public decimal HousingT { get; set; }
        public decimal IncomeT { get; set; }
        public decimal InvestmentsT { get; set; }
        public decimal OtherT { get; set; }
        public decimal TransportationT { get; set; }
        public decimal UtilitiesT { get; set; }



    }
}