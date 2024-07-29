using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalAdoptionSite.UserPanelController
{
    public class AboutPanelController : Controller
    {
        AboutManager am =new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {  var about = am.GetActiveAbouts(); 
            return View(about);
        }
        }
    }
