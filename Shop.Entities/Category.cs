﻿using System.Collections.Generic;

namespace Shop.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Product> ProductsInCategory { get; set; }

    }
}