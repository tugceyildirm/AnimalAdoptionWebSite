using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AnimalAdoptionSite.Controllers
{
    public class LoginController : Controller
    {
        UserLoginManager um = new UserLoginManager(new EfCustomerDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName 
            && x.AdminPassword == p.AdminPassword);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminAnimal");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
        }
        [HttpGet]
        public ActionResult UserLogin()
        {
        return View(); 
        }
        [HttpPost]
        public ActionResult UserLogin(Customer p)
        {
            //Context c = new Context();
            //var Username = c.Customers.FirstOrDefault(x => x.UserEmail == p.UserEmail
            //&& x.UserPassword == p.UserPassword);
            var user = um.GetUser(p.UserEmail, p.UserPassword);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserEmail, false);
                Session["UserEmail."] = user.UserEmail;
                return RedirectToAction("Index", "HomePage");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı";
                return View("UserLogin");
            }
        }
    }
}