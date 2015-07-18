using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcTesting0113.Models
{
    public class Post
    {
        //constructor with hash to comments
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset Created { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? Updated { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }

        public string MediaURL { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }

    public class Comment 
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ParentPost")]
        public int PostId { get; set; }

        [ForeignKey("Author")]
        public string Authorid { get; set; }

        public string Body { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTimeOffset Created { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTimeOffset> Updated { get; set; }
        public string UpdateReason { get; set; }

        public virtual Post ParentPost { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}