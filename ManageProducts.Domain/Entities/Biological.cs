﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageProducts.Domain.Entities
{
    public class Biological:Product
    {
        public string Herbs { get; set; }
        public Biological() {
        }
    }
}
