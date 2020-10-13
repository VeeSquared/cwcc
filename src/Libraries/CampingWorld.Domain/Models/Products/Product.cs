using System;
using System.Collections.Generic;
using System.Text;

namespace CampingWorld.Domain.Models
{
    public class Product
    {
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the product name
        /// </summary
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product cost
        /// </summary
        public decimal Cost { get; set; }

        /// <summary>
        /// Gets or sets the order line identifier
        /// </summary
        public decimal Price { get; set; }
    }
}
