using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecordStore.Models
{
    public class Album
    {
        //constructor with hash to Reviews
        //public Album()
        //{
        //    this.Reviews = new HashSet<Review>();
        //}

        [Key]
        public int AlbumId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Album Name")]
        public string Name { get; set; }

        public virtual Artist Artist { get; set; }


    }
}