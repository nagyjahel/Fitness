using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public Card Cards { get; set; }
        public Abonament NewAbonament { get; set; }
        public List<Abonament> Abonaments { get; set; }
        public List<SelectListItem> AllBasicAbonaments { get; set; }
    }
}
