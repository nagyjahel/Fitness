using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class UserType
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
