using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness.Data;
using Fitness.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            user.Image = "avatar.jpg";
            var card = new Card()
            {
                IsActive = true,
                IsDeleted = false,
            };
            _context.FitnessUsers.Add(user);
            await _context.SaveChangesAsync();

            card.UserId = user.UserId;
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Profile(int id)
        {
            var model = await _context.FitnessUsers.FirstOrDefaultAsync(x => x.UserId == id);
            var basicAbonaments = await _context.BasicAbonaments.ToListAsync();
            
            List<SelectListItem> allBasicAbonaments = new List<SelectListItem>();
            foreach(var item in basicAbonaments)
            {
                allBasicAbonaments.Add(new SelectListItem
                {
                    Value = item.Name,
                    Text = item.Name,
                });
            }
            var cards = await _context.Cards.Where(x => x.UserId == id)
                .FirstOrDefaultAsync();

            var abonaments = await _context.Abonaments.Where(x => x.CardId == cards.Id).ToListAsync();
            cards.Abonaments = abonaments;
            

            var userView = new UserViewModel()
            {
                User = model,
                Cards = cards,
                Abonaments = abonaments,
                AllBasicAbonaments = allBasicAbonaments,

            };

            ViewBag.Title = "Profil oldal";
            ViewData["CardId"] = cards.Id;
            ViewBag.Action = nameof(Profile);
            return View("Profile", userView);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserViewModel model)
        {

            var basicAbonament = await _context.BasicAbonaments.FirstOrDefaultAsync(x => x.Name == model.NewAbonament.Name);
            Abonament abonament = new Abonament()
            {
                Name = basicAbonament.Name,
                AccessLimit = model.NewAbonament.AccessLimit,
                IsDeleted = basicAbonament.IsDeleted,
                StartDate = model.NewAbonament.StartDate,
                EndDate = model.NewAbonament.EndDate,
                CardId = model.Cards.Id,
            };

            _context.Abonaments.Add(abonament);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Profile));
        }

        [HttpPost]
        public async Task<IActionResult> AddAbonament(UserViewModel model)
        {

            //var basicAbonament = await _context.BasicAbonaments.FirstOrDefaultAsync(x => x.Name == model.NewAbonament.Name);
            //Abonament abonament = new Abonament()
            //{
            //    Name = basicAbonament.Name,
            //    Description = basicAbonament.Description,
            //    Type = basicAbonament.Type,
            //    Constraints = basicAbonament.Constraints,
            //    AccessLimit = basicAbonament.AccessLimit,
            //    AccessLimitPerDay = basicAbonament.AccessLimitPerDay,
            //    CompanyId = basicAbonament.CompanyId,
            //    IsDeleted = basicAbonament.IsDeleted,
            //    CardId = model.Cards.Id,
            //};

            //_context.Abonaments.Add(abonament);
            //await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
