using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class BasicAbonament
    {
        public int Id { get; set; }
        [Display(Name = "Bérlet neve")]
        public string Name { get; set; }
        [Display(Name = "Bérlet leírása")]
        public string Description { get; set; }
        [Display(Name = "Bérlet típusa")]
        public Enums.AbonamentType Type { get; set; }
        public String Constraints { get; set; }
        [Display(Name = "Belépések maximális száma naponta")]
        public int AccessLimitPerDay { get; set; }
        public int CompanyId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
