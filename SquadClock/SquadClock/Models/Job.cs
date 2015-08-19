using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SquadClock.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Display(Name = "Job Name")]
        [Range(0, 50)]
        public string JobName { get; set; }

        //Navigation
        public virtual Company Company { get; set; }
    }
}