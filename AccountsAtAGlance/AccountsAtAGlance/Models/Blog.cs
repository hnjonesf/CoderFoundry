using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountsAtAGlance.Models
{
    public class Blog
    {
        //Constructor
        public Blog()
        {
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Body { get; set; }

        //foreign keys
        public int CommentId { get; set; }

        //navigation property
        public virtual ICollection<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CommentBody { get; set; }

        //navigation
        public virtual Blog Blog { get; set; }

    }
}