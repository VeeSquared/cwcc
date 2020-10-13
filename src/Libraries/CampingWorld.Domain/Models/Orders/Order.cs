using System;
using System.Collections.Generic;
using System.Text;

namespace CampingWorld.Domain.Models
{
    public class Order
    {
       // private ICollection<OrderLine> _orderLines;

        #region Properties
        /// <summary>
        /// Gets or sets the order identifier
        /// </summary
        public int OrderID { get; set; }

        /// <summary>
        /// Gets or sets the order date
        /// </summary
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary
        public int CustomerID { get; set; }

        /// <summary>
        /// Gets or sets order lines
        /// </summary>
        /*public virtual ICollection<OrderLine> OrderLines
        {
            get { return _orderLines ?? (_orderLines = new List<OrderLine>()); }
            protected set { _orderLines = value; }
        }*/
        #endregion
    }
}
