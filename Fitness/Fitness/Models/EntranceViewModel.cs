using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class EntranceViewModel
    {
        public User User { get; set; }
        public Abonament Abonament { get; set; }
        public DateTime EnteringTime { get; set; }
    }
}
