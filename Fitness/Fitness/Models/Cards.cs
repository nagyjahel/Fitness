using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class Cards
    {
        public int CardNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public int AbonamentId { get; set; }
        public int NumberOfRemainingEntrances { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
