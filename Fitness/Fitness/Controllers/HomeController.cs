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
        public IActionResult Index(int foundCard, int foundUser )
        {
            if(foundCard==-1 && foundUser == 0)
            {
                ViewBag.Error = "Nem található a megadott azonosítójú kártya. Probáld újra!";
                return View();
            }

            if(foundCard == 0 && foundUser == -1)
            {
                ViewBag.Error = "A kártyához tartozó ügyfél már nem szerepel a rendszerben!";
                return View();
            }

            return View();

        }
        [HttpPost]
        public IActionResult Index(int cardId)
        {
            
            var card = _context.Cards.Find(cardId);
            if (card == null) return Index(-1,0);

            var user = _context.FitnessUsers.Find(card.UserId);
            if (user == null) return Index(0, -1);

            var abonaments = _context.Abonaments.Include(a => a.BasicAbonament).Where(a => a.CardId == card.Id).ToList();
            
            foreach(var abonament in abonaments)
            {
                abonament.BasicAbonament = _context.BasicAbonaments.Where(b => b.Name == abonament.Name).FirstOrDefault();
            }
            card.Abonaments = abonaments;

            return View("Card", new CardViewModel()
            {
                User = user,
                Card = card,
            });
           
        }


        [HttpPost]
        [Route("Home/Entrance/{userId}/{abonamentId}")]
        public JsonResult Entrance(int userId,int abonamentId)
        {
            _context.Entrances.Add(new Entrance()
            {
                UserId = userId,
                AbonamentId = abonamentId,
                EnteringTime = DateTime.Now,
                IsDeleted = false
            });
            _context.SaveChanges();
            return Json(new
            {
                success = true,
                msg = "Successful entrance!"
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
