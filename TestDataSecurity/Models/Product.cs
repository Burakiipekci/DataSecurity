using System;
using System.Collections.Generic;

#nullable disable

namespace TestDataSecurity.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public int ProductCategoryId { get; set; }
      
    }
}
