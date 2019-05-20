using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.Data;
using Fitness.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fitness.Controllers
{
    public class ClientsController : Controller
    {
        // GET: /<controller>/
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.FitnessUsers.ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            var model = new User()
            {
            };

            ViewBag.Title = "Ügyfél regisztrálása";
            ViewBag.Action = nameof(Add);
            return View("Add", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(User model)
        {
            var user = model;
            _context.FitnessUsers.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Profile(int id)
        {
            var model = await _context.FitnessUsers.FirstOrDefaultAsync(x => x.UserId == id);
            var cards = await _context.Cards.Where(x => x.UserId == id).ToListAsync();
            List<CardViewModel> cardsList = new List<CardViewModel>();
            foreach(var card in cards)
            {
                var abonaments = _context.Abonaments.Where(x => x.CardId == card.Id).ToListAsync();
                var cardViewModel = new CardViewModel()
                {
                    Card = card,
                    Abonaments = abonaments.Result
                };
                cardsList.Add(cardViewModel);
            }

            var userView = new UserViewModel()
            {
                User = model,
                Cards = cardsList
            };

            ViewBag.Title = "Profil oldal";
            ViewBag.Action = nameof(Profile);
            return View("Profile", userView);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(AbonamentViewModel model)
        {

            //var accessDays = GetAccessDays(model.AccessDays);
            //var abonamentFromDb = await _context.Abonaments.FirstOrDefaultAsync(x => x.Id == model.Abonament.Id);

            //abonamentFromDb.Name = model.Abonament.Name;
            //abonamentFromDb.Description = model.Abonament.Description;
            //abonamentFromDb.Type = model.Abonament.Type;
            //abonamentFromDb.CompanyId = 1;
            //abonamentFromDb.Constraints = accessDays;
            //abonamentFromDb.StartDate = model.Abonament.StartDate;
            //abonamentFromDb.EndDate = model.Abonament.EndDate;
            //abonamentFromDb.AccessLimit = model.Abonament.AccessLimit;
            //abonamentFromDb.StartTime = model.Abonament.StartTime;
            //abonamentFromDb.EndTime = model.Abonament.EndTime;
            //abonamentFromDb.AccessLimitPerDay = model.Abonament.AccessLimitPerDay;
            //abonamentFromDb.IsDeleted = model.Abonament.IsDeleted;


            //_context.Abonaments.Update(abonamentFromDb);
            //await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
