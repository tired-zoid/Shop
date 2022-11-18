using Microsoft.EntityFrameworkCore;
using System;

namespace Shop.Entities
{
    [Index(nameof(Article), IsUnique = true)]
    public class Product 
    {
        public int Id { get; set; }

        public int Article { get; set; } 

        public string Name { get; set; }

        public int Price { get; set; }

        public string Img { get; set; }

        public int ProductQuantity { get; set; }

        public int CategoryId { get; set; }

        public Category Category { set; get; }

    }
}
