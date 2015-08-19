using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;

namespace SquadClock.Models
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Display(Name = "Manager Title")]
        [Range(0, 50)]
        public string ManagerTitle { get; set; }

        //Navigation
        public virtual Company Company { get; set; }
    }
}