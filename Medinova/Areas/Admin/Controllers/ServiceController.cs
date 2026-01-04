using Medinova.DTOs.ServiceDtos;
using Medinova.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Medinova.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        MedinovaContext _context = new MedinovaContext();
        // GET: Admin/Service
        public async Task<ActionResult> Index()
        {
            var service = await _context.Services.ToListAsync();
            var result = MvcApplication.Mapper.Map<List<ResultServiceDto>>(service);
            return View(result);
        }

        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateService(CreateServiceDto dto)
        {
            var service = MvcApplication.Mapper.Map<Service>(dto);
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> UpdateService(int id)
        {
            var service = await _context.Services.FindAsync(id);
            var result = MvcApplication.Mapper.Map<ResultServiceDto>(service);
            return View(result);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateService(UpdateServiceDto dto)
        {
            var service = await _context.Services.FindAsync(dto.ServiceId);
            MvcApplication.Mapper.Map(dto, service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> DeleteService(int id)
        {
            var service = await _context.Services.FindAsync(id);
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}