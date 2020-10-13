using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CampingWorld.Web.Application.Helpers;

namespace CampingWorld.Web.Application.Models
{
    public class ProductModel
    {


        [Display(Name = "Product ID")]
        public int ProductId { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Quantity Sold")]
        public int QuantitySold { get; set; }
        public decimal Revenue { get; set; }
        public decimal Profit { get; set; }
    }

    public enum ProductSortBy
    {
        [Description("Quantity Sold")]
        QuantitySold = 1,
        [Description("Revenue")]
        Revenue = 2,
        [Description("Profit")]
        Profit = 3
    }
}
