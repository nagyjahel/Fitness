﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CompanyType Type { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public List<Abonament> Abonaments;
    }
}
