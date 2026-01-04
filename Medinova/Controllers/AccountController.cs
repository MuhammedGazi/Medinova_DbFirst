using Medinova.DTOs;
using Medinova.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Medinova.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        MedinovaContext context = new MedinovaContext();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginDto dto)
        {
            var user = context.Users.FirstOrDefault(x => x.UserName == dto.Username && x.Password == dto.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "kullanıcı adı yada şifre hatalı");
                return View(dto);
            }
            var roleId = context.RoleRelations.Where(x => x.UserId == user.UserId).Select(x => x.RoleId).FirstOrDefault();
            var roleName = context.Roles.Where(x => x.RoleId == roleId).Select(x => x.RoleName).FirstOrDefault();

            FormsAuthentication.SetAuthCookie(user.UserName, false);
            Session["userName"] = user.UserName;
            Session["fullName"] = user.FirstName + " " + user.LastName;
            Session["role"] = roleName;
            Session["userId"] = user.UserId;
            if (roleName == "Admin")
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            if (roleName == "Doctor")
            {
                return RedirectToAction("Index", "Appointment", new { area = "Doctor" });
            }
            if (roleName == "User")
            {
                return RedirectToAction("Index", "Appointment", new { area = "User" });
            }

            return RedirectToAction("Index", "AdminAbout");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}