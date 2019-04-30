using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class CompanyType
    {
        public int id { get; set; }
        public int Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

    }
}
