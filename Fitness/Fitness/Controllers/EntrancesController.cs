using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.Data;
using Fitness.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.Controllers
{
    public class EntrancesController : Controller
    {
        private ApplicationDbContext _context;
        public EntrancesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var entrances = _context.Entrances.ToList();
            List<EntranceViewModel> viewModels = new List<EntranceViewModel>();
            foreach(var entrance in entrances)
            {
                viewModels.Add(new EntranceViewModel()
                {
                    User = _context.FitnessUsers.Find(entrance.UserId),
                    Abonament = _context.Abonaments.Find(entrance.AbonamentId),
                    EnteringTime = entrance.EnteringTime
                });
            }
            return View(viewModels);
        }
    }
}