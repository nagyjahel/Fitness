using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class Entrance
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AbonamentId { get; set; }
        public DateTime EnteringTime { get; set; }
        public DateTime LeavingTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
