﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriveEcommerce.Domain.Entities.Base;

namespace ThriveEcommerce.Domain.Entities
{
    public class Review : Entity
    {
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Comment { get; set; }
        public double Star { get; set; }
    }
}
