using Medinova.DTOs.AppointmentDtos;
using Medinova.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Medinova.Areas.User.Controllers
{
    public class AppointmentController : Controller
    {
        MedinovaContext _context = new MedinovaContext();
        // GET: User/Appointment
        public ActionResult Index()
        {
            int userId = (int)Session["userId"];
            string fullName = _context.Users.Where(x => x.UserId == userId).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();
            var appo = _context.Appointments.Where(x => x.FullName == fullName).ToList();
            var result = MvcApplication.Mapper.Map<List<ResultUserAppointmentDto>>(appo);
            return View(result);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var appo = await _context.Appointments.FindAsync(id);
            _context.Appointments.Remove(appo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}