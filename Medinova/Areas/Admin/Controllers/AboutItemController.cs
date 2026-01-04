using Medinova.DTOs.AboutItemDtos;
using Medinova.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Medinova.Areas.Admin.Controllers
{
    public class AboutItemController : Controller
    {
        MedinovaContext _context = new MedinovaContext();
        // GET: Admin/AboutItem
        public async Task<ActionResult> Index()
        {
            var items = await _context.AboutItems.ToListAsync();
            var result = MvcApplication.Mapper.Map<List<ResultAboutItemDto>>(items);
            return View(result);
        }

        [HttpGet]
        public ActionResult CreateAboutItems()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateAboutItems(CreateAboutItemDto dto)
        {
            var items = MvcApplication.Mapper.Map<AboutItem>(dto);
            _context.AboutItems.Add(items);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> UpdateAboutItems(int id)
        {
            var items = await _context.AboutItems.FindAsync(id);
            var result = MvcApplication.Mapper.Map<ResultAboutItemDto>(items);
            return View(result);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateAboutItems(UpdateAboutItemDto dto)
        {
            var items = await _context.AboutItems.FindAsync(dto.AboutItemId);
            MvcApplication.Mapper.Map(dto, items);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> DeleteAboutItems(int id)
        {
            var items = await _context.AboutItems.FindAsync(id);
            _context.AboutItems.Remove(items);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}