using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountsAtAGlance.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int CarId { get; set; }

        [Display(Name = "Comment Date")]
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Comment")]
        [StringLength(250, MinimumLength = 3, ErrorMessage =
            "Comments must be between 3 and 250 characters long.")]
        public string CommentBody { get; set; }

        //navigation
        public virtual Car Car { get; set; }

    }
}