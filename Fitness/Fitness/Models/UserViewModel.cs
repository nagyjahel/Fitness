﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public List<CardViewModel> Cards { get; set; }
    }
}
