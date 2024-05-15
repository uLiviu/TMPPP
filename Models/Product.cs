using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public enum ProductType
    {
        DigitalClock,
        PortableRadio,
        PocketCalculator,
        Smartphone,
        Smartwatch,
        Tablet,
        Headphones,
        Keyboard,
        Mouse
    }

    public class Product
    {
        public int Id { get; set; }
        [BindProperty]
        public ProductType ProductType { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = "";
        [MaxLength(100)]
        public string Brand { get; set; } = "";
        [MaxLength(100)]
        public string Category { get; set; } = "";
        [Precision(16, 2)]
        public virtual decimal Price { get; set; }
        public int Warranty { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; } = "";
        [MaxLength(100)]
        public string ImageFileName { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdated { get; set; }
        public int StockCount {  get; set; }
        public List<Review>? Reviews { get; set; }
        public List<UserProduct>? UserProducts { get; set; }

    }
}
