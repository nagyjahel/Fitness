using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class Enums
    {
        public enum AbonamentType : byte
        {
            [Display(Name = "Időszakos bérlet")]
            Periodic,

            [Display(Name = "Belépésszám korlátozott bérlet")]
            AccessLimit,

            [Display(Name = "Kombinált bérlet")]
            Combined
        }

        public enum AccesDays : byte
        {

            [Display(Name = "Hétfő")]
            Monday,
            [Display(Name = "Kedd")]
            Tuesday,
            [Display(Name = "Szerda")]
            Wednesday,
            [Display(Name = "Csütörtök")]
            Thursday,
            [Display(Name = "Péntek")]
            Friday,
            [Display(Name = "Szombat")]
            Saturday,
            [Display(Name = "Vasárnap")]
            Sunday
        }
    }
}
