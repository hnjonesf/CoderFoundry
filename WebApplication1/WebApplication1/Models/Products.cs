using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Display(Name="Product Name")]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.00}")]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset InventoryDate { get; set; }
    }
}