using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using CampingWorld.Web.Application.Helpers;

namespace CampingWorld.Web.Application.Models
{
    public class ReceiptModel
    {
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the product name
        /// </summary
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the product cost
        /// </summary
        public decimal Cost { get; set; }

        /// <summary>
        /// Gets or sets the order line identifier
        /// </summary
        public decimal Price { get; set; }

        public decimal ExtendedPrice { get; set; }

        public decimal Quantity { get; set; }

        public DateTime OrderDate { get; set; }

        public int OrderID { get; set; }

        public string CustomerName { get; set; }

        public decimal Total { get; set; }


    }

}
