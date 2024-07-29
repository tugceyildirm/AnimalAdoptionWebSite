using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalAdoptionSite.UserPanelController
{
    public class PetShopPanelController : Controller
    {

        PetShopManager pm = new PetShopManager(new EfPetShopDal());
        public ActionResult Index()
        {
            var p = pm.GetList(); 
            return View(p);
        }
        
    }

}