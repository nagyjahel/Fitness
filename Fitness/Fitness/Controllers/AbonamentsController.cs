using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class AbonamentsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AbonamentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var model = await _context.Abonaments.ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            var model = new AbonamentViewModel()
            {
            };
            
            model.AccessDays = GetSelectListItems();
            ViewBag.Title = "Új bérlet hozzáadása";
            ViewBag.Action = nameof(Add);
            return View("Add", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AbonamentViewModel model)
        {
            var accessDays = GetAccessDays(model.AccessDays);
            Abonament abonament = new Abonament()
            {
                Name = model.Abonament.Name,
                Description = model.Abonament.Description,
                Type = model.Abonament.Type,
                CompanyId = 1,
                Constraints = accessDays,
                StartDate = model.Abonament.StartDate,
                EndDate = model.Abonament.EndDate,
                AccessLimit = model.Abonament.AccessLimit,
                StartTime = model.Abonament.StartTime,
                EndTime = model.Abonament.EndTime,
                AccessLimitPerDay = model.Abonament.AccessLimitPerDay,
                IsDeleted = false
            };

            _context.Abonaments.Add(abonament);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.Abonaments.FirstOrDefaultAsync(x => x.Id == id);
            var modelView = new AbonamentViewModel()
            {
                Abonament = model
            };
            modelView.AccessDays = GetNewSelectListItems(model.Constraints);
            ViewBag.Title = "Bérlet szerkesztése";
            ViewBag.Action = nameof(Edit);
            return View("Edit", modelView);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AbonamentViewModel model)
        {

            var accessDays = GetAccessDays(model.AccessDays);
            var abonamentFromDb = await _context.Abonaments.FirstOrDefaultAsync(x => x.Id == model.Abonament.Id);
            
            abonamentFromDb.Name = model.Abonament.Name;
            abonamentFromDb.Description = model.Abonament.Description;
            abonamentFromDb.Type = model.Abonament.Type;
            abonamentFromDb.CompanyId = 1;
            abonamentFromDb.Constraints = accessDays;
            abonamentFromDb.StartDate = model.Abonament.StartDate;
            abonamentFromDb.EndDate = model.Abonament.EndDate;
            abonamentFromDb.AccessLimit = model.Abonament.AccessLimit;
            abonamentFromDb.StartTime = model.Abonament.StartTime;
            abonamentFromDb.EndTime = model.Abonament.EndTime;
            abonamentFromDb.AccessLimitPerDay = model.Abonament.AccessLimitPerDay;
            abonamentFromDb.IsDeleted = model.Abonament.IsDeleted;
            

             _context.Abonaments.Update(abonamentFromDb);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> GetSelectListItems()
        {
            var selectList = new List<SelectListItem>();

            // Get all values of the Industry enum
            var enumValues = Enum.GetValues(typeof(Enums.AccesDays)) as Enums.AccesDays[];
            if (enumValues == null)
                return null;

            foreach (var enumValue in enumValues)
            {
                selectList.Add(new SelectListItem
                {
                    Value = enumValue.ToString(),
                    Text = GetDayName(enumValue)
                });
            }

            return selectList;
        }

        private List<SelectListItem> GetNewSelectListItems(String days)
        {
            var selectList = new List<SelectListItem>();
            var accessDays = days.Split(',').ToArray();
            var enumValues = Enum.GetValues(typeof(Enums.AccesDays)) as Enums.AccesDays[];
            if (enumValues == null)
                return null;

            foreach (var enumValue in enumValues)
            {
                var nameOfTheDay = GetDayName(enumValue);
                var selected = false;
                if (accessDays.Contains(enumValue.ToString()))
                {
                    selected = true;
                }
                selectList.Add(new SelectListItem
                {
                    Value = enumValue.ToString(),
                    Text = GetDayName(enumValue),
                    Selected = selected
                });

            }

            return selectList;
        }

        private string GetDayName(Enums.AccesDays day)
        {
            // Get the MemberInfo object for supplied enum value
            var memberInfo = day.GetType().GetMember(day.ToString());
            if (memberInfo.Length != 1)
                return null;

            // Get DisplayAttibute on the supplied enum value
            var displayAttribute = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false)
                                   as DisplayAttribute[];
            if (displayAttribute == null || displayAttribute.Length != 1)
                return null;

            return displayAttribute[0].Name;
        }

        private String GetAccessDays(List<SelectListItem> list)
        {
            var accessDays = "";
            foreach (var item in list)
            {
                if (item.Selected == true)
                {
                    accessDays += item.Value + ",";
                }
            }
            return accessDays;
        }
    }
}
