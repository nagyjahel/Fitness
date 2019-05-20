using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class Cards
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public List<Abonament> Abonaments { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
