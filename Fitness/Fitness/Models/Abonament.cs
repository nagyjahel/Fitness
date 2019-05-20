using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class Abonament
    {
        public int BasicAbonamentId { get; set; }
        public int AbonamentId { get; set; }
        [Display(Name = "Név")]
        public string Name { get; set; }
        [Display(Name = "Mettől")]
        public Nullable<DateTime> StartDate { get; set; }
        [Display(Name = "Meddig")]
        public Nullable<DateTime> EndDate { get; set; }
        [Display(Name = "Maximális belépések száma")]
        public int AccessLimit { get; set; }
        public int CardId { get; set; }
        public bool IsDeleted { get; set; }
       
    }
}
