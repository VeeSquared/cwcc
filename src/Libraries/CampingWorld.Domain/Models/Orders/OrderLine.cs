using System;
using System.Collections.Generic;
using System.Text;
using CampingWorld.Domain.Models;

namespace CampingWorld.Domain.Models
{
    public class OrderLine
    {
        /// <summary>
        /// Gets or sets the order line identifier
        /// </summary
        public int OrderLineID { get; set; }

        /// <summary>
        /// Gets or sets the order quantity
        /// </summary
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the product identifier
        /// </summary
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the order identifier
        /// </summary
        public int OrderID { get; set; }

    }
}
