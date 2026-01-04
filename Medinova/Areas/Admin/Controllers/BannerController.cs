using Medinova.DTOs.BannerDtos;
using Medinova.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Medinova.Areas.Admin.Controllers
{
    public class BannerController : Controller
    {
        MedinovaContext _context = new MedinovaContext();


        // GET: Admin/Banner
        public ActionResult Index()
        {
            var banner = _context.Banners.ToList();
            var value = MvcApplication.Mapper.Map<List<ResultBannerDto>>(banner);
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateBanner()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateBanner(CreateBannerDto dto)
        {
            var banner = MvcApplication.Mapper.Map<Banner>(dto);
            _context.Banners.Add(banner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> UpdateBanner(int id)
        {
            var banner = await _context.Banners.FindAsync(id);
            var result = MvcApplication.Mapper.Map<ResultBannerDto>(banner);
            return View(result);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateBanner(UpdateBannerDto dto)
        {
            var banner = await _context.Banners.FindAsync(dto.BannerId);
            MvcApplication.Mapper.Map(dto, banner);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> DeleteBanner(int id)
        {
            var banner = await _context.Banners.FindAsync(id);
            _context.Banners.Remove(banner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}