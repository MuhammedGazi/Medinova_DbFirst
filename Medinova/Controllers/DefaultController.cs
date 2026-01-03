using Medinova.DTOs;
using Medinova.Enums;
using Medinova.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Medinova.Controllers
{
    [AllowAnonymous]
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
            var dateList = new List<SelectListItem>();
            for (int i = 0; i < 7; i++)
            {
                var date = DateTime.Now.AddDays(i);
                dateList.Add(new SelectListItem
                {
                    Text = date.ToString("dd.MMMM.dddd"),
                    Value = date.ToString("yyyy-MM-dd")
                });
            }
            ViewBag.dateList = dateList;
            return PartialView();
        }
        [HttpPost]
        public ActionResult MakeAppointment(Appointment appointment)
        {
            appointment.IsActive = true;
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

        [HttpPost]
        public JsonResult GetAvailableHours(DateTime selectedDate, int doctorId)
        {
            var bookedTimes = context.Appointments.Where(x => x.DoctorId == doctorId
                && x.AppointmentDate == selectedDate).Select(x => x.AppointmentTime).ToList();

            var dtoList = new List<AppointmentAvailabilityDto>();

            foreach (var hour in Times.AppointmentHours)
            {
                var dto = new AppointmentAvailabilityDto();
                dto.Time = hour;

                if (bookedTimes.Contains(hour))
                {
                    dto.IsBooked = true;
                }
                else
                {
                    dto.IsBooked = false;
                }

                dtoList.Add(dto);
            }
            return Json(dtoList, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult DefaultBanner()
        {
            var banner = context.Banners.FirstOrDefault();
            return PartialView(banner);
        }

        public PartialViewResult DefaultAbout()
        {
            var about = context.Abouts.FirstOrDefault();
            return PartialView(about);
        }

        public PartialViewResult DefaultAboutItem()
        {
            var aboutItem = context.AboutItems.ToList();
            return PartialView(aboutItem);
        }

        public PartialViewResult DefaultServices()
        {
            var services = context.Services.ToList();
            return PartialView(services);
        }

        public PartialViewResult DefaultDepartman()
        {
            var departman = context.Departmens.ToList();
            return PartialView(departman);
        }

        public PartialViewResult DefaultTeam()
        {
            var doctors = context.Doctors.ToList();
            return PartialView(doctors);
        }

        public PartialViewResult DefaultAISearch()
        {
            return PartialView();
        }

        public PartialViewResult DefaultTestimonial()
        {
            var testimonial = context.Testimonials.ToList();
            return PartialView(testimonial);
        }
    }
}