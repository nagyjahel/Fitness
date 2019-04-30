using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public UserType Type { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Image { get; set; }
    }
}
