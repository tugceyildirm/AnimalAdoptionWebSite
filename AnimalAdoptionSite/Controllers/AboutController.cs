using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalAdoptionSite.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm= new AboutManager(new EfAboutDal());

        [Authorize]
        public ActionResult Index()

        {
            var aboutList = abm.GetList();
            return View(aboutList);
        }
                 
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        { 

            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAbout(int id)
        {
            var aboutValue = abm.GetByID(id);
            abm.AboutDelete(aboutValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public PartialViewResult AboutPartial()
        {
            //var aboutList = abm.GetList();
            return PartialView();
        }
        public ActionResult ActivateAbout(int id)
        {
            abm.SetActive(id, true);
            return RedirectToAction("Index");
        }

        public ActionResult DeactivateAbout(int id)
        {
            abm.SetActive(id, false);
            return RedirectToAction("Index");
        }
    }
}

