using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class Abonament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AbonamentType Type { get; set; }
        [NotMapped]
        public List<int> Constraints { get; set; }
        public int CompanyId { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped]
        public List<Cards> ClientAbonaments { get; set; }
       
    }
}
