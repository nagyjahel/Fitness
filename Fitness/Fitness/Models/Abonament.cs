using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class Abonament : BasicAbonament
    {
        public int AbonamentId { get; set; }
        [Display(Name = "Mettől")]
        public Nullable<DateTime> StartDate { get; set; }
        [Display(Name = "Meddig")]
        public Nullable<DateTime> EndDate { get; set; }
        [Display(Name = "Belépések maximális száma")]
        public int AccessLimit { get; set; }
        public bool IsDeleted { get; set; }       
    }
}
