using Medinova.DTOs.AboutDtos;
using Medinova.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Medinova.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        MedinovaContext _context = new MedinovaContext();

        // GET: Admin/About
        public async Task<ActionResult> Index()
        {
            var abouts = await _context.Abouts.ToListAsync();
            var result = MvcApplication.Mapper.Map<List<ResultAboutDto>>(abouts);
            return View(result);
        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateAbout(CreateAboutDto dto)
        {
            var about = MvcApplication.Mapper.Map<About>(dto);
            _context.Abouts.Add(about);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> UpdateAbout(int id)
        {
            var about = await _context.Abouts.FindAsync(id);
            var result = MvcApplication.Mapper.Map<ResultAboutDto>(about);
            return View(result);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateAbout(UpdateAboutDto dto)
        {
            var about = await _context.Abouts.FindAsync(dto.AboutId);
            MvcApplication.Mapper.Map(dto, about);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> DeleteAbout(int id)
        {
            var about = await _context.Abouts.FindAsync(id);
            _context.Abouts.Remove(about);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}