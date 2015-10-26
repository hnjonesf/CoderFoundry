using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountsAtAGlance.Models
{
    public class Car
    {
        public Car()
        {
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }


        public string Model { get; set; }
        public string Trim { get; set; }

        [DataType(DataType.Currency)]
        public double Cost { get; set; }

        //navigation
        public virtual ICollection<Comment> Comments { get; set; }
    }
}