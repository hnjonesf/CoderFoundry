using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SquadClock.Models
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public string LocalTimeZone { get; set; }
        public string PayPeriodType { get; set; }
        public DateTimeOffset PayPeriodStartDate { get; set; }
        public int PunchRoundingMinutes { get; set; }
        public bool PunchLog { get; set; }
        public bool PunchApproval { get; set; }
        public bool GroupPunch { get; set; }
        public bool MultiLanguage { get; set; }
        public string LogoURL { get; set; }
        public string GlobalMessage { get; set; }
        public bool RememberMeAdmin { get; set; }
        public bool RememberMeManager { get; set; }
        public bool RememberMeEmployee { get; set; }

        //Navigation
        public virtual Company Company { get; set; }
    }
}