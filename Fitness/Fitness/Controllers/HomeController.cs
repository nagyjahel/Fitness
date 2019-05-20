using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fitness.Models;
using Fitness.Data;
using Microsoft.EntityFrameworkCore;

namespace Fitness.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(int cardId)
        {
            var card = _context.Cards.Find(cardId);
            if (card == null) return Index();

            var user = _context.FitnessUsers.Find(card.UserId);
            if (user == null) return NotFound();

            var abonamentsOnCard = _context.AbonamentsOnCard.Where(a => a.CardId == card.Id).ToList();
            List<Abonament> abonaments = new List<Abonament>();
            foreach(var abonamentOnCard in abonamentsOnCard)
            {
                abonaments.Add(_context.Abonaments.Find(abonamentOnCard.AbonamentId));
            }
            card.Abonaments = abonaments;

            return View("Card", new CardViewModel()
            {
                User = user,
                Card = card,
            });
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { Id = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
