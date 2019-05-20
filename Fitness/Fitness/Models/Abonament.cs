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
        public int Id { get; set; }
        [Display(Name = "Bérlet neve")]
        public string Name { get; set; }
        [Display(Name = "Bérlet leírása")]
        public string Description { get; set; }
        [Display(Name = "Bérlet típusa")]
        public Enums.AbonamentType Type { get; set; }
        public String Constraints { get; set; }
        [Display(Name = "Mettől")]
        public Nullable<DateTime> StartDate { get; set; }
        [Display(Name = "Meddig")]
        public Nullable<DateTime> EndDate { get; set; }
        [Display(Name = "Hánytól")]
        public Nullable<TimeSpan> StartTime { get; set; }
        [Display(Name = "Hányig")]
        public Nullable<TimeSpan> EndTime { get; set; }
        [Display(Name = "Belépések maximális száma naponta")]
        public int AccessLimitPerDay { get; set; }
        [Display(Name = "Belépések maximális száma")]
        public int AccessLimit { get; set; }
        public int CompanyId { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped]
        public int CardId { get; set; }
        public List<Cards> ClientAbonaments { get; set; }
       
    }
}
