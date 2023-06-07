using System;
using System.Collections.Generic;

namespace WebApplication6.Models
{
    public partial class Products
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int? ProductPrice { get; set; }
        public int? ProductStock { get; set; }
    }
}
