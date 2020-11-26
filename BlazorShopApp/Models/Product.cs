using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShopApp.Models
{
    public class Product
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductCode { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }
        public int ItemNumber { get; set; }
        public string Supplier { get; set; }
        //public double Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
