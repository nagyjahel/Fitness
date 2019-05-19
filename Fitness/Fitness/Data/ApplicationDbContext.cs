using System;
using System.Collections.Generic;
using System.Text;
using Fitness.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fitness.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
          
        }
        public DbSet<Abonament> Abonaments { get; set; }
        public DbSet<AbonamentType> AbonamentTypes { get; set; }
        public DbSet<Cards> Cards { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<Entrance> Entrances { get; set; }
        public DbSet<ErrorViewModel> ErrorViewModels { get; set; }
        public DbSet<User> FitnessUsers { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

    }
}
