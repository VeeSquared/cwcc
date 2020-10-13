﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CampingWorld.Core.Models
{
    /// <summary>
    /// Represents base grandnode entity model
    /// </summary>
    public partial class BaseEntityModel : BaseModel
    {
        /// <summary>
        /// Gets or sets model identifier
        /// </summary>
        public virtual string Id { get; set; }
    }
}
