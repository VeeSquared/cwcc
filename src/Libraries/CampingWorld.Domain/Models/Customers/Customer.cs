using System;
using System.Collections.Generic;
using System.Text;

namespace CampingWorld.Domain.Models
{
    public class Customer
    {
        #region Properties
        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary
        public int CustomerID { get; set; }


        /// <summary>
        /// Gets or sets the customer first name
        /// </summary
        public string FirstName { get; set; }


        /// <summary>
        /// Gets or sets the customer last name
        /// </summary
        public string LastName { get; set; }
        #endregion
    }
}
