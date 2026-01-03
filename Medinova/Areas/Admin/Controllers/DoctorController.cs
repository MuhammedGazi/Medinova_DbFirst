using Medinova.DTOs.DoctorDtos;
using Medinova.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Medinova.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class DoctorController : Controller
    {
        MedinovaContext _context = new MedinovaContext();
        // GET: Admin/Doctor

        private async Task GetDepartman()
        {
            var departman = await _context.Departmens.ToListAsync();
            ViewBag.Departmens = new SelectList(departman, "DepartmenId", "Name");
        }
        public async Task<ActionResult> Index()
        {
            var doctor = await _context.Doctors.ToListAsync();
            var result = MvcApplication.Mapper.Map<List<ResultDoctorDto>>(doctor);
            return View(result);
        }

        [HttpGet]
        public async Task<ActionResult> CreateDoctor()
        {
            await GetDepartman();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateDoctor(CreateDoctorDto dto)
        {
            var doctor = MvcApplication.Mapper.Map<Doctor>(dto);
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> UpdateDoctor(int id)
        {
            await GetDepartman();
            var doctor = await _context.Doctors.FindAsync(id);
            var result = MvcApplication.Mapper.Map<ResultDoctorDto>(doctor);
            return View(result);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateDoctor(UpdateDoctorDto dto)
        {
            var doctor = await _context.Doctors.FindAsync(dto.DoctorId);
            MvcApplication.Mapper.Map(dto, doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}