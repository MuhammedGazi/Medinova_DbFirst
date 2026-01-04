using Medinova.DTOs.AppointmentDtos;
using Medinova.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Medinova.Areas.Doctor.Controllers
{
    public class AppointmentController : Controller
    {
        MedinovaContext _context = new MedinovaContext();
        public ActionResult Index()
        {
            int doktorUserId = (int)Session["userId"];
            int? doctorId = _context.UserDoctors.Where(x => x.UserId == doktorUserId).Select(y => y.DoctorId).FirstOrDefault();
            var appo = _context.Appointments.Where(x => x.DoctorId == doctorId).ToList();
            var result = MvcApplication.Mapper.Map<List<ResultAppointmentDto>>(appo);
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