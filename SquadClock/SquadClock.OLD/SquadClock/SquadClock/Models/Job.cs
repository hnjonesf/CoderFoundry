using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Squadclock.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public string JobName { get; set; }
    }
}