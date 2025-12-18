using Medinova.Models;
using System.Linq;
using System.Web.Mvc;

namespace Medinova.Controllers
{
    public class DefaultController : Controller
    {
        MedinovaContext context = new MedinovaContext();



        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult DefaultAppointment()
        {
            var departments = context.Departmens.ToList();
            ViewBag.departments = (from departman in departments
                                   select new SelectListItem
                                   {
                                       Text = departman.Name,
                                       Value = departman.DepartmenId.ToString()
                                   }).ToList();
            return PartialView();
        }
        [HttpPost]
        public ActionResult MakeAppointment(Appointment appointment)
        {

            context.Appointments.Add(appointment);
            context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public JsonResult GetDoctorsByDepartmentId(int departmentId)
        {
            var doctors = context.Doctors.Where(x => x.DepartmenId == departmentId)
                                           .Select(doctor => new SelectListItem
                                           {
                                               Text = doctor.FullName,
                                               Value = doctor.DoctorId.ToString()
                                           }).ToList();
            return Json(doctors, JsonRequestBehavior.AllowGet);
        }
    }
}