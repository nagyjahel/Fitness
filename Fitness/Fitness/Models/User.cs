using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Display(Name = "Keresztnév")]
        public string LastName { get; set; }
        [Display(Name = "Családnév")]
        public string FirstName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
        public string Image { get; set; }
    }
}
