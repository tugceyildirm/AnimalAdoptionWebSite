using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalAdoptionSite.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager cm = new CustomerManager(new EfCustomerDal());
        [Authorize]
        public ActionResult Index()
        {
            var CustomerValues = cm.GetList();
            return View(CustomerValues);
        }
       
        
        public ActionResult DeleteCustomer(int id)
        {
            var CustomerValues = cm.GetByID(id);
            cm.CustomerDelete(CustomerValues);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                cm.CustomerAdd(customer);
                TempData["SuccessMessage"] = "Kaydınız başarıyla yapılmıştır.";
                return RedirectToAction("Register");
            }
            return View(customer);
        }
    }
}