using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountsAtAGlance.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CommentBody { get; set; }

        //navigation
        public virtual Car Car { get; set; }

    }
}