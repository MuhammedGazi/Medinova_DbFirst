using Medinova.DTOs.TestimonialDtos;
using Medinova.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Medinova.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class TestimonialController : Controller
    {
        MedinovaContext _context = new MedinovaContext();

        private async Task GetUsers()
        {
            var users = _context.Users.Select(x => new
            {
                UserId = x.UserId,
                FullName = x.FirstName + " " + x.LastName
            }).ToList();

            ViewBag.Users = new SelectList(users, "UserId", "FullName");
        }
        // GET: Admin/Testimonial
        public async Task<ActionResult> Index()
        {
            var test = await _context.Testimonials.ToListAsync();
            var result = MvcApplication.Mapper.Map<List<ResultTestimonialDto>>(test);
            return View(result);
        }

        [HttpGet]
        public async Task<ActionResult> CreateTestimonial()
        {
            await GetUsers();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateTestimonial(CreateTestimonialDto dto)
        {
            var test = MvcApplication.Mapper.Map<Testimonial>(dto);
            _context.Testimonials.Add(test);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> UpdateTestimonial(int id)
        {
            await GetUsers();
            var test = await _context.Testimonials.FindAsync(id);
            var result = MvcApplication.Mapper.Map<ResultTestimonialDto>(test);
            return View(result);
        }
        [HttpPost]
        public async Task<ActionResult> UpdateTestimonial(UpdateTestimonialDto dto)
        {
            var test = await _context.Testimonials.FindAsync(dto.TestimonialId);
            MvcApplication.Mapper.Map(dto, test);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> DeleteTestimonial(int id)
        {
            var test = await _context.Testimonials.FindAsync(id);
            _context.Testimonials.Remove(test);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}