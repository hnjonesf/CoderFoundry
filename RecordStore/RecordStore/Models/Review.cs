﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace RecordStore.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        public int AlbumId { get; set; }

        [Required]
        [Display(Name="Review Title")]
        [MaxLength(60)]
        public string Title { get; set; }

        [MaxLength(4250)]
        [Display(Name = "Review Contents")]
        public string Contents { get; set; }

        [Display(Name = "Created or Saved")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTimeOffset CreatedDate { get; set; }

        public virtual Album Album { get; set; }
    }
}