using Medinova.DTOs.DepartmenDtos;
using Medinova.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Medinova.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class DepartmenController : Controller
    {
        MedinovaContext _context = new MedinovaContext();
        // GET: Admin/Departmen
        public async Task<ActionResult> Index()
        {
            var depart = await _context.Departmens.ToListAsync();
            var result = MvcApplication.Mapper.Map<List<ResultDepartmenDto>>(depart);
            return View(result);
        }

        [HttpGet]
        public ActionResult CreateDepartmen()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateDepartmen(CreateDepartmenDto dto)
        {
            var depart = MvcApplication.Mapper.Map<Departmen>(dto);
            _context.Departmens.Add(depart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> UpdateDepartmen(int id)
        {
            var depart = await _context.Departmens.FindAsync(id);
            var result = MvcApplication.Mapper.Map<ResultDepartmenDto>(depart);
            return View(result);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateDepartmen(UpdateDepartmenDto dto)
        {
            var depart = await _context.Departmens.FindAsync(dto.DepartmenId);
            MvcApplication.Mapper.Map(dto, depart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> DeleteDepartmen(int id)
        {
            var depart = await _context.Departmens.FindAsync(id);
            _context.Departmens.Remove(depart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}