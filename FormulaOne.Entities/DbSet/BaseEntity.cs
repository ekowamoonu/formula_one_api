﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.DbSet
{
    public class BaseEntity
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public int Status { get; set; }
    }
}
